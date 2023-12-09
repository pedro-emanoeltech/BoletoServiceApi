using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pe.Shared.Abstractions;

namespace Pe.Infra.EntityMap
{
    public abstract class BaseEntityMap<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
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
