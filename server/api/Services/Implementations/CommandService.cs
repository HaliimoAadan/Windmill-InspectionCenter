using System.ComponentModel.DataAnnotations;
using api.Services.Interfaces;
using efscaffold.Entities;
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

    public async Task<CommandDto> CreateCommand(CreateCommandRequestDto dto)
    {
        var command = new Command()
        {
            Id = Guid.NewGuid().ToString(),
            TurbineId = dto.TurbineId,
            Timestamp = DateTime.UtcNow,
            Action = dto.Action, // "start", "stop", "setInterval", "setPitch""
            IntervalSeconds = dto.IntervalSeconds, // Only for "setInterval"
            PitchAngle = dto.PitchAngle, // Only for "setPitchAngle"
            Reason = dto.Reason // Only for "stop"
        };
        ctx.Commands.Add(command);
        await ctx.SaveChangesAsync();
        return new CommandDto(command);

    }

    public async Task<CommandDto> UpdateCommand(UpdateCommandRequestDto dto)
    {
        Validator.ValidateObject(dto, new ValidationContext(dto)); 
        var command = await ctx.Commands.FirstAsync(c => c.Id == dto.CommandId);
        command.Action = dto.Action; // "start", "stop", "setInterval", "setPitch"""
        command.IntervalSeconds = dto.IntervalSeconds; // Only for "setInterval"
        command.PitchAngle = dto.PitchAngle; // Only for "setPitchAngle"
        command.Reason = dto.Reason; // Only for "stop"
        await ctx.SaveChangesAsync();
        return new CommandDto(command);

    }
    
    public async Task<CommandDto> DeleteCommand(string id)
    {
        var command = await ctx.Commands.FirstAsync(c => c.Id == id);
        ctx.Commands.Remove(command);
        await ctx.SaveChangesAsync();
        return new CommandDto(command);
    }
}