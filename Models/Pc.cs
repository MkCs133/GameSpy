using System;
using System.Collections.Generic;

namespace GameSpy.Models;

public partial class Pc
{
    public int Pcid { get; set; }

    public int Cpuid { get; set; }

    public int Gpuid { get; set; }

    public int Storageid { get; set; }

    public int Ramid { get; set; }

    public int Motherboardid { get; set; }

    public string Userid { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual Cpu Cpu { get; set; } = null!;

    public virtual ICollection<Cpu> Cpus { get; set; } = new List<Cpu>();

    public virtual Gpu Gpu { get; set; } = null!;

    public virtual ICollection<Gpu> Gpus { get; set; } = new List<Gpu>();

    public virtual Motherboard Motherboard { get; set; } = null!;

    public virtual ICollection<Motherboard> Motherboards { get; set; } = new List<Motherboard>();

    public virtual Ram Ram { get; set; } = null!;

    public virtual ICollection<Ram> Rams { get; set; } = new List<Ram>();

    public virtual Storage Storage { get; set; } = null!;

    public virtual ICollection<Storage> Storages { get; set; } = new List<Storage>();

    public virtual AppUser User { get; set; } = null!;

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
