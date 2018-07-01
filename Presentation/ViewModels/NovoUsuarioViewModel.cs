using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels
{
    public class NovoUsuarioViewModel : EditUsuarioViewModel
    {
        [Required(ErrorMessage = "UserNameRequired")]
        [MinLength(6, ErrorMessage = "UserNameInvalidLength")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "UserNameInvalid")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "PasswordRequired")]
        [MinLength(6, ErrorMessage = "PasswordInvalidLength")]
        [RegularExpression("^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z].*).*$", ErrorMessage = "PasswordInvalid")]
        public string Password { get; set; }

        [Required(ErrorMessage = "PasswordConfirmRequired")]
        [Compare("Password", ErrorMessage = "PasswordConfirmCompare")]
        public string PasswordConfirm { get; set; }
    }
}