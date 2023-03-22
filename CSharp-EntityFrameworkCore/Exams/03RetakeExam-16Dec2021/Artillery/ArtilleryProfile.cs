namespace Artillery
{
    using Artillery.Data.Models;
    using Artillery.DataProcessor.ExportDto;
    using AutoMapper;
    using System.Linq;

    public class ArtilleryProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public ArtilleryProfile()
        {
            this.CreateMap<Country, CountriesExportDto>()
                .ForMember(dto => dto.CountryName, m =>
                m.MapFrom(t => t.CountryName))
                .ForMember(dto => dto.ArmySize, m =>
                m.MapFrom(t => t.ArmySize));
            this.CreateMap<Gun, ExportCountriesDto>()
                .ForMember(dto => dto.Manufacturer, m =>
                m.MapFrom(t => t.Manufacturer.ManufacturerName))
                .ForMember(dto => dto.GunType, m =>
                m.MapFrom(t => t.GunType.ToString()))
                .ForMember(dto => dto.BarrelLength, m =>
                m.MapFrom(t => t.BarrelLength))
                .ForMember(dto => dto.GunWeight, m =>
                m.MapFrom(t => t.GunWeight))
                .ForMember(dto => dto.Range, m =>
                m.MapFrom(t => t.Range))
                .ForMember(dto => dto.Countries, m =>
                m.MapFrom(t => t.CountriesGuns.Where(x => x.Country.ArmySize > 4500000)
                                              .Select(y => new { y.Country.CountryName, y.Country.ArmySize })
                                              .OrderBy(c => c.ArmySize)
                                              .ToArray()
                          ));
        }
    }
}