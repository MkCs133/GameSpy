using GameSpy.Models;

namespace GameSpy.DTOs
{
    public class GameDTO
    {
        public int Gameid { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public string Image { get; set; }

        public DateTime RecentTime { get; set; }
        public decimal Rating { get; set; }

        public string Manufacturer { get; set; } = null!;

        public virtual ICollection<Achievement> Achievements { get; set; } = new List<Achievement>();

        public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
    }
}
