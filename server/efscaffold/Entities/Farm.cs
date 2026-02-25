using System;
using System.Collections.Generic;

namespace efscaffold.Entities;

public partial class Farm
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Turbine> Turbines { get; set; } = new List<Turbine>();
}
