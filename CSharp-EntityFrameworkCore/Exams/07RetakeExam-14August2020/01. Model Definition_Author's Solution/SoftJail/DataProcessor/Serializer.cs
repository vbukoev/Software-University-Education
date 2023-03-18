namespace SoftJail.DataProcessor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Globalization;

    using Newtonsoft.Json;
    using System.Xml.Serialization;

    using Data;
    using ExportDto;
    using System.Xml;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportPrisonersByCells(SoftJailDbContext context, int[] ids)
        {
            var prisoners = context
                .Prisoners
                .ToArray()
                .Where(p => ids.Contains(p.Id))
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.FullName,
                    CellNumber = p.Cell.CellNumber,
                    Officers = p.PrisonerOfficers
                        .Select(po => new
                        {
                            OfficerName = po.Officer.FullName,
                            Department = po.Officer.Department.Name
                        })
                        .OrderBy(o => o.OfficerName)
                        .ToArray(),
                    TotalOfficerSalary = Math.Round(p.PrisonerOfficers.Sum(po => po.Officer.Salary), 2)
                })
                .OrderBy(p => p.Name)
                .ThenBy(p => p.Id)
                .ToArray();

            string json = JsonConvert.SerializeObject(prisoners, Formatting.Indented);

            return json;
        }

        public static string ExportPrisonersInbox(SoftJailDbContext context, string prisonersNames)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportPrisonerDto[]), new XmlRootAttribute("Prisoners"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            string[] prisonerNamesArr = prisonersNames
                .Split(",")
                .ToArray();

            ExportPrisonerDto[] prisoners = context
                .Prisoners
                .ToArray()
                .Where(p => prisonerNamesArr.Contains(p.FullName))
                .Select(p => new ExportPrisonerDto()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                    IncarcerationDate = p.IncarcerationDate.ToString("yyyy-MM-dd", CultureInfo.CurrentCulture),
                    Mails = p.Mails
                        .Select(m => new ExportPrisonerMailDto()
                        {
                            ReversedDescription = String.Join("", m.Description.Reverse())
                        })
                        .ToArray()
                })
                .OrderBy(p => p.FullName)
                .ThenBy(p => p.Id)
                .ToArray();

            using (StringWriter stringWriter = new StringWriter(sb))
            {
                xmlSerializer.Serialize(stringWriter, prisoners, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}