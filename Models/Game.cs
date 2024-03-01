using System;
using System.Collections.Generic;

namespace GameSpy.Models;

public partial class Game
{
    public int Gameid { get; set; }

    public int? Userid { get; set; }

    public int? Pcid { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Rating { get; set; }

    public string Manufacturer { get; set; } = null!;

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual Pc? Pc { get; set; }

    public virtual User? User { get; set; }
}
