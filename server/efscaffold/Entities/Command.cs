using System;
using System.Collections.Generic;

namespace efscaffold.Entities;

public partial class Command
{
    public string Id { get; set; } = null!;

    public string TurbineId { get; set; } = null!;

    public string OperatorId { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public string Action { get; set; } = null!;

    public int? IntervalSeconds { get; set; }

    public float? PitchAngle { get; set; }

    public string? Reason { get; set; }

    public virtual Operator Operator { get; set; } = null!;

    public virtual Turbine Turbine { get; set; } = null!;
}
