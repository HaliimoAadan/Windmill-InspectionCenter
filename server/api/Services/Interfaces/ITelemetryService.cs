using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Interfaces;

public interface ITelemetryService
{
    Task<List<TelemetryDto>> GetAllTelemetries();
    Task<TelemetryDto> GetTelemetryByTurbineId(string id);
    Task<TelemetryDto> CreateTelemetry(CreateTelemetryRequestDto dto);
    Task<TelemetryDto> UpdateTelemetry(UpdateTelemetryRequestDto dto);
    Task<TelemetryDto> DeleteTelemetry(string id);
}

