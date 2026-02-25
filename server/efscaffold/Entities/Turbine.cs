using System;
using System.Collections.Generic;

namespace efscaffold.Entities;

public partial class Turbine
{
    public string Id { get; set; } = null!;

    public string FarmId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();

    public virtual ICollection<Command> Commands { get; set; } = new List<Command>();

    public virtual Farm Farm { get; set; } = null!;

    public virtual ICollection<Telemetry> Telemetries { get; set; } = new List<Telemetry>();
}
