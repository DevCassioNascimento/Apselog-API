using Apselog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apselog.Infrastructure.Mappings;

public class VeiculoMapping : IEntityTypeConfiguration<Veiculo>
{
    public void Configure(EntityTypeBuilder<Veiculo> builder)
    {
        builder.ToTable("Veiculos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .IsRequired();

        builder.Property(x => x.Placa)
            .IsRequired()
            .HasMaxLength(20);

        builder.HasIndex(x => x.Placa)
            .IsUnique();

        builder.Property(x => x.Modelo)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Tipo)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Status)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(x => x.MotoristaId)
            .IsRequired();

        builder.HasOne(x => x.Motorista)
            .WithMany(x => x.Veiculos)
            .HasForeignKey(x => x.MotoristaId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
