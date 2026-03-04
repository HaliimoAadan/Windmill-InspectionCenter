using System.ComponentModel.DataAnnotations;
using api.Services.Interfaces;
using efscaffold.Entities;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.EntityFrameworkCore;
using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Implementations;

public class FarmService(MyDbContext ctx) : IFarmService
{
    public Task<List<FarmDto>> GetAllFarms()
    {
        return ctx.Farms.Select(f => new FarmDto(f)).ToListAsync();
    }

    public async Task<FarmDto> CreateFarm(CreateFarmRequestDto dto)
    {
        var farm = new Farm()
        {
            Id = Guid.NewGuid().ToString(),
            Name = dto.Name
        };
        ctx.Farms.Add(farm);
        await ctx.SaveChangesAsync();
        return new FarmDto(farm);
    }

    public async Task<FarmDto> UpdateFarm(UpdateFarmRequestDto dto)
    {
        Validator.ValidateObject(dto, new ValidationContext(dto));
        var farm =  await ctx.Farms.FirstAsync(f => f.Id == dto.FarmId);
        farm.Name = dto.Name;
        farm.Turbines = dto.TurbinesIds.Select(id => ctx.Turbines.First(t => t.Id == id)).ToList();
        await ctx.SaveChangesAsync();
        return new FarmDto(farm);
    }

    public async Task<FarmDto> DeleteFarm(string id)
    {
        var farm = await ctx.Farms.FirstAsync(f => f.Id == id);
        ctx.Farms.Remove(farm);
        await ctx.SaveChangesAsync();
        return new FarmDto(farm);
    }
}