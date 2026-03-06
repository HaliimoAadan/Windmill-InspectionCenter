using System.ComponentModel.DataAnnotations;
using api.Services.Interfaces;
using efscaffold.Entities;
using Infrastructure.Postgres.Scaffolding;
using Microsoft.EntityFrameworkCore;
using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Implementations;

// Save Alerts, Query Alerts, Push Alerts via SSE
public class AlertService(MyDbContext ctx) : IAlertService
{
 public Task<List<AlertDto>> GetAllAlerts()
 {
  return ctx.Alerts.Select(a => new AlertDto(a)).ToListAsync();

 }

 public async Task<AlertDto> CreateAlert(CreateAlertRequestDto dto)
 {
  var alert = new Alert()
  {
   Id = Guid.NewGuid().ToString(),
   Message = dto.Message,
   Severity = dto.Severity,
   Timestamp = DateTime.UtcNow,
   TurbineId = dto.TurbineId,
   Turbine = ctx.Turbines.FirstOrDefault(t => t.Id == dto.TurbineId)
  };
  ctx.Alerts.Add(alert);
  await ctx.SaveChangesAsync();
  return new AlertDto(alert);
 }

 public async Task<AlertDto> UpdateAlert(UpdateAlertRequestDto dto)
 { 
  Validator.ValidateObject(dto, new ValidationContext(dto)); 
  var alert = await ctx.Alerts.FirstAsync(a => a.Id == dto.AlertId); 
  alert.Severity = dto.Severity; 
  alert.Message = dto.Message;
  await ctx.SaveChangesAsync();
  return new AlertDto(alert);
 }

 public async Task<AlertDto> DeleteAlert(string id)
 {
  var alert = await ctx.Alerts.FirstAsync(a => a.Id == id);
  ctx.Alerts.Remove(alert);
  await ctx.SaveChangesAsync();
  return new AlertDto(alert);
 }
}