using System.ComponentModel.DataAnnotations;

namespace DataManagementWASM.Models
{
    public class Player
    {
        public Player()
        {
            Username = "user";
            Email = "user@example.com";
            Rank = 0;
            Kills = 0;
            KD = 0;
            Headshots = 0;
            Accuracy = 0;
        }

        
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(0, 150)]
        public int Rank { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Kills { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public float KD { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Headshots { get; set; }

        [Required]
        [Range(0, 100)]
        public int Accuracy { get; set; }


        public void ResetProperties()
        {
            Username = "user";
            Email = "user@example.com";
            Rank = 0;
            Kills = 0;
            KD = 0;
            Headshots = 0;
            Accuracy = 0;
        }
    }
}
