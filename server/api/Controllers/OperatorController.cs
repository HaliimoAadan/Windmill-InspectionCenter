using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Dtos.Requests;

namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OperatorController(IOperatorService operatorService) : ControllerBase
{
    [Route(nameof(GetAllOperators))]
    [HttpGet]
    public async Task<ActionResult<List<OperatorDto>>> GetAllOperators()
    {
        return await operatorService.GetAllOperators();
    }
    
    [Route(nameof(CreateOperator))]
    [HttpPost]
    public async Task<ActionResult<OperatorDto>> CreateOperator([FromBody]CreateOperatorRequestDto dto)
    {
        return await operatorService.CreateOperator(dto);
    }
    
    [Route(nameof(UpdateOperator))]
    [HttpPut]
    public async Task<ActionResult<OperatorDto>> UpdateOperator([FromBody]UpdateOperatorRequestDto dto)
    {
        return await operatorService.UpdateOperator(dto);
    }
    
    [Route(nameof(DeleteOperator))]
    [HttpDelete("{id}")]
    public async Task<ActionResult<OperatorDto>> DeleteOperator([FromQuery] string id)
    {
        return await operatorService.DeleteOperator(id);
    }
}