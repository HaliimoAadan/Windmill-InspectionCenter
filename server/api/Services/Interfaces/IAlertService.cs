using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Interfaces;

public interface IAlertService
{

    Task<List<AlertDto>> GetAllAlerts();
    Task<AlertDto> CreateAlert(CreateAlertRequestDto dto);
    Task<AlertDto> UpdateAlert(UpdateAlertRequestDto dto);
    Task<AlertDto> DeleteAlert(string id);
    
}