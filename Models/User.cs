using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace GameSpy.Models;

public partial class User : IdentityUser
{
    public int Userid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public decimal Balence { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

    public virtual ICollection<Pc> Pcs { get; set; } = new List<Pc>();

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();
}
