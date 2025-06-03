using AutoMapper;
using backControlInventory.Application.Service.ChipInfos;
using backControlInventory.Application.Service.Devices;
using backControlInventory.Application.Service.NetworkInfos;
using backControlInventory.Domain.Model;

namespace backControlInventory.Application.Service.MappingProfiles;

public class DeviceMappingProfile : Profile
{
    public DeviceMappingProfile()
    {
        CreateMap<Device, DeviceViewModel>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
            .ForMember(dest => dest.ManufacturerName, opt => opt.MapFrom(src => src.Manufacturer.Name))
            .ForMember(dest => dest.ModelName, opt => opt.MapFrom(src => src.Model.Name))
            .ForMember(dest => dest.NetworkInfo, opt => opt.MapFrom(src => src.NetworkInfo))
            .ForMember(dest => dest.ChipInfo, opt => opt.MapFrom(src => src.ChipInfo));

        CreateMap<NetworkInfo, NetworkInfoViewModel>();
        CreateMap<ChipInfo, ChipInfoViewModel>();

        CreateMap<DeviceDto, Device>()
            .ForMember(dest => dest.NetworkInfo, opt => opt.MapFrom(src => src.NetworkInfo))
            .ForMember(dest => dest.ChipInfo, opt => opt.MapFrom(src => src.ChipInfo));

        CreateMap<NetworkInfoDto, NetworkInfo>();
        CreateMap<ChipInfoDto, ChipInfo>();

        CreateMap<Device, DeviceDto>()
            .ForMember(dest => dest.NetworkInfo, opt => opt.MapFrom(src => src.NetworkInfo))
            .ForMember(dest => dest.ChipInfo, opt => opt.MapFrom(src => src.ChipInfo));

        CreateMap<NetworkInfo, NetworkInfoDto>();
        CreateMap<ChipInfo, ChipInfoDto>();
    }
}