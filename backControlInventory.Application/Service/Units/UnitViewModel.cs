namespace backControlInventory.Application.Service.Units;

public class UnitViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; } = "Brazil";
    public string ZipCode { get; set; }
}