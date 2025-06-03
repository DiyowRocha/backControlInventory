using backControlInventory.Application.Service.Departments;
using Microsoft.AspNetCore.Mvc;

namespace backControlInventory.WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _deparmentService;

    public DepartmentController(IDepartmentService departmentService)
    {
        _deparmentService = departmentService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateDepartmentAsync([FromBody] DepartmentDto dto)
    {
        var createdDepartment = await _deparmentService.CreateDepartmentAsync(dto);

        return Created("api/Department", createdDepartment);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllDepartmentsAsync()
    {
        var departments = await _deparmentService.GetAllDepartmentsAsync();

        if (!departments.Any())
            return NotFound("Departments not found");

        return Ok(departments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetDepartmentById([FromRoute] int id)
    {
        var department = await _deparmentService.GetDepartmentByIdAsync(id);

        if (department == null)
            return NotFound("Department not found.");

        return Ok(department);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDepartmentAsync([FromBody] DepartmentDto dto, [FromRoute] int id)
    {
        var updatedDepartment = await _deparmentService.UpdateDepartmentAsync(dto, id);

        if (updatedDepartment == null)
            return NotFound("Department not found.");

        return Ok(updatedDepartment);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDepartmentAsync([FromRoute] int id)
    {
        var deletedDepartment = await _deparmentService.DeleteDepartmentAsync(id);

        if (!deletedDepartment)
            return NotFound("Department not found.");

        return Ok("Department deleted.");
    }
}