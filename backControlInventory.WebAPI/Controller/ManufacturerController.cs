using backControlInventory.Application.Service.Manufacturers;
using Microsoft.AspNetCore.Mvc;

namespace backControlInventory.WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class ManufacturerController : ControllerBase
{
    private readonly IManufacturerService _manufacturerService;

    public ManufacturerController(IManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateManufacturerAsync([FromBody] ManufacturerDto dto)
    {
        var createdManufacturer = await _manufacturerService.CreateManufacturerAsync(dto);

        return Created("api/Manufacturer", createdManufacturer);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllManufacturersAsync()
    {
        var manufacturers = await _manufacturerService.GetAllManufacturersAsync();

        if (manufacturers == null)
            return NotFound("Manufacturers not found.");

        return Ok(manufacturers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetManufacturerById([FromRoute] int id)
    {
        var manufacturer = await _manufacturerService.GetManufacturerById(id);

        if (manufacturer == null)
            return NotFound("Manufacturer not found");

        return Ok(manufacturer);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateManufacturerAsync([FromBody] ManufacturerDto dto, [FromRoute] int id)
    {
        var updatedManufacturer = await _manufacturerService.UpdateManufacturerAsync(dto, id);

        if (updatedManufacturer == null)
            return NotFound("Manufacturer not found.");

        return Ok(updatedManufacturer);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteManufacturerAsync([FromRoute] int id)
    {
        var deletedManufacturer = await _manufacturerService.DeleteManufacturerAsync(id);

        if (!deletedManufacturer)
            return NotFound("Manufacturer not found.");

        return Ok("Manufacturer deleted.");
    }
}