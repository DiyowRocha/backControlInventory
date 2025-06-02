using AutoMapper;
using backControlInventory.Domain.Model;

namespace backControlInventory.Application.Service.Models;

public class ModelMappingProfile : Profile
{
    public ModelMappingProfile()
    {
        CreateMap<ModelDto, Model>();
        CreateMap<Model, ModelViewModel>()
            .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.Manufacturer.Name));
    }
}