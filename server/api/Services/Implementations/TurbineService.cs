using System.ComponentModel.DataAnnotations;
using api.Services.Interfaces;
using efscaffold.Entities;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.EntityFrameworkCore;
using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Implementations;

public class TurbineService(MyDbContext ctx) : ITurbineService
{
    public Task<List<TurbineDto>> GetAllTurbines()
    {
        return ctx.Turbines
            .Include(t => t.Farm)
            .Include(t => t.Alerts)
            .Include(t => t.Commands)
            .Include(t => t.Telemetries)
            .Select(t => new TurbineDto(t)).ToListAsync();
    }

    public async Task<TurbineDto> CreateTurbine(CreateTurbineRequestDto dto)
    {
        var turbine = new Turbine()
        {
            Id = Guid.NewGuid().ToString(),
            Name = dto.Name,
            FarmId = dto.FarmId,
        };
        ctx.Turbines.Add(turbine);
        await ctx.SaveChangesAsync();
        return new TurbineDto(turbine);
    }

    public async Task<TurbineDto> UpdateTurbine(UpdateTurbineRequestDto dto)
    {
        Validator.ValidateObject(dto, new ValidationContext(dto)); 
        var turbine = await ctx.Turbines.FirstAsync(t => t.Id == dto.TurbineId);
        turbine.Name = dto.Name;
        turbine.FarmId = dto.FarmId;
        turbine.Alerts = dto.AlertsIds.Select(id => ctx.Alerts.First(a => a.Id == id)).ToList();
        turbine.Commands = dto.CommandsIds.Select(id => ctx.Commands.First(c => c.Id == id)).ToList();
        turbine.Telemetries = dto.TelemetriesIds.Select(id => ctx.Telemetries.First(t => t.Id == id)).ToList();
        await ctx.SaveChangesAsync();
        return new TurbineDto(turbine);
    }

    public async Task<TurbineDto> DeleteTurbine(string id)
    {
        var turbine = await ctx.Turbines
            .Include(t => t.Alerts)
            .Include(t => t.Commands)
            .Include(t => t.Telemetries)
            .FirstAsync(t => t.Id == id);
        ctx.Turbines.Remove(turbine);
        await ctx.SaveChangesAsync();
        return new TurbineDto(turbine);
    }
}