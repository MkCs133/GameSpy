using System;
using System.Collections.Generic;

namespace GameSpy.Models;

public partial class Achievement
{
    public int Achievementsid { get; set; }

    public int Gameid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Game Game { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
