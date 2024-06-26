﻿using GameSpy.Models;
using Microsoft.AspNetCore.Identity;

namespace GameSpy.DTOs
{
    public class UserDTO : IdentityUser
    {
        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public decimal Balance { get; set; }

        public string ProfilePicture { get; set; }

        public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

        public virtual ICollection<GameDTO> Games { get; set; } = new List<GameDTO>();

        public int NumberOfGames { get; set; }

        public int NumberOfAchievements { get; set; }

        public List<GameDTO> RecentGames { get; set; } = new List<GameDTO>();
    }
}
