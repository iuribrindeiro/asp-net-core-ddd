using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels
{
    public class LoginUsuarioViewModel
    {
        [Required(ErrorMessage = "UserNameRequired")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "PasswordRequired")]
        public string Password { get; set; }
    }
}