using api.Services.Interfaces;
using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Implementations;

public class TurbineService : ITurbineService
{
    public Task<List<TurbineDto>> GetAllTurbines()
    {
        throw new NotImplementedException();
    }

    public Task<TurbineDto> CreateTurbine(CreateTurbineRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<TurbineDto> UpdateTurbine(UpdateTurbineRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<TurbineDto> DeleteTurbine(string id)
    {
        throw new NotImplementedException();
    }
}