using System.ComponentModel.DataAnnotations;
using System.Data;

namespace BharatMedics.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }


        [Required]
        public long PhoneNumber { get; set; }


        [Required(ErrorMessage = "Password Cannot be empty")]
        public string Password { get; set; }


        
    }
}
