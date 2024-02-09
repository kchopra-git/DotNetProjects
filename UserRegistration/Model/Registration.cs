using System.ComponentModel.DataAnnotations;

namespace UserRegistration.Model
{
    public class Registration {
        [Key]
    public  int UserId { get; set; }
    [Required]
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    [Required]
    public string UserEmail { get; set; }
    [Required]
    public string password { get; set; } 
    public string UserPhone { get; set; }

    
    }
  
}
