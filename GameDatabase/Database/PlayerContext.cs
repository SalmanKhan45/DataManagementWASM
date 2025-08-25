using Microsoft.EntityFrameworkCore;
using GameDatabase.Models;

namespace GameDatabase.Database
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options) 
        { 
        }
        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>().HasData
            (

            new Player() { Id = 1, Username = "abc", Email = "abc@gmail.com", Rank = 2, Kills = 78, Accuracy = 53, Headshots = 9, KD = 0.6f },
            new Player() { Id = 2, Username = "xingq", Email = "something@gmail.com",  Rank = 3, Kills = 190, Accuracy = 75, Headshots = 21, KD = 0.79f },
            new Player() { Id = 3, Username = "matt41", Email = "matt@gmail.com",  Rank = 4, Kills = 294, Accuracy = 80, Headshots = 89, KD = 0.95f },
            new Player() { Id = 4, Username = "user39", Email = "user3@gmail.com", Rank = 6, Kills = 456, Accuracy = 81, Headshots = 90, KD = 0.98f },
            new Player() { Id = 5, Username = "bot", Email = "bot@gmail.com", Rank = 1, Kills = 34, Accuracy = 66, Headshots = 2, KD = 0.50f },
            new Player() { Id = 6, Username = "bee3", Email = "bee33@gmail.com", Rank = 2, Kills = 60, Accuracy = 76, Headshots = 6, KD = 0.85f },
            new Player() { Id = 7, Username = "player213", Email = "newuser@gmail.com", Rank = 1, Kills = 56, Accuracy = 67, Headshots = 3, KD = 0.7f }
            );
        }

    }
}
