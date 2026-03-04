using System;
using System.Collections.Generic;

namespace efscaffold.Entities;

public partial class Telemetry
{
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

    public virtual Turbine Turbine { get; set; } = null!;
}
