namespace backControlInventory.Application.Service.Departments;

public interface IDepartmentService
{
    Task<DepartmentViewModel> CreateDepartmentAsync(DepartmentDto dto);
    Task<IEnumerable<DepartmentViewModel>> GetAllDepartmentsAsync();
    Task<DepartmentViewModel> GetDepartmentByIdAsync(int id);
    Task<DepartmentViewModel> UpdateDepartmentAsync(DepartmentDto dto, int id);
    Task<bool> DeleteDepartmentAsync(int id);
}