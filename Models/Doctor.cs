using System.ComponentModel.DataAnnotations;

namespace BharatMedics.Models
{
    public class Doctor
    {
        [Key]

        public int Id { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string Password { get; set; }
    }
}
