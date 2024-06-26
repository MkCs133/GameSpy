﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace GameSpy.Models;

public partial class AppUser : IdentityUser
{
    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string ProfilePicture { get; set; }             

    public decimal Balance { get; set; }

    public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();

}