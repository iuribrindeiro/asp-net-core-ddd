﻿using System;

namespace Domain.Entidades
{
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
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
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public virtual bool EhPessoaFisica
        {
            get => CPFCNPJ?.Length > 11;
        }
    }
}