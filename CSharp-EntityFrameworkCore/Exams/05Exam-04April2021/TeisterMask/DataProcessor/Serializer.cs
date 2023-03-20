using System.Globalization;
using Newtonsoft.Json;
using TeisterMask.Data.Models.Enums;
using TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor
{
    using Data;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            ExportProjectDto[] projectDtos = context.Projects
                .Where(x => x.Tasks.Any())
                .ToArray()
                .Select(x => new ExportProjectDto()
                {
                    TasksCount = x.Tasks.Count,
                    ProjectName = x.Name,
                    HasEndDate = x.DueDate == null ? "No" : "Yes",
                    Tasks = x.Tasks.Select(t => new ExportTaskDto()
                        {
                            Name = t.Name,
                            Label = t.LabelType.ToString()
                        })
                        .OrderBy(t => t.Name)
                        .ToArray()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.ProjectName)
                .ToArray();

            return Serialize<ExportProjectDto[]>(projectDtos, "Projects");
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var busiestEmployees = context
                .Employees
                .Where(x => x.EmployeesTasks.Any(et => et.Task.OpenDate >= date))
                .ToArray()
                .Select(e => new
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(et => et.Task.OpenDate >= date)
                        .OrderByDescending(et => et.Task.DueDate)
                        .ThenBy(et => et.Task.Name)
                        .Select(et => new
                        {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                            DueDate = et.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString()
                        })
                        .ToArray()
                })
                .OrderByDescending(e => e.Tasks.Count())
                .ThenBy(e => e.Username)
                .Take(10)
                .ToArray();

            return JsonConvert.SerializeObject(busiestEmployees, Formatting.Indented);
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