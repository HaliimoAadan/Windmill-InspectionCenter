using efscaffold.Entities;

namespace server.Dtos;

public class TurbineDto
{

    public TurbineDto(Turbine turbine)
    {
        Id = turbine.Id;
        FarmId = turbine.FarmId;
        Name = turbine.Name;
        AlertsIds = turbine.Alerts.Select(a => a.Id).ToList();
        CommandsIds = turbine.Commands.Select(c => c.Id).ToList();
        TelemetriesIds = turbine.Telemetries.Select(t => t.Id).ToList();
    }
    
    public string Id { get; set; } = null!;
    public string FarmId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public List<string> AlertsIds { get; set; } = new List<string>();
    public List<string> CommandsIds { get; set; } = new List<string>();
    public List<string> TelemetriesIds { get; set; } = new List<string>();

}