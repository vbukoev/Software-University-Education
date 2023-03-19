using System.Globalization;
using Newtonsoft.Json;
using VaporStore.Data.Models;
using VaporStore.DataProcessor.ExportDto;

namespace VaporStore.DataProcessor
{ 
    using Data;
    using System.Text;
    using System.Xml.Serialization;

    public static class Serializer
    {
        public static string ExportGamesByGenres(VaporStoreDbContext context, string[] genreNames)
        {
            var exportGames = context.Genres
                .Where(x => genreNames.Contains(x.Name))
                .ToArray()
                .Select(x => new
                {
                    Id = x.Id,
                    Genre = x.Name,
                    Games = x.Games.Where(x => x.Purchases.Any()).Select(game => new
                        {
                            Id = game.Id,
                            Title = game.Name,
                            Developer = game.Developer.Name,
                            Tags = String.Join(", ", game.GameTags.Select(gt => gt.Tag.Name)),
                            Players = game.Purchases.Count
                        })
                        .OrderByDescending(x => x.Players)
                        .ThenBy(x => x.Id)
                        .ToArray(),
                    TotalPlayers = x.Games.Sum(x => x.Purchases.Count)
                })
                .OrderByDescending(x => x.TotalPlayers)
                .ThenBy(x => x.Id)
                .ToArray();

            return JsonConvert.SerializeObject(exportGames, Formatting.Indented);
        }

        public static string ExportUserPurchasesByType(VaporStoreDbContext context, string purchaseType)
        {
            ExportUserDto[] userDtos = context.Users
                .ToArray()
                .Where(x => x.Cards.Any(c => c.Purchases.Any(p => p.Type.ToString() == purchaseType)))
                .Select(x => new ExportUserDto()
                {
                    Username = x.Username,
                    TotalSpent = x.Cards
                        .Sum(c => c.Purchases.Where(p => p.Type.ToString() == purchaseType)
                            .Sum(p => p.Game.Price)),
                    Purchases = x.Cards
                        .SelectMany(c => c.Purchases
                            .Where(p => p.Type.ToString() == purchaseType)
                            .Select(p => new ExportPurchasesDto()
                            {
                                Card = p.Card.Number,
                                Cvc = p.Card.Cvc,
                                Date = p.Date.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                                Game = new ExportGameDto()
                                {
                                    Genre = p.Game.Genre.Name,
                                    Title = p.Game.Name,
                                    Price = p.Game.Price
                                }
                            }))
                        .OrderBy(p => p.Date)
                        .ToArray()
                })
                .OrderByDescending(x => x.TotalSpent)
                .ThenBy(x => x.Username)
                .ToArray();

            return Serialize<ExportUserDto[]>(userDtos, "Users");
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