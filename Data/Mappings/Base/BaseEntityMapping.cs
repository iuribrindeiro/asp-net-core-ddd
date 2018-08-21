using Domain.Entidades.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings.Base
{
    public class BaseEntityMapping : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.HasIndex(e => e.Id);
            builder.Property(e => e.DataCadastro).IsRequired();
            builder.Property(e => e.DataAtualizacao).IsRequired(false);
        }
    }
}