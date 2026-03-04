using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Interfaces;

public interface IFarmService
{
    Task<List<FarmDto>> GetAllFarms();
    Task<FarmDto> CreateFarm(CreateFarmRequestDto dto);
    Task<FarmDto> UpdateFarm(UpdateFarmRequestDto dto);
    Task<FarmDto> DeleteFarm(string id);
}
