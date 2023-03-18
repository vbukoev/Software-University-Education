namespace SoftJail.DataProcessor
{
    using System;
    using System.IO;
    using System.Text;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;

    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using ImportDto;
    // ReSharper disable InconsistentNaming

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data";

        private const string SuccessfullyImportedDepartment = "Imported {0} with {1} cells";

        private const string SuccessfullyImportedPrisoner = "Imported {0} {1} years old";

        private const string SuccessfullyImportedOfficer = "Imported {0} ({1} prisoners)";

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportDepartmentDto[] departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);

            List<Department> departments = new List<Department>();

            foreach (ImportDepartmentDto departmentDto in departmentDtos)
            {
                if (!IsValid(departmentDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Department d = new Department()
                {
                    Name = departmentDto.Name
                };

                bool isDepValid = true;
                foreach (ImportDepartmentCellDto cellDto in departmentDto.Cells)
                {
                    if (!IsValid(cellDto))
                    {
                        isDepValid = false;
                        break;
                    }

                    d.Cells.Add(new Cell()
                    {
                        CellNumber = cellDto.CellNumber,
                        HasWindow = cellDto.HasWindow
                    });
                }

                if (!isDepValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (d.Cells.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                departments.Add(d);
                sb.AppendLine(String.Format(SuccessfullyImportedDepartment, d.Name, d.Cells.Count));
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            ImportPrisonerDto[] prisonerDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);

            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (ImportPrisonerDto prisonerDto in prisonerDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime incarcerationDate;
                bool isIncarcerationDateValid = DateTime.TryParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out incarcerationDate);

                if (!isIncarcerationDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime? releaseDate = null;
                if (!String.IsNullOrEmpty(prisonerDto.ReleaseDate))
                {
                    DateTime releaseDateValue;
                    bool isReleaseDateValid = DateTime.TryParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy",
                        CultureInfo.InvariantCulture, DateTimeStyles.None, out releaseDateValue);

                    if (!isReleaseDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    releaseDate = releaseDateValue;
                }

                Prisoner p = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = releaseDate,
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                bool areMailsValid = true;
                foreach (ImportPrisonerMailDto mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        areMailsValid = false;
                        continue;
                    }

                    p.Mails.Add(new Mail()
                    {
                        Description = mailDto.Description,
                        Sender = mailDto.Sender,
                        Address = mailDto.Address
                    });
                }

                if (!areMailsValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                prisoners.Add(p);
                sb.AppendLine(String.Format(SuccessfullyImportedPrisoner, p.FullName, p.Age));
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportOfficerDto[]), new XmlRootAttribute("Officers"));

            List<Officer> officers = new List<Officer>();

            using (StringReader stringReader = new StringReader(xmlString))
            {
                ImportOfficerDto[] officerDtos = (ImportOfficerDto[])xmlSerializer.Deserialize(stringReader);

                foreach (ImportOfficerDto officerDto in officerDtos)
                {
                    if (!IsValid(officerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object positionObj;
                    bool isPositionValid = Enum.TryParse(typeof(Position), officerDto.Position, out positionObj);

                    if (!isPositionValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    object weaponObj;
                    bool isWeaponValid = Enum.TryParse(typeof(Weapon), officerDto.Weapon, out weaponObj);

                    if (!isWeaponValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Officer o = new Officer()
                    {
                        FullName = officerDto.FullName,
                        Salary = officerDto.Salary,
                        Position = (Position)positionObj,
                        Weapon = (Weapon)weaponObj,
                        DepartmentId = officerDto.DepartmentId
                    };

                    foreach (ImportOfficerPrisonerDto prisonerDto in officerDto.Prisoners)
                    {
                        o.OfficerPrisoners.Add(new OfficerPrisoner()
                        {
                            Officer = o,
                            PrisonerId = prisonerDto.PrisonerId
                        });
                    }

                    officers.Add(o);
                    sb.AppendLine(String.Format(SuccessfullyImportedOfficer, o.FullName, o.OfficerPrisoners.Count));
                }

                context.Officers.AddRange(officers);
                context.SaveChanges();
            }

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(obj, validationContext, validationResult, true);
            return isValid;
        }
    }
}