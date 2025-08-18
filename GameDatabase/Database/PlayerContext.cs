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

            new Player() { Id = 1, username = "abc", email = "abc@gmail.com", password = "abc123", rank = 2, kills = 78, accuracy = 53, headshots = 9, KD = 0.6f },
            new Player() { Id = 2, username = "xingq", email = "something@gmail.com", password = "iqjifnqw3", rank = 3, kills = 190, accuracy = 75, headshots = 21, KD = 0.79f },
            new Player() { Id = 3, username = "matt41", email = "ice23@gmail.com", password = "jr3i214", rank = 4, kills = 294, accuracy = 80, headshots = 89, KD = 0.95f }
            );
        }

    }
}
