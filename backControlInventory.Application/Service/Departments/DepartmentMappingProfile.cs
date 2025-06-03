using AutoMapper;
using backControlInventory.Domain.Model;

namespace backControlInventory.Application.Service.Departments;

public class DepartmentMappingProfile : Profile
{
    public DepartmentMappingProfile()
    {
        CreateMap<DepartmentDto, Department>();
        CreateMap<Department, DepartmentSimpleViewModel>();
        CreateMap<Department, DepartmentViewModel>()
            .ForMember(dest => dest.BuildingName, opt => opt.MapFrom(src =>
            src.Building.Name));
    }
}