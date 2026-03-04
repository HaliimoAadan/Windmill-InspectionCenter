using efscaffold.Entities;

namespace server.Dtos;

public class CommandDto
{
    public CommandDto(Command command)
    {
        Id = command.Id;
        TurbineId = command.Turbine.Id;
        OperatorId = command.Operator.Id;
        Timestamp = command.Timestamp;
        Action = command.Action; // "start", "stop", "setInterval", "setPitch"
        while(command.Action == "setInterval")
        {
            IntervalSeconds = command.IntervalSeconds;
        }

        if (command.Action == "setPitchAngle")
        {
            PitchAngle = command.PitchAngle;
        }

        if (command.Action == "stop")
        {
            Reason = command.Reason;
        }
    }
    
    public string Id { get; set; } = null!;

    public string TurbineId { get; set; } = null!;

    public string OperatorId { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public string Action { get; set; } = null!;

    public int? IntervalSeconds { get; set; }

    public float? PitchAngle { get; set; }

    public string? Reason { get; set; }
    
}