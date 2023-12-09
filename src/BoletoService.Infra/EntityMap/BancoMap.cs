using BoletoService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pe.Infra.EntityMap;

namespace BoletoService.Infra.EntityMap
{
    public class BancoMap : BaseEntityMap<Banco>
    {
        public override void Configure(EntityTypeBuilder<Banco> builder)
        {
            base.Configure(builder);
            builder.Property(s => s.Nome).HasMaxLength(255).IsRequired();
            builder.Property(s => s.Codigo).HasMaxLength(12).IsRequired();
            builder.Property(s => s.PercentualJuros).HasPrecision(18, 2).IsRequired();

            //indices
            builder.HasIndex(s => s.Codigo).IsUnique(true);


        }
    }
}
