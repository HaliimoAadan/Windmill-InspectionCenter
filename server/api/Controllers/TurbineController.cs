using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Dtos.Requests;

namespace api.Controllers;

// GET api/turbines
[ApiController]
[Route("api/[controller]")]
public class TurbineController(ITurbineService turbineService) : ControllerBase
{
    [Route(nameof(GetAllTurbines))]
    [HttpGet]
    public async Task<ActionResult<List<TurbineDto>>> GetAllTurbines()
    {
        return await turbineService.GetAllTurbines();
    }
    
    [Route(nameof(CreateTurbine))]
    [HttpPost]
    public async Task<ActionResult<TurbineDto>> CreateTurbine([FromBody]CreateTurbineRequestDto dto)
    {
        return await turbineService.CreateTurbine(dto);
    }
    
    [Route(nameof(UpdateTurbine))]
    [HttpPut]
    public async Task<ActionResult<TurbineDto>> UpdateTurbine([FromBody]UpdateTurbineRequestDto dto)
    {
        return await turbineService.UpdateTurbine(dto);
    }
    
    [Route(nameof(DeleteTurbine))]
    [HttpDelete("{id}")]
    public async Task<ActionResult<TurbineDto>> DeleteTurbine([FromQuery] string id)
    {
        return await turbineService.DeleteTurbine(id);
    }
}