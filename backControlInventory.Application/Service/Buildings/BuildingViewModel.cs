using backControlInventory.Application.Service.Departments;
using backControlInventory.Application.Service.Units;

namespace backControlInventory.Application.Service.Buildings;

public class BuildingViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string UnitName { get; set; }

    public List<DepartmentSimpleViewModel> Departments { get; set; } = new List<DepartmentSimpleViewModel>();
}