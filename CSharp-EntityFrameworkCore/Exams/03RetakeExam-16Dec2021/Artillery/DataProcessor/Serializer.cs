
namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.DataProcessor.ExportDto;
    using AutoMapper;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportShells(ArtilleryContext context, double shellWeight)
        {
            var result = context.Shells
               .Where(x => x.ShellWeight > shellWeight)
                .Select(x => new
                {
                    ShellWeight = x.ShellWeight,
                    Caliber = x.Caliber,
                    Guns = x.Guns.Where(x => ((int)x.GunType) == 3)
                                 .Select(g => new
                                 {
                                     GunType = g.GunType.ToString(),
                                     GunWeight = g.GunWeight,
                                     BarrelLength = g.BarrelLength,
                                     Range = g.Range > 3000 ? "Long-range" : "Regular range",
                                 })
                    .OrderByDescending(x => x.GunWeight)
                    .ToArray()
                })
                .OrderBy(x => x.ShellWeight)
                .ToArray();

            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            return json;
        }

        public static string ExportGuns(ArtilleryContext context, string manufacturer)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ExportCountriesDto[]), new XmlRootAttribute("Guns"));

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add("", "");

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                var result = context.Guns.Where(x => x.Manufacturer.ManufacturerName == manufacturer)
                    .Select(x => new ExportCountriesDto
                    {
                        Manufacturer = x.Manufacturer.ManufacturerName,
                        GunType = x.GunType.ToString(),
                        BarrelLength = x.BarrelLength,
                        GunWeight = x.GunWeight,
                        Range = x.Range,
                        Countries = x.CountriesGuns.Where(x => x.Country.ArmySize > 4500000)
                        .Select(a => new CountriesExportDto
                        {
                            CountryName = a.Country.CountryName,
                            ArmySize = a.Country.ArmySize
                        })
                      .OrderBy(x => x.ArmySize)
                      .ToArray()
                    })
                    .OrderBy(x => x.BarrelLength)
                    .ToArray();

                // ExportCountriesDto[] result = Mapper.Map<ExportCountriesDto[]>(guns).OrderBy(x => x.BarrelLength).ToArray();

                xmlSerializer.Serialize(stringWriter, result, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
