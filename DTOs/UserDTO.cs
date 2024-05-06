using GameSpy.Models;
using Microsoft.AspNetCore.Identity;

namespace GameSpy.DTOs
{
    public class UserDTO : IdentityUser
    {
        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public decimal Balance { get; set; }

        public virtual ICollection<Pc> Pcs { get; set; } = new List<Pc>();

        public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

        public virtual ICollection<Game> Games { get; set; } = new List<Game>();

        public int NumberOfGames { get; set; }

        public int NumberOfAchievements { get; set; }
    }
}
