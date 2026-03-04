using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Dtos.Requests;

namespace api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FarmController(IFarmService farmService) : ControllerBase
{
    [Route(nameof(GetAllFarms))]
    [HttpGet]
    public async Task<ActionResult<List<FarmDto>>> GetAllFarms()
    {
        return await farmService.GetAllFarms();
    }
    
    [Route(nameof(CreateFarm))]
    [HttpPost]
    public async Task<ActionResult<FarmDto>> CreateFarm([FromBody]CreateFarmRequestDto dto)
    {
        return await farmService.CreateFarm(dto);
    }
    
    [Route(nameof(UpdateFarm))]
    [HttpPut]
    public async Task<ActionResult<FarmDto>> UpdateFarm([FromBody]UpdateFarmRequestDto dto)
    {
        return await farmService.UpdateFarm(dto);
    }
    
    [Route(nameof(DeleteFarm))]
    [HttpDelete("{id}")]
    public async Task<ActionResult<FarmDto>> DeleteFarm([FromQuery] string id)
    {
        return await farmService.DeleteFarm(id);
    }
}