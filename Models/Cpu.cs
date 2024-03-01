using System;
using System.Collections.Generic;

namespace GameSpy.Models;

public partial class Cpu
{
    public int Cpuid { get; set; }

    public int? Pcid { get; set; }

    public string Name { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public decimal Speed { get; set; }

    public virtual Pc? Pc { get; set; }

    public virtual ICollection<Pc> Pcs { get; set; } = new List<Pc>();
}
