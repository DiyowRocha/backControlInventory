using backControlInventory.Application.Service.ChipInfos;
using backControlInventory.Application.Service.NetworkInfos;
using backControlInventory.Domain.Enum;
using backControlInventory.Domain.Model;

namespace backControlInventory.Application.Service.Devices;

public class DeviceDto
{
    public DeviceType Type { get; set; }
    public string SerialNumber { get; set; }
    public int ManufacturerId { get; set; }
    public int ModelId { get; set; }
    public NetworkInfoDto? NetworkInfo { get; set; }
    public ChipInfoDto? ChipInfo { get; set; }
}