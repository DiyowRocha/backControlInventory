namespace backControlInventory.Application.Service.Devices;

public interface IDeviceService
{
    Task<DeviceViewModel> CreateDeviceAsync(DeviceDto dto);
    Task<IEnumerable<DeviceViewModel>> GetAllDevicesAsync();
    Task<DeviceViewModel> GetDeviceByIdAsync(int id);
    Task<DeviceViewModel> UpdateDeviceAsync(DeviceDto dto, int id);
    Task<bool> DeleteDeviceAsync(int id);
}