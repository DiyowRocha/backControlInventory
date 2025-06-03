
using backControlInventory.Application.Service.ChipInfos;
using backControlInventory.Application.Service.NetworkInfos;
using backControlInventory.Domain.Model;

namespace backControlInventory.Application.Service.Devices;

public class DeviceViewModel
{
    public int Id { get; set; }
    public string Type { get; set; }
    public string SerialNumber { get; set; }

    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; }

    public int ModelId { get; set; }
    public string ModelName { get; set; }
    
    public NetworkInfoViewModel? NetworkInfo { get; set; }
    public ChipInfoViewModel? ChipInfo { get; set; }
}