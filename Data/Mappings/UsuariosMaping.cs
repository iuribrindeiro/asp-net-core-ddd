﻿using System;
using Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class UsuariosMaping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasIndex(u => u.Id);
            builder.Property(u => u.UserName).HasMaxLength(10).IsRequired();
            builder.Property(u => u.CadastroConfirmado).IsRequired();
            builder.Property(u => u.Lembrar).IsRequired();
            builder.Property(u => u.CPFCNPJ).IsRequired().HasMaxLength(14);
            builder.Property(u => u.DataNascimento);
            builder.Property(u => u.Ddd).HasMaxLength(2).IsRequired();
            builder.Property(u => u.Telefone).IsRequired().HasMaxLength(9);
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.DataCadastro);
            builder.Property(u => u.DataAtualizacao);
        }
    }
}