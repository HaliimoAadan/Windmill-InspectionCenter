using System.ComponentModel.DataAnnotations;
using api.Services.Interfaces;
using efscaffold.Entities;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.EntityFrameworkCore;
using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Implementations;

public class OperatorService(MyDbContext ctx) : IOperatorService
{
    public Task<List<OperatorDto>> GetAllOperators()
    {
        return ctx.Operators.Select(o => new OperatorDto(o)).ToListAsync();
    }

    public async Task<OperatorDto> CreateOperator(CreateOperatorRequestDto dto)
    {
        var op = new Operator()
        {
            Id = Guid.NewGuid().ToString(),
            Username = dto.Username,
            Email = dto.Email,
            // Hashing Service
            PasswordHash = dto.Password
        };
        ctx.Operators.Add(op);
        await ctx.SaveChangesAsync();
        return new OperatorDto(op);    }

    public async Task<OperatorDto> UpdateOperator(UpdateOperatorRequestDto dto)
    {
        Validator.ValidateObject(dto, new ValidationContext(dto));
        var op = await ctx.Operators.FirstAsync(o => o.Id == dto.OperatorId);
        op.Username = dto.Username;
        op.Email = dto.Email;
        // Hashing Service
        op.PasswordHash = dto.Password;
        await ctx.SaveChangesAsync();
        return new OperatorDto(op);
    }

    public async Task<OperatorDto> DeleteOperator(string id)
    {
        var op = await ctx.Operators.FirstAsync(o => o.Id == id);
        ctx.Operators.Remove(op);
        await ctx.SaveChangesAsync();
        return new OperatorDto(op);
    }
}