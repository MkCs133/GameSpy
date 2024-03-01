using System;
using System.Collections.Generic;

namespace GameSpy.Models;

public partial class Ram
{
    public int Ramid { get; set; }

    public int? Pcid { get; set; }

    public string Name { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int Capacity { get; set; }

    public int Speed { get; set; }

    public virtual Pc? Pc { get; set; }

    public virtual ICollection<Pc> Pcs { get; set; } = new List<Pc>();
}
