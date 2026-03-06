using System.ComponentModel.DataAnnotations;
using api.Services.Interfaces;
using efscaffold.Entities;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.EntityFrameworkCore;
using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Implementations;

// Save Telemetry, Query Telemetry for Graphs, Notify SSE Clients
public class TelemetryService(MyDbContext ctx) : ITelemetryService
{
    public Task<List<TelemetryDto>> GetAllTelemetries()
    {
        return ctx.Telemetries.Select(t => new TelemetryDto(t)).ToListAsync();
    }
    
    public async Task<TelemetryDto> GetTelemetryByTurbineId(string id)
    {
        var telemetry = await ctx.Telemetries.Include(t => t.Turbine).FirstAsync(t => t.Turbine.Id == id);
        return new TelemetryDto(telemetry);
    }

    public async Task<TelemetryDto> CreateTelemetry(CreateTelemetryRequestDto dto)
    {
        var telemetry = new Telemetry()
        {
            Id = Guid.NewGuid().ToString(),
            TurbineId = dto.TurbineId,
            FarmId = dto.FarmId,
            Timestamp = DateTime.UtcNow,
            WindSpeed = dto.WindSpeed,
            WindDirection = dto.WindDirection,
            AmbientTemperature = dto.AmbientTemperature,
            RotorSpeed = dto.RotorSpeed,
            PowerOutput = dto.PowerOutput,
            NacelleDirection = dto.NacelleDirection,
            BladePitch = dto.BladePitch,
            GeneratorTemp = dto.GeneratorTemp,
            GearboxTemp = dto.GearboxTemp,
            Vibration = dto.Vibration,
            Status = dto.Status
        };
        ctx.Telemetries.Add(telemetry);
        await ctx.SaveChangesAsync();
        return new TelemetryDto(telemetry);
        
    }

    public async Task<TelemetryDto> UpdateTelemetry(UpdateTelemetryRequestDto dto)
    {
        Validator.ValidateObject(dto, new ValidationContext(dto)); 
        var telemetry = ctx.Telemetries.First(t => t.Id == dto.TelemetryId);
        telemetry.TurbineId = dto.TurbineId;
        telemetry.FarmId = dto.FarmId;
        telemetry.WindSpeed = dto.WindSpeed;
        telemetry.WindDirection = dto.WindDirection;
        telemetry.AmbientTemperature = dto.AmbientTemperature;
        telemetry.RotorSpeed = dto.RotorSpeed;
        telemetry.PowerOutput = dto.PowerOutput;
        telemetry.NacelleDirection = dto.NacelleDirection;
        telemetry.BladePitch = dto.BladePitch;
        telemetry.GeneratorTemp = dto.GeneratorTemp;
        telemetry.GearboxTemp = dto.GearboxTemp;
        telemetry.Vibration = dto.Vibration;
        telemetry.Status = dto.Status;
        
        await ctx.SaveChangesAsync();
        return new TelemetryDto(telemetry);
    }

    public async Task<TelemetryDto> DeleteTelemetry(string id)
    {
        var telemetry = await ctx.Telemetries.FirstAsync(t => t.Id == id);
        ctx.Telemetries.Remove(telemetry);
        await ctx.SaveChangesAsync();
        return new TelemetryDto(telemetry);
    }
}