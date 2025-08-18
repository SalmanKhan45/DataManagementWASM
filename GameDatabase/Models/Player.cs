using System.ComponentModel.DataAnnotations;

namespace GameDatabase.Models
{
    public class Player
    {
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
