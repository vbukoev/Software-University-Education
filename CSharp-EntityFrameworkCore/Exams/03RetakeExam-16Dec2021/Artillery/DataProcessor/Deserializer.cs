namespace Artillery.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    using Newtonsoft.Json;
    using System.Linq;
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.DataProcessor.ImportDto;
    using Artillery.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            var deserializer = new XmlSerializer(typeof(CountryDto[]), new XmlRootAttribute("Countries"));
            var objects = (CountryDto[])deserializer.Deserialize(new StringReader(xmlString));
            var countries = new List<Country>();
            var sb = new StringBuilder();

            foreach (var dto in objects)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var country = new Country
                {
                    CountryName = dto.CountryName,
                    ArmySize = dto.ArmySize
                };

                countries.Add(country);
                sb.AppendLine(string.Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            var deserializer = new XmlSerializer(typeof(ManufacturerDto[]), new XmlRootAttribute("Manufacturers"));
            var objects = (ManufacturerDto[])deserializer.Deserialize(new StringReader(xmlString));
            var manufacturers = new List<Manufacturer>();
            var sb = new StringBuilder();


            foreach (var dto in objects)
            {
                var uniqueManufacturer = manufacturers.FirstOrDefault(x => x.ManufacturerName == dto.ManufacturerName);

                if (!IsValid(dto) || uniqueManufacturer != null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var manufacturer = new Manufacturer
                {
                    ManufacturerName = dto.ManufacturerName,
                    Founded = dto.Founded
                };

                manufacturers.Add(manufacturer);
                var manufacturerCountry = manufacturer.Founded.Split(", ").ToArray();
                var last = manufacturerCountry.Skip(Math.Max(0, manufacturerCountry.Count() - 2)).ToArray();
                sb.AppendLine(string.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, string.Join(", ", last)));
            }
            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            var deserializer = new XmlSerializer(typeof(ShellDto[]), new XmlRootAttribute("Shells"));
            var objects = (ShellDto[])deserializer.Deserialize(new StringReader(xmlString));
            var shells = new List<Shell>();
            var sb = new StringBuilder();

            foreach (var dto in objects)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var shell = new Shell
                {
                    ShellWeight = dto.ShellWeight,
                    Caliber = dto.Caliber
                };

                shells.Add(shell);
                sb.AppendLine(string.Format(SuccessfulImportShell, dto.Caliber, dto.ShellWeight));
            }

            context.Shells.AddRange(shells);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            var validGunTypes = new string[] { "Howitzer", "Mortar", "FieldGun", "AntiAircraftGun", "MountainGun", "AntiTankGun" };
            var gunsJson = JsonConvert.DeserializeObject<GunDto[]>(jsonString);
            var guns = new List<Gun>();
            var sb = new StringBuilder();

            foreach (var dto in gunsJson)
            {
                if (!IsValid(dto) ||
                    !validGunTypes.Contains(dto.GunType))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var gun = new Gun
                {
                    ManufacturerId = dto.ManufacturerId,
                    GunWeight = dto.GunWeight,
                    BarrelLength = dto.BarrelLength,
                    NumberBuild = dto.NumberBuild,
                    Range = dto.Range,
                    GunType = (GunType)Enum.Parse(typeof(GunType), dto.GunType),
                    ShellId = dto.ShellId
                };

                foreach (var countryDto in dto.Countries)
                {
                    gun.CountriesGuns.Add(new CountryGun
                    {
                        CountryId = countryDto.Id,
                        Gun = gun
                    });
                }

                guns.Add(gun);
                sb.AppendLine(string.Format(SuccessfulImportGun, dto.GunType, dto.GunWeight, dto.BarrelLength));
            }

            context.Guns.AddRange(guns);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
