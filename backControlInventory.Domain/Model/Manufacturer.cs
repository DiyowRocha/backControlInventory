namespace backControlInventory.Domain.Model;

public class Manufacturer
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<Device>? Devices { get; set; } = new List<Device>();
}