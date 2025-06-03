using backControlInventory.Application.Service.Units;
using Microsoft.AspNetCore.Mvc;

namespace backControlInventory.WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class UnitController : ControllerBase
{
    private readonly IUnitService _unitService;

    public UnitController(IUnitService unitService)
    {
        _unitService = unitService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateUnitAsync([FromBody] UnitDto dto)
    {
        var createdUnit = await _unitService.CreateUnitAsync(dto);

        return Created("api/Unit/", createdUnit);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllUnitsAsync()
    {
        var units = await _unitService.GetAllUnitsAsync();

        if (!units.Any())
            return NotFound("Units not found.");

        return Ok(units);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetUnitByIdAsync([FromRoute] int id)
    {
        var unit = await _unitService.GetUnitByIdAsync(id);

        if (unit == null)
            return NotFound("Unit not found.");

        return Ok(unit);
    }

    [HttpGet("buildings/{id}")]
    public async Task<ActionResult> GetUnitWithBuildingsByIdAsync([FromRoute] int id)
    {
        var unit = await _unitService.GetUnitWithBuildingsByIdAsync(id);

        if (unit == null)
            return NotFound("Unit not found.");

        return Ok(unit);
    }

    [HttpGet("zipcode/{zipcode}")]
    public async Task<ActionResult> GetUnitByZipCodeAsync([FromRoute] string zipcode)
    {
        var unit = await _unitService.GetUnitByZipCodeAsync(zipcode);

        if (unit == null)
            return NotFound("Unit not found.");

        return Ok(unit);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUnitAsync([FromBody] UnitDto dto, [FromRoute] int id)
    {
        var updatedUnit = await _unitService.UpdateUnitAsync(dto, id);

        if (updatedUnit == null)
            return NotFound("Unit not found.");

        return Ok(updatedUnit);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUnitAsync(int id)
    {
        var deletedUnit = await _unitService.DeleteUnitAsync(id);

        if (!deletedUnit)
            return NotFound("Unit not found");

        return Ok("Unit deleted");
    }
}