using AutoMapper;
using backControlInventory.Domain.Enum;
using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Models;
using backControlInventory.Infrastructure.Repository.Devices;
using backControlInventory.Infrastructure.Repository.Manufacturers;

namespace backControlInventory.Application.Service.Devices;

public class DeviceService : IDeviceService
{
    private readonly IDeviceRepository _deviceRepository;
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IModelRepository _modelRepository;
    private readonly IMapper _mapper;

    public DeviceService(IDeviceRepository deviceRepository, IManufacturerRepository manufacturerRepository, IModelRepository modelRepository, IMapper mapper)
    {
        _deviceRepository = deviceRepository;
        _manufacturerRepository = manufacturerRepository;
        _modelRepository = modelRepository;
        _mapper = mapper;
    }

    public async Task<DeviceViewModel> CreateDeviceAsync(DeviceDto dto)
    {
        switch (dto.Type)
        {
            case DeviceType.AccessPoint:
            case DeviceType.Firewall:
            case DeviceType.Printer:
            case DeviceType.Server:
            case DeviceType.Switch:
                if (dto.NetworkInfo is null)
                    throw new ArgumentException($"NetworkInfo is required for {dto.Type}.");
                break;

            case DeviceType.MobileChip:
                if (dto.ChipInfo is null)
                    throw new ArgumentException($"ChipInfo is required for MobileChip.");
                break;

            default:
                if (dto.NetworkInfo is not null || dto.ChipInfo is not null)
                    throw new ArgumentException("NetworkInfo and ChipInfo must be null for this device type.");
                break;
        }

        var manufacturer = await _manufacturerRepository.GetById(dto.ManufacturerId);
        if (manufacturer == null)
            throw new Exception("Manufacturer not found.");

        var model = await _modelRepository.GetById(dto.ModelId);
        if (model == null)
            throw new Exception("Model not found");

        var createdDevice = _mapper.Map<Device>(dto);

        await _deviceRepository.Add(createdDevice);

        return _mapper.Map<DeviceViewModel>(createdDevice);
    }

    public async Task<IEnumerable<DeviceViewModel>> GetAllDevicesAsync()
    {
        var devices = await _deviceRepository.GetAll();

        return _mapper.Map<IEnumerable<DeviceViewModel>>(devices);
    }

    public async Task<DeviceViewModel> GetDeviceByIdAsync(int id)
    {
        var device = await _deviceRepository.GetById(id);

        return _mapper.Map<DeviceViewModel>(device);
    }

    public async Task<DeviceViewModel> UpdateDeviceAsync(DeviceDto dto, int id)
    {
        var updatedDevice = await _deviceRepository.GetById(id);

        if (updatedDevice == null)
            return null;

        switch (dto.Type)
        {
            case DeviceType.AccessPoint:
            case DeviceType.Firewall:
            case DeviceType.Printer:
            case DeviceType.Server:
            case DeviceType.Switch:
                if (dto.NetworkInfo is null)
                    throw new ArgumentException($"NetworkInfo is required for {dto.Type}.");
                break;

            case DeviceType.MobileChip:
                if (dto.ChipInfo is null)
                    throw new ArgumentException($"ChipInfo is required for MobileChip.");
                break;

            default:
                if (dto.NetworkInfo is not null || dto.ChipInfo is not null)
                    throw new ArgumentException("NetworkInfo and ChipInfo must be null for this device type.");
                break;
        }

        var manufacturer = await _manufacturerRepository.GetById(dto.ManufacturerId);
        if (manufacturer == null)
            throw new Exception("Manufacturer not found.");

        var model = await _modelRepository.GetById(dto.ModelId);
        if (model == null)
            throw new Exception("Model not found");

        _mapper.Map(dto, updatedDevice);

        await _deviceRepository.Update(updatedDevice);

        return _mapper.Map<DeviceViewModel>(updatedDevice);
    }

    public async Task<bool> DeleteDeviceAsync(int id)
    {
        var deletedDevice = await _deviceRepository.GetById(id);

        if (deletedDevice == null)
            return false;

        await _deviceRepository.Delete(deletedDevice);

        return true;
    }
}