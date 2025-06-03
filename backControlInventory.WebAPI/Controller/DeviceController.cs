using backControlInventory.Application.Service.Devices;
using Microsoft.AspNetCore.Mvc;

namespace backControlInventory.WebAPI.Controller;

[ApiController]
[Route("/api[controller]")]
public class DeviceController : ControllerBase
{
    private readonly IDeviceService _deviceService;

    public DeviceController(IDeviceService deviceService)
    {
        _deviceService = deviceService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateDeviceAsync([FromBody] DeviceDto dto)
    {
        var createdDevice = await _deviceService.CreateDeviceAsync(dto);

        return Created("api/Device", createdDevice);
    }

    [HttpGet]
    public async Task<ActionResult> GetAllDevicesAsync()
    {
        var devices = await _deviceService.GetAllDevicesAsync();

        if (!devices.Any())
            return NotFound("Devices not found.");

        return Ok(devices);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetDeviceByIdAsync([FromRoute] int id)
    {
        var device = await _deviceService.GetDeviceByIdAsync(id);

        if (device == null)
            return NotFound("Device not found.");

        return Ok(device);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDeviceAsync([FromBody] DeviceDto dto, [FromRoute] int id)
    {
        var updatedDevice = await _deviceService.UpdateDeviceAsync(dto, id);

        if (updatedDevice == null)
            return NotFound("Device not found.");

        return Ok(updatedDevice);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDeviceAsync([FromRoute] int id)
    {
        var deletedDevice = await _deviceService.DeleteDeviceAsync(id);

        if (!deletedDevice)
            return NotFound("Device not found.");

        return Ok("Device deleted.");
    }
}