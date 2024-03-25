using System;
using System.Collections.Generic;

namespace GameSpy.Models;

public partial class Game
{
    public int Gameid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Image { get; set; }

    public decimal Rating { get; set; }

    public string Manufacturer { get; set; } = null!;

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual ICollection<Pc> Pcs { get; set; } = new List<Pc>();

    public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
}
