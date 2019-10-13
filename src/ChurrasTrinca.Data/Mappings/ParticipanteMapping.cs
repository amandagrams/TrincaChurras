using ChurrasTrinca.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChurrasTrinca.Data.Mappings
{
    public class ParticipanteMapping : IEntityTypeConfiguration<Participante>
    {
        public void Configure(EntityTypeBuilder<Participante> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.ValorPago)
               .IsRequired();

            builder.Property(p => p.Pago)
               .IsRequired();

            builder.Property(p => p.ComBebida)
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .IsRequired()
                .HasColumnType("datetime");

            // builder.ToTable("Participante", "schemaX");
            builder.ToTable("Participantes");
        }
    }
}
