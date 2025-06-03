using AutoMapper;
using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Repository.Buildings;
using backControlInventory.Infrastructure.Repository.Units;

namespace backControlInventory.Application.Service.Buildings;

public class BuildingService : IBuildingService
{
    private readonly IBuildingRepository _buildingRepository;
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;

    public BuildingService(IBuildingRepository buildingRepository, IUnitRepository unitRepository, IMapper mapper)
    {
        _buildingRepository = buildingRepository;
        _unitRepository = unitRepository;
        _mapper = mapper;
    }

    public async Task<BuildingViewModel> CreateBuildingAsync(BuildingDto dto)
    {
        var unit = await _unitRepository.GetById(dto.UnitId);

        if (unit == null)
            throw new Exception("Unit not found.");

        var createdBuilding = _mapper.Map<Building>(dto);

        await _buildingRepository.Add(createdBuilding);

        return _mapper.Map<BuildingViewModel>(createdBuilding);
    }

    public async Task<IEnumerable<BuildingViewModel>> GetAllBuildingsAsync()
    {
        var buildings = await _buildingRepository.GetAll();

        return _mapper.Map<IEnumerable<BuildingViewModel>>(buildings);
    }

    public async Task<BuildingViewModel> GetBuildingByIdAsync(int id)
    {
        var building = await _buildingRepository.GetById(id);

        return _mapper.Map<BuildingViewModel>(building);
    }

    public async Task<BuildingViewModel> UpdateBuildingAsync(BuildingDto dto, int id)
    {
        var unit = await _unitRepository.GetById(dto.UnitId);

        if (unit == null)
            throw new Exception("Unit not found.");

        var updatedBuilding = await _buildingRepository.GetById(id);

        if (updatedBuilding == null)
            return null;


        _mapper.Map(dto, updatedBuilding);

        await _buildingRepository.Update(updatedBuilding);

        return _mapper.Map<BuildingViewModel>(updatedBuilding);
    }

    public async Task<bool> DeleteBuildingAsync(int id)
    {
        var deletedBuilding = await _buildingRepository.GetById(id);

        if (deletedBuilding == null)
            return false;

        await _buildingRepository.Delete(deletedBuilding);

        return true;
    }
}