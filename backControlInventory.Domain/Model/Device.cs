using backControlInventory.Domain.Enum;

namespace backControlInventory.Domain.Model;

public class Device
{
    public int Id { get; set; }
    public DeviceType Type { get; set; }
    public string SerialNumber { get; set; }
    public DeviceStatus Status { get; set; }

    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; }

    public int ModelId { get; set; }
    public Model Model { get; set; }

    public NetworkInfo? NetworkInfo { get; set; }
    public ChipInfo? ChipInfo { get; set; }
}