namespace backControlInventory.Domain.Model;

public class Unit
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Address Address { get; set; }

    public ICollection<Building> Buildings { get; set; } = new List<Building>();
}