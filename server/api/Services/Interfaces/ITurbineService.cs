using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Interfaces;

public interface ITurbineService
{
    Task<List<TurbineDto>> GetAllTurbines();
    Task<TurbineDto> CreateTurbine(CreateTurbineRequestDto dto);
    Task<TurbineDto> UpdateTurbine(UpdateTurbineRequestDto dto);
    Task<TurbineDto> DeleteTurbine(string id);
}