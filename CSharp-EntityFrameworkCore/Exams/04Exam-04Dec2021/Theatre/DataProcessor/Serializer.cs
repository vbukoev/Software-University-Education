using Newtonsoft.Json;
using Theatre.DataProcessor.ExportDto;

namespace Theatre.DataProcessor
{

    using System;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var exportPlays = context.Theatres
                .Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count >= 20)
                .ToArray()
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(ti => ti.RowNumber >= 1 && ti.RowNumber <= 5)
                        .Sum(ti => ti.Price),
                    Tickets = t.Tickets.Select(x => new
                        {
                            Price = x.Price,
                            RowNumber = x.RowNumber
                        })
                        .Where(x => x.RowNumber >= 1 && x.RowNumber <= 5)
                        .OrderByDescending(x => x.Price)
                        .ToArray()
                })
                .OrderByDescending(t => t.Halls)
                .ThenBy(t => t.Name)
                .ToArray();

            return JsonConvert.SerializeObject(exportPlays, Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double raiting)
        {
            ExportPlayDto[] playDtos = context.Plays
                .Where(p => p.Rating <= raiting)
                .ToArray()
                .Select(p => new ExportPlayDto()
                {
                    Rating = p.Rating == 0 ? "Premier" : p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Title = p.Title,
                    Duration = p.Duration.ToString("c"),
                    Actors = p.Casts.Where(x => x.IsMainCharacter)
                        .Select(x => new ExportActorDto()
                        {
                            FullName = x.FullName,
                            MainCharacter = $"Plays main character in '{p.Title}'."
                        })
                        .OrderByDescending(x => x.FullName)
                        .ToArray()
                })
                .OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            return Serialize<ExportPlayDto[]>(playDtos, "Plays");
        }

        private static string Serialize<T>(T dataTransferObjects, string xmlRootAttributeName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

            StringBuilder sb = new StringBuilder();
            using var write = new StringWriter(sb);

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(write, dataTransferObjects, xmlNamespaces);

            return sb.ToString();
        }
    }
}
