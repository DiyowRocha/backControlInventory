
using AutoMapper;
using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Repository.Manufacturers;

namespace backControlInventory.Application.Service.Manufacturers;

public class ManufacturerService : IManufacturerService
{
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IMapper _mapper;

    public ManufacturerService(IManufacturerRepository manufacturerRepository, IMapper mapper)
    {
        _manufacturerRepository = manufacturerRepository;
        _mapper = mapper;
    }

    public async Task<ManufacturerViewModel> CreateManufacturerAsync(ManufacturerDto dto)
    {
        var createdManufacturer = _mapper.Map<Manufacturer>(dto);

        await _manufacturerRepository.Add(createdManufacturer);

        return _mapper.Map<ManufacturerViewModel>(createdManufacturer);
    }

    public async Task<IEnumerable<ManufacturerViewModel>> GetAllManufacturersAsync()
    {
        var manufacturers = await _manufacturerRepository.GetAll();

        return _mapper.Map<IEnumerable<ManufacturerViewModel>>(manufacturers);
    }

    public async Task<ManufacturerViewModel> GetManufacturerById(int id)
    {
        var manufacturer = await _manufacturerRepository.GetById(id);

        return _mapper.Map<ManufacturerViewModel>(manufacturer);
    }

    public async Task<ManufacturerViewModel> UpdateManufacturerAsync(ManufacturerDto dto, int id)
    {
        var updatedManufacturer = await _manufacturerRepository.GetById(id);

        if (updatedManufacturer == null)
            return null;

        _mapper.Map(dto, updatedManufacturer);

        await _manufacturerRepository.Update(updatedManufacturer);

        return _mapper.Map<ManufacturerViewModel>(updatedManufacturer);
    }

    public async Task<bool> DeleteManufacturerAsync(int id)
    {
        var deletedManufacturer = await _manufacturerRepository.GetById(id);

        if (deletedManufacturer == null)
            return false;

        await _manufacturerRepository.Delete(deletedManufacturer);

        return true;
    }
}