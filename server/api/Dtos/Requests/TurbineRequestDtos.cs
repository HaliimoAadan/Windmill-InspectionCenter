using System.ComponentModel.DataAnnotations;

namespace server.Dtos.Requests;

public record CreateTurbineRequestDto
{
    [MinLength(1)]
    public string Name { get; set; }
    [Required] [MinLength(1)]
    public string FarmId { get; set; }  
}

public record UpdateTurbineRequestDto
{
    [Required] [MinLength(1)]
    public string TurbineId { get; set; }
    public string Name { get; set; } 
    public string FarmId { get; set; } 
    public List<string> AlertsIds { get; set; }
    public List<string> CommandsIds { get; set; }
    public List<string> TelemetriesIds { get; set; }
}