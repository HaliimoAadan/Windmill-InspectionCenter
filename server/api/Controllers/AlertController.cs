using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Dtos.Requests;

namespace api.Controllers;


// GET /api/alerts, List past alerts
[ApiController]
[Route("api/[controller]")]
public class AlertController (IAlertService alertService) : ControllerBase
{
    [Route(nameof(GetAllAlerts))]
    [HttpGet]
    public async Task<ActionResult<List<AlertDto>>> GetAllAlerts()
    {
        return await alertService.GetAllAlerts();
    }
    
    [Route(nameof(CreateAlert))]
    [HttpPost]
    public async Task<ActionResult<AlertDto>> CreateAlert([FromBody]CreateAlertRequestDto dto)
    {
        return await alertService.CreateAlert(dto);
    }
    
    [Route(nameof(UpdateAlert))]
    [HttpPut]
    public async Task<ActionResult<AlertDto>> UpdateAlert([FromBody]UpdateAlertRequestDto dto)
    {
        return await alertService.UpdateAlert(dto);
    }
    
    [Route(nameof(DeleteAlert))]
    [HttpDelete("{id}")]
    public async Task<ActionResult<AlertDto>> DeleteAlert([FromQuery] string id)
    {
        return await alertService.DeleteAlert(id);
    }
}