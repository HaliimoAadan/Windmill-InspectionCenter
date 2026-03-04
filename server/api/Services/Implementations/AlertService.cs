using api.Services.Interfaces;
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

 public Task<AlertDto> CreateAlert(CreateAlertRequestDto dto)
 {
  throw new NotImplementedException();
 }

 public Task<AlertDto> UpdateAlert(UpdateAlertRequestDto dto)
 {
  throw new NotImplementedException();
 }

 public Task<AlertDto> DeleteAlert(string id)
 {
  throw new NotImplementedException();
 }
}