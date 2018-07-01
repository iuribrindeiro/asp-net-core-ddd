using System;
using System.ComponentModel.DataAnnotations;
using Presentation.Attributes.ModelAttributes;

namespace Presentation.ViewModels
{
    public class EditUsuarioViewModel
    {
        [Required(ErrorMessage = "EmailRequired")]
        [EmailAddress(ErrorMessage = "EmailInvalid")]
        public string Email { get; set; }

        public bool CadastroConfirmado { get; set; }
        
        public bool Lembrar { get; set; }
        
        [Required(ErrorMessage = "DddRequired")]
        [StringLength(2, ErrorMessage = "DddInvalid", MinimumLength = 2)]
        public string Ddd { get; set; }
        
        [Required(ErrorMessage = "TelefoneRequired")]
        [StringLength(9, ErrorMessage = "TelefoneInvalid", MinimumLength = 8)]
        public string Telefone { get; set; }
        
        [Required(ErrorMessage = "DataNascimentoRequired")]
        public DateTime? DataNascimento { get; set; }
        
        [Required(ErrorMessage = "CpfCnpjRequired")]
        [IsCnpjOrCpf]
        public string CPFCNPJ { get; set; }
        
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
    }
}