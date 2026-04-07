using Apselog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apselog.Infrastructure.Mappings;

public class EntregaMapping : IEntityTypeConfiguration<Entrega>
{
    public void Configure(EntityTypeBuilder<Entrega> builder)
    {
        builder.ToTable("Entregas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Cidade)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Estado)
            .IsRequired()
            .HasMaxLength(2);

        builder.Property(x => x.Cep)
            .IsRequired();

        builder.Property(x => x.Bairro)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Rua)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Numero)
            .IsRequired();

        builder.Property(x => x.Complemento)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.DataPedido)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.DataEntrega)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Entregador)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<int>();
    }
}
