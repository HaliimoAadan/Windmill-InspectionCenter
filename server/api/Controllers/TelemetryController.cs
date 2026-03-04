using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Dtos.Requests;

namespace api.Controllers;

// GET /api/telemetry?turbineId=..., Used for historical graphs
[ApiController]
[Route("api/[controller]")]
public class TelemetryController(ITelemetryService telemetryService) : ControllerBase
{
    [Route(nameof(GetAllTelemetries))]
    [HttpGet]
    public async Task<ActionResult<List<TelemetryDto>>> GetAllTelemetries()
    {
        return await telemetryService.GetAllTelemetries();
    }

    [Route("/telemetry/turbineId={turbineId}")]
    [HttpGet]
    public async Task<ActionResult<TelemetryDto>> GetTelemetryByTurbineId(string turbineId)
    {
        return await telemetryService.GetTelemetryByTurbineId(turbineId);
    }
    
    [Route(nameof(CreateTelemetry))]
    [HttpPost]
    public async Task<ActionResult<TelemetryDto>> CreateTelemetry([FromBody]CreateTelemetryRequestDto dto)
    {
        return await telemetryService.CreateTelemetry(dto);
    }
    
    [Route(nameof(UpdateTelemetry))]
    [HttpPut]
    public async Task<ActionResult<TelemetryDto>> UpdateTelemetry([FromBody]UpdateTelemetryRequestDto dto)
    {
        return await telemetryService.UpdateTelemetry(dto);
    }
    
    [Route(nameof(DeleteTelemetry))]
    [HttpDelete("{id}")]
    public async Task<ActionResult<TelemetryDto>> DeleteTelemetry([FromQuery] string id)
    {
        return await telemetryService.DeleteTelemetry(id);
    }
}