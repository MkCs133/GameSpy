using System;
using System.Collections.Generic;

namespace GameSpy.Models;

public partial class Storage
{
    public int Storageid { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public decimal Capacity { get; set; }

    public int? Pcid { get; set; }

    public virtual Pc? Pc { get; set; }

    public virtual ICollection<Pc> Pcs { get; set; } = new List<Pc>();
}
