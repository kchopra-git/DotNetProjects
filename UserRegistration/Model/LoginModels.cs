using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserRegistration.Model
{
    public class LoginModels
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public string UserEmail { get; set; }

        [Required]
        public string password { get; set; }
    }
}
