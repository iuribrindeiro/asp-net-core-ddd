﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CPFCNPJ")
                        .IsRequired()
                        .HasMaxLength(14);

                    b.Property<bool>("CadastroConfirmado");

                    b.Property<DateTime?>("DataAtualizacao");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<DateTime>("DataNascimento");

                    b.Property<string>("Ddd")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<bool>("Lembrar");

                    b.Property<string>("NormalizedEmail")
                        .IsRequired();

                    b.Property<string>("NormalizedUserName")
                        .IsRequired();

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
