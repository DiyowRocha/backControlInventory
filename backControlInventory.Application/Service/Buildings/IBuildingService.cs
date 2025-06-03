namespace backControlInventory.Application.Service.Buildings;

public interface IBuildingService
{
    Task<BuildingViewModel> CreateBuildingAsync(BuildingDto dto);
    Task<IEnumerable<BuildingViewModel>> GetAllBuildingsAsync();
    Task<BuildingViewModel> GetBuildingByIdAsync(int id);
    Task<BuildingViewModel> UpdateBuildingAsync(BuildingDto dto, int id);
    Task<bool> DeleteBuildingAsync(int id);
}