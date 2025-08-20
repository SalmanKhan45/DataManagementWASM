using System.ComponentModel.DataAnnotations;

namespace DataManagementWASM.Models
{
    public class Player
    {
        public Player() 
        {
            username = "user";
            email = "user@example.com";
            password = "1234";
            rank = 0;
            kills = 0;
            KD = 0;
            headshots = 0;
            accuracy = 0;
        }
        public int Id { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        [EmailAddress]
        public string email { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public int rank { get; set; }

        [Required]
        public int kills { get; set; }

        [Required]
        public float KD { get; set; }

        [Required]
        public int headshots { get; set; }

        [Required]
        public int accuracy { get; set; }
    }
}
