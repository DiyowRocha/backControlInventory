using backControlInventory.Application.Service.Buildings;

namespace backControlInventory.Application.Service.Units;

public class UnitWithBuildingsViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<BuildingSimpleViewModel> Buildings { get; set; }
}