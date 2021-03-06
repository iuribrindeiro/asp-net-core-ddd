﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Presentation.Attributes.ModelAttributes;

namespace Presentation.ViewModels
{
    public class UsuarioViewModel
    {
        public Guid ?Id { get; set; }
        
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