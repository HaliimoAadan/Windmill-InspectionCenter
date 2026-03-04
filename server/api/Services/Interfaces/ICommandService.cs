using server.Dtos;
using server.Dtos.Requests;

namespace api.Services.Interfaces;

public interface ICommandService
{
    Task<List<CommandDto>> GetAllCommands();
    Task<CommandDto> CreateCommand(CreateCommandRequestDto dto);
    Task<CommandDto> UpdateCommand(UpdateCommandRequestDto dto);
    Task<CommandDto> DeleteCommand(string id);
}
