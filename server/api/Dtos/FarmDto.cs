using efscaffold.Entities;

namespace server.Dtos;

public class FarmDto
{
    public FarmDto(Farm farm)
    {
        Id = farm.Id;
        Name = farm.Name;
        TurbinesIds = farm.Turbines.Select(t => t.Id).ToList();
    }
    
    public string Id { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<string> TurbinesIds { get; set; } = new List<string>();
}