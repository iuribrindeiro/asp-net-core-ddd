using Domain.Entidades;
using Domain.Entidades.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasBaseType<BaseEntity>();
            builder.Property(c => c.Habilitado).IsRequired();
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.NomeExibicao).IsRequired();
            builder.HasMany(c => c.UserClaims);
            builder.HasOne(c => c.Usuario);
        }
    }
}