using System;
using System.ComponentModel.DataAnnotations;
using Presentation.ValidatorAttributes;

namespace Presentation.ViewModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "UserNameRequired")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "UserNameInvalid")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "EmailRequired")]
        [EmailAddress(ErrorMessage = "EmailInvalid")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "PasswordRequired")]
        public string Password { get; set; }

        [Required(ErrorMessage = "PasswordConfirmRequired")]
        [Compare("Password", ErrorMessage = "PasswordConirmInvalid")]
        public string PasswordConfirm { get; set; }
        
        public bool Lembrar { get; set; }
        
        [Required(ErrorMessage = "DddRequired")]
        [StringLength(2, ErrorMessage = "DddInvalid", MinimumLength = 2)]
        public string Ddd { get; set; }
        
        [Required(ErrorMessage = "TelefoneRequired")]
        [StringLength(9, ErrorMessage = "TelefoneInvalid", MinimumLength = 8)]
        public string Telefone { get; set; }
        
        [Required(ErrorMessage = "DataNascimentoRequireed")]
        public DateTime DataNascimento { get; set; }
        
        [Required(ErrorMessage = "CpfCnpjRequired")]
        [IsCnpjOrCpf]
        public string CPFCNPJ { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}