namespace backControlInventory.Domain.Model;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int BuildingId { get; set; }
    public Building Building { get; set; }
}