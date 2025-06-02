using AutoMapper;
using backControlInventory.Domain.Model;

namespace backControlInventory.Application.Service.Manufacturers;

public class ManufacturerMappingProfile : Profile
{
    public ManufacturerMappingProfile()
    {
        CreateMap<ManufacturerDto, Manufacturer>();
        CreateMap<Manufacturer, ManufacturerViewModel>();
    }
}