using AutoMapper;
using backControlInventory.Application.Service.Addresses;
using backControlInventory.Application.Service.Buildings;
using backControlInventory.Domain.Model;

namespace backControlInventory.Application.Service.Units;

public class UnitMappingProfile : Profile
{
    public UnitMappingProfile()
    {
        CreateMap<AddressDto, Address>();

        CreateMap<UnitDto, Unit>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address));

        CreateMap<Unit, UnitViewModel>()
            .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number))
            .ForMember(dest => dest.Complement, opt => opt.MapFrom(src => src.Address.Complement))
            .ForMember(dest => dest.Neighborhood, opt => opt.MapFrom(src => src.Address.Neighborhood))
            .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
            .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.Address.State))
            .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
            .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.Address.ZipCode));

        CreateMap<Unit, UnitWithBuildingsViewModel>();

        CreateMap<Building, BuildingSimpleViewModel>();
    }
}