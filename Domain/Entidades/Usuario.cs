using System;
using Domain.Entidades.Base;

namespace Domain.Entidades
{
    public class Usuario : BaseEntity
    {
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public string PasswordHash { get; set; }
        public bool CadastroConfirmado { get; set; }
        public bool Lembrar { get; set; }
        public string Ddd { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPFCNPJ { get; set; }
        public virtual bool EhPessoaFisica
        {
            get => CPFCNPJ?.Length > 11;
        }
    }
}