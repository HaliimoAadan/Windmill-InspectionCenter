using api.Services.Interfaces;
using Infrastructure.Postgres.Scaffolding;
using server.Dtos;
using server.Dtos.Requests;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Implementations;

// Validate Commands, Save Commands, Publish to MQTT
public class CommandService(MyDbContext ctx) : ICommandService
{
    public Task<List<CommandDto>> GetAllCommands()
    {
        return ctx.Commands.Select(c => new CommandDto(c)).ToListAsync();
    }

    public Task<CommandDto> CreateCommand(CreateCommandRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<CommandDto> UpdateCommand(UpdateCommandRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<CommandDto> DeleteCommand(string id)
    {
        throw new NotImplementedException();
    }
}