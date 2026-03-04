using efscaffold.Entities;

namespace server.Dtos;

public class TelemetryDto
{
    public TelemetryDto(Telemetry telemetry)
    {
        Id = telemetry.Id;
        TurbineId = telemetry.Turbine.Id;
        Timestamp = telemetry.Timestamp;
        WindSpeed = telemetry.WindSpeed;
        WindDirection = telemetry.WindDirection;
        AmbientTemperature = telemetry.AmbientTemperature;
        RotorSpeed = telemetry.RotorSpeed;
        PowerOutput = telemetry.PowerOutput;
        NacelleDirection = telemetry.NacelleDirection;
        BladePitch = telemetry.BladePitch;
        GeneratorTemp = telemetry.GeneratorTemp;
        GearboxTemp = telemetry.GearboxTemp;
        Vibration = telemetry.Vibration;
        Status = telemetry.Status; // "running" or "stopped"
    }
    
    public string Id { get; set; } = null!;

    public string TurbineId { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public float? WindSpeed { get; set; }

    public float? WindDirection { get; set; }

    public float? AmbientTemperature { get; set; }

    public float? RotorSpeed { get; set; }

    public float? PowerOutput { get; set; }

    public float? NacelleDirection { get; set; }

    public float? BladePitch { get; set; }

    public float? GeneratorTemp { get; set; }

    public float? GearboxTemp { get; set; }

    public float? Vibration { get; set; }

    public string? Status { get; set; }
}