using efscaffold.Entities;

namespace server.Dtos;

public class OperatorDto
{

    public OperatorDto(Operator op)
    {
        Id = op.Id;
        Username = op.Username;
        Email = op.Email;
        PasswordHash = op.PasswordHash;
        CommandsIds = op.Commands.Select(c => c.Id).ToList();
    }
    
    public string Id { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public List<string> CommandsIds { get; set; } = new List<string>();
}