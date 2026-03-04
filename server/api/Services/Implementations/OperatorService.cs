using api.Services.Interfaces;
using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Implementations;

public class OperatorService : IOperatorService
{
    public Task<List<OperatorDto>> GetAllOperators()
    {
        throw new NotImplementedException();
    }

    public Task<OperatorDto> CreateOperator(CreateOperatorRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<OperatorDto> UpdateOperator(UpdateOperatorRequestDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<OperatorDto> DeleteOperator(string id)
    {
        throw new NotImplementedException();
    }
}