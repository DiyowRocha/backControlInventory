namespace backControlInventory.Application.Service.Units;

public interface IUnitService
{
    Task<UnitViewModel> CreateUnitAsync(UnitDto dto);
    Task<IEnumerable<UnitViewModel>> GetAllUnitsAsync();
    Task<UnitViewModel> GetUnitByIdAsync(int id);
    Task<UnitViewModel> GetUnitByZipCodeAsync(string zipCode);
    Task<UnitViewModel> UpdateUnitAsync(UnitDto dto, int id);
    Task<bool> DeleteUnitAsync(int id);
}