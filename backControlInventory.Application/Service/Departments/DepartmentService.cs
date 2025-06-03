
using AutoMapper;
using backControlInventory.Domain.Model;
using backControlInventory.Infrastructure.Repository.Buildings;
using backControlInventory.Infrastructure.Repository.Departments;

namespace backControlInventory.Application.Service.Departments;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IBuildingRepository _buildingRepository;
    private readonly IMapper _mapper;

    public DepartmentService(IDepartmentRepository departmentRepository, IBuildingRepository buildingRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _buildingRepository = buildingRepository;
        _mapper = mapper;
    }

    public async Task<DepartmentViewModel> CreateDepartmentAsync(DepartmentDto dto)
    {
        var building = await _buildingRepository.GetById(dto.BuildingId);

        if (building == null)
            throw new Exception("Building not found.");

        var createdDepartment = _mapper.Map<Department>(dto);

        await _departmentRepository.Add(createdDepartment);

        return _mapper.Map<DepartmentViewModel>(createdDepartment);
    }

    public async Task<IEnumerable<DepartmentViewModel>> GetAllDepartmentsAsync()
    {
        var departments = await _departmentRepository.GetAll();

        return _mapper.Map<IEnumerable<DepartmentViewModel>>(departments);
    }

    public async Task<DepartmentViewModel> GetDepartmentByIdAsync(int id)
    {
        var department = await _departmentRepository.GetById(id);

        return _mapper.Map<DepartmentViewModel>(department);
    }

    public async Task<DepartmentViewModel> UpdateDepartmentAsync(DepartmentDto dto, int id)
    {
        var building = await _buildingRepository.GetById(dto.BuildingId);

        if (building == null)
            throw new Exception("Building not found.");

        var updatedDepartment = await _departmentRepository.GetById(id);

        if (updatedDepartment == null)
            return null;

        _mapper.Map(dto, updatedDepartment);

        await _departmentRepository.Update(updatedDepartment);

        return _mapper.Map<DepartmentViewModel>(updatedDepartment);
    }

    public async Task<bool> DeleteDepartmentAsync(int id)
    {
        var deletedDepartment = await _departmentRepository.GetById(id);

        if (deletedDepartment == null)
            return false;

        await _departmentRepository.Delete(deletedDepartment);

        return true;
    }
}