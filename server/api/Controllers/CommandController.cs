using api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using server.Dtos;
using server.Dtos.Requests;

namespace server.Controllers;

// POST /api/command, Validates & sends commands
[ApiController]
[Route("api/[controller]")]
public class CommandController(ICommandService commandService) : ControllerBase
{
    [Route(nameof(GetAllCommands))]
    [HttpGet]
    public async Task<ActionResult<List<CommandDto>>> GetAllCommands()
    {
        return await commandService.GetAllCommands();
    }
    
    [Route(nameof(CreateCommand))]
    [HttpPost]
    public async Task<ActionResult<CommandDto>> CreateCommand([FromBody]CreateCommandRequestDto dto)
    {
        return await commandService.CreateCommand(dto);
    }
    
    [Route(nameof(UpdateCommand))]
    [HttpPut]
    public async Task<ActionResult<CommandDto>> UpdateCommand([FromBody]UpdateCommandRequestDto dto)
    {
        return await commandService.UpdateCommand(dto);
    }
    
    [Route(nameof(DeleteCommand))]
    [HttpDelete("{id}")]
    public async Task<ActionResult<CommandDto>> DeleteCommand([FromQuery] string id)
    {
        return await commandService.DeleteCommand(id);
    }
}