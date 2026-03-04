using System.ComponentModel.DataAnnotations;

namespace server.Dtos.Requests;

public record CreateOperatorRequestDto
{
    [MinLength(1)]
    public string Username { get; set; }
    [MinLength(1)]
    public string Email { get; set; }
    [MinLength(1)]
    public string Password { get; set; }   
}

public record UpdateOperatorRequestDto
{
    [Required] [MinLength(1)]
    public string OperatorId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }  
}