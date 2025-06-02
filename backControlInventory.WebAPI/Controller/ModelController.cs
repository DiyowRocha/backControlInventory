using backControlInventory.Application.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace backControlInventory.WebAPI.Controller;

[ApiController]
[Route("api/[controller]")]
public class ModelController : ControllerBase
{
    private readonly IModelService _modelService;

    public ModelController(IModelService modelService)
    {
        _modelService = modelService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateModelAsync([FromBody] ModelDto dto)
    {
        var createdModel = await _modelService.CreateModelAsync(dto);

        return Created("api/Model", createdModel);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllModelsAsync()
    {
        var models = await _modelService.GetAllModelsAsync();

        if (!models.Any())
            return NotFound("Models not found.");

        return Ok(models);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetModelByIdAsync([FromRoute] int id)
    {
        var model = await _modelService.GetModelByIdAsync(id);

        if (model == null)
            return NotFound("Model not found.");

        return Ok(model);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateModelAsync([FromBody] ModelDto dto, [FromRoute] int id)
    {
        var updatedModel = await _modelService.UpdateModelAsync(dto, id);

        if (updatedModel == null)
            return NotFound("Model not found.");

        return Ok(updatedModel);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteModelAsync([FromRoute] int id)
    {
        var deletedModel = await _modelService.DeleteModelAsync(id);

        if (!deletedModel)
            return NotFound("Model not found.");

        return Ok("Model deleted.");
    }
}