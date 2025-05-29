namespace backControlInventory.Domain.Model;

public class Building
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int UnitId { get; set; }
    public Unit Unit { get; set; }

    public ICollection<Department> Departments { get; set; } = new List<Department>();
}