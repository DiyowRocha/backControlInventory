namespace backControlInventory.Application.Service.Models;

public interface IModelService
{
    Task<ModelViewModel> CreateModelAsync(ModelDto dto);
    Task<IEnumerable<ModelViewModel>> GetAllModelsAsync();
    Task<ModelViewModel> GetModelByIdAsync(int id);
    Task<ModelViewModel> UpdateModelAsync(ModelDto dto, int id);
    Task<bool> DeleteModelAsync(int id);
}