using backControlInventory.Application.Service.Addresses;

namespace backControlInventory.Application.Service.Units;

public class UnitDto
{
    public string Name { get; set; }
    
    public AddressDto Address { get; set; }
}