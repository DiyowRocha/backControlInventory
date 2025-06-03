using AutoMapper;
using backControlInventory.Application.Service.Departments;
using backControlInventory.Domain.Model;

namespace backControlInventory.Application.Service.Buildings;

public class BuildingMappingProfile : Profile
{
    public BuildingMappingProfile()
    {
        CreateMap<BuildingDto, Building>();
        CreateMap<Department, DepartmentViewModel>();
        CreateMap<Building, BuildingViewModel>()
            .ForMember(dest => dest.UnitName, opt => opt.MapFrom(src =>
            src.Unit.Name))
            .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.Departments));
    }
}