using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UI.WebApi.Dominio;

namespace UI.WebApi.Data.Mappings
{
    public class ReservaCarroMap : IEntityTypeConfiguration<ReservaCarro>
    {
        public void Configure(EntityTypeBuilder<ReservaCarro> builder)
        {
            builder.ToTable("ReservasCarro");
            builder.HasKey(p => p.Id);
            builder.Property(r => r.ClienteId);
            builder.Property(c => c.ModeloDoVeiculo).IsRequired().HasColumnType("varchar(1024)");
            builder.Property(r => r.Preco).IsRequired().HasColumnType("decimal(5, 2)");
            builder.Property(c => c.Status).IsRequired().HasConversion<int>();
            builder.Property(c => c.DataInicio).IsRequired().HasColumnType("datetime");
            builder.Property(c => c.DataFim).IsRequired().HasColumnType("datetime");
        }
    }
}
