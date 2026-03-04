using System.ComponentModel.DataAnnotations;

namespace server.Dtos.Requests;

public record CreateCommandRequestDto
{
    [MinLength(1)]
    public string Action { get; set; }
}

public record UpdateCommandRequestDto
{
    [Required] [MinLength(1)]
    public string CommandId { get; set; }
    [MinLength(1)]
    public string Action { get; set; }
    public int? IntervalSeconds { get; set; }
    public float? PitchAngle { get; set; }
    public string? Reason { get; set; }
}