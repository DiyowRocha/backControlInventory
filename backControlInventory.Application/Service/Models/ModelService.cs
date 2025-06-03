using AutoMapper;
using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Models;
using backControlInventory.Infrastructure.Repository.Manufacturers;

namespace backControlInventory.Application.Service.Models;

public class ModelService : IModelService
{
    private readonly IModelRepository _modelRepository;
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IMapper _mapper;

    public ModelService(IModelRepository modelRepository, IManufacturerRepository manufacturerRepository, IMapper mapper)
    {
        _modelRepository = modelRepository;
        _manufacturerRepository = manufacturerRepository;
        _mapper = mapper;
    }

    public async Task<ModelViewModel> CreateModelAsync(ModelDto dto)
    {
        var manufacturer = await _manufacturerRepository.GetById(dto.ManufacturerId);

        if (manufacturer == null)
            throw new Exception("Manufacturer not found.");

        var createdModel = _mapper.Map<Model>(dto);

        await _modelRepository.Add(createdModel);

        return _mapper.Map<ModelViewModel>(createdModel);
    }

    public async Task<IEnumerable<ModelViewModel>> GetAllModelsAsync()
    {
        var models = await _modelRepository.GetAll();

        return _mapper.Map<IEnumerable<ModelViewModel>>(models);
    }

    public async Task<ModelViewModel> GetModelByIdAsync(int id)
    {
        var model = await _modelRepository.GetById(id);

        return _mapper.Map<ModelViewModel>(model);
    }

    public async Task<ModelViewModel> UpdateModelAsync(ModelDto dto, int id)
    {
        var manufacturer = await _manufacturerRepository.GetById(dto.ManufacturerId);

        if (manufacturer == null)
            throw new Exception("Manufacturer not found.");

        var updatedModel = await _modelRepository.GetById(id);

        if (updatedModel == null)
            return null;

        if (id != updatedModel.Id)
            throw new Exception("Route Id and body Id do not match.");

        _mapper.Map(dto, updatedModel);

        await _modelRepository.Update(updatedModel);

        return _mapper.Map<ModelViewModel>(updatedModel);
    }

    public async Task<bool> DeleteModelAsync(int id)
    {
        var deletedModel = await _modelRepository.GetById(id);

        if (deletedModel == null)
            return false;

        await _modelRepository.Delete(deletedModel);

        return true;
    }
}