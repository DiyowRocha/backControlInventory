namespace backControlInventory.Application.Service.Manufacturers;

public interface IManufacturerService
{
    Task<ManufacturerViewModel> CreateManufacturerAsync(ManufacturerDto dto);
    Task<IEnumerable<ManufacturerViewModel>> GetAllManufacturersAsync();
    Task<ManufacturerViewModel> GetManufacturerById(int id);
    Task<ManufacturerViewModel> UpdateManufacturerAsync(ManufacturerDto dto, int id);
    Task<bool> DeleteManufacturerAsync(int id);
}