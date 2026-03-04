using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Interfaces;

public interface IOperatorService
{
    Task<List<OperatorDto>> GetAllOperators();
    Task<OperatorDto> CreateOperator(CreateOperatorRequestDto dto);
    Task<OperatorDto> UpdateOperator(UpdateOperatorRequestDto dto);
    Task<OperatorDto> DeleteOperator(string id);
}