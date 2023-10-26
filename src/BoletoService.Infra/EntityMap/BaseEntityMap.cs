using BoletoService.Shared.Abstractions;
using BoletoService.Shared.Messages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BoletoService.Infra.EntityMap
{
    public abstract class BaseEntityMap<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey((TEntity p) => p.Id);


            builder.Property((TEntity p) => p.Id).IsRequired().ValueGeneratedNever();

            //indices
            builder.HasIndex((TEntity p) => p.Id).IsUnique();
        }
    }
}
