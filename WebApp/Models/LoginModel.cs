using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class LoginModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserEmail { get; set; }

        [Required]
        public string password { get; set; }
    }
}
