using backControlInventory.Application.Service.Buildings;
using Microsoft.AspNetCore.Mvc;

namespace backControlInventory.WebAPI.Controller;

[ApiController]
[Route("/api[controller]")]
public class BuildingController : ControllerBase
{
    private readonly IBuildingService _buildingService;

    public BuildingController(IBuildingService buildingService)
    {
        _buildingService = buildingService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateBuildingAsync([FromBody] BuildingDto dto)
    {
        var createdBuilding = await _buildingService.CreateBuildingAsync(dto);

        return Created("api/Building", createdBuilding);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllBuildingsAsync()
    {
        var buildings = await _buildingService.GetAllBuildingsAsync();

        if (!buildings.Any())
            return NotFound("Buildings not found.");

        return Ok(buildings);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetBuildingByIdAsync([FromRoute] int id)
    {
        var building = await _buildingService.GetBuildingByIdAsync(id);

        if (building == null)
            return NotFound("Building not found.");

        return Ok(building);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBuildingAsync([FromBody] BuildingDto dto, [FromRoute] int id)
    {
        var updatedBuilding = await _buildingService.UpdateBuildingAsync(dto, id);

        if (updatedBuilding == null)
            return NotFound("Building not found.");

        return Ok(updatedBuilding);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBuildingAsync([FromRoute] int id)
    {
        var deletedBuilding = await _buildingService.DeleteBuildingAsync(id);

        if (!deletedBuilding)
            return NotFound("Building not found.");

        return Ok("Building deleted.");
    }
}