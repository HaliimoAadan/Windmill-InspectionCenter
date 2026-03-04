using efscaffold.Entities;

namespace server.Dtos;

public class AlertDto
{
    public AlertDto(Alert alert)
    {
        Id = alert.Id;
        TurbineId = alert.Turbine.Id;
        Timestamp = alert.Timestamp;
        Severity = alert.Severity; // "Info", "Warning", "Critical"
        Message = alert.Message;
    }
    
    public string Id { get; set; }

    public string TurbineId { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public string? Severity { get; set; }

    public string Message { get; set; } = null!;

}