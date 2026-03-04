using api.Services.Interfaces;
using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Implementations;

// Save Telemetry, Query Telemetry for Graphs, Notify SSE Clients
public class TelemetryService : ITelemetryService
{
    public Task<List<TelemetryDto>> GetAllTelemetries()
    {
        throw new NotImplementedException();
    }
    
    public Task<TelemetryDto> GetTelemetryByTurbineId(string id)
    {
        throw new NotImplementedException();
    }

    public Task<TelemetryDto> CreateTelemetry(CreateTelemetryRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<TelemetryDto> UpdateTelemetry(UpdateTelemetryRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<TelemetryDto> DeleteTelemetry(string id)
    {
        throw new NotImplementedException();
    }
}