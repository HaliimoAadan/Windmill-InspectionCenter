using System.ComponentModel.DataAnnotations;

namespace server.Dtos.Requests;

public record CreateFarmRequestDto
{
    [MinLength(1)]
    public string Name { get; set; }
}

public record UpdateFarmRequestDto
{
    [Required] [MinLength(1)]
    public string FarmId { get; set; }
    [MinLength(1)]
    public string Name { get; set; }  
    [MinLength(1)]
    public List<string> TurbinesIds { get; set; }
}