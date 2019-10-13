using ChurrasTrinca.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChurrasTrinca.Data.Mappings
{
    public class ChurrasMapping : IEntityTypeConfiguration<Churras>
    {
        public void Configure(EntityTypeBuilder<Churras> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Data)
                .IsRequired()
                .HasColumnType("datetime");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(300)");

            builder.Property(p => p.Observacao)
               .IsRequired()
               .HasColumnType("varchar(300)");

            builder.Property(p => p.ValorComBebida)
                .IsRequired();

            builder.Property(p => p.ValorSemBebida)
                .IsRequired();

            builder.Property(p => p.ValorArrecadado)
                .IsRequired();

            // 1 : N => Churras : Participante
            builder.HasMany(f => f.Participantes)
                .WithOne(p => p.Churras)
                .HasForeignKey(p => p.ChurrasId);

            builder.ToTable("Churras");
        }
    }
}