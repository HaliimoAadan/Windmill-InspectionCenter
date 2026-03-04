using System.ComponentModel.DataAnnotations;

namespace server.Dtos.Requests;

public record CreateAlertRequestDto
{
    [MinLength(1)]
    public string Severity { get; set; }
    [MinLength(1)]
    public string Message { get; set; }
}

public record UpdateAlertRequestDto
{
    [Required] [MinLength(1)]
    public string AlertId { get; set; }
    [MinLength(1)]
    public string Severity { get; set; }
    [MinLength(1)]
    public string Message { get; set; }
}