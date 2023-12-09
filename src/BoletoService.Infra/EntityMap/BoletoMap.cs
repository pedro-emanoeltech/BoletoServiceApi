using BoletoService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pe.Infra.EntityMap;
using Pe.Shared.Common;

namespace BoletoService.Infra.EntityMap
{
    public class BoletoMap : BaseEntityMap<Boleto>
    {
        public override void Configure(EntityTypeBuilder<Boleto> builder)
        {
            base.Configure(builder);

            builder.Property(s => s.NomePagador).HasMaxLength(255).IsRequired();
            builder.Property(s => s.NomeBeneficiario).HasMaxLength(255).IsRequired();
            builder.Property(s => s.CpfCnpjPagador).HasMaxLength(14).IsRequired();
            builder.Property(s => s.CpfCnpjBeneficiario).HasMaxLength(14).IsRequired();
            builder.Property(s => s.Observacoes).HasMaxLength(600);
            builder.Property(s => s.Valor).HasPrecision(18, 2).IsRequired();
            builder.Property(s => s.DataVencimento).HasColumnType(ColumnTypeConstants.Date).IsRequired();

            builder.HasOne(s => s.Banco).WithMany(s => s.Boletos).HasForeignKey(i => i.BancoId);
        }
    }
}
