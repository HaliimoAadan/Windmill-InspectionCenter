using System;
using System.Collections.Generic;

namespace efscaffold.Entities;

public partial class Operator
{
    public string Id { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public virtual ICollection<Command> Commands { get; set; } = new List<Command>();
}
