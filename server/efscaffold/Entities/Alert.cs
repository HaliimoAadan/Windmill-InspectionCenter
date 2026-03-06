using System;
using System.Collections.Generic;

namespace efscaffold.Entities;

public partial class Alert
{
    public string Id { get; set; } = null!;

    public string TurbineId { get; set; } = null!;

    public DateTime Timestamp { get; set; }

    public string? Severity { get; set; }

    public string Message { get; set; } = null!;

    public virtual Turbine Turbine { get; set; } = null!;
}
