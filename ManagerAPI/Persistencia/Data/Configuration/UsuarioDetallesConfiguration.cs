using ManagerApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class UsuarioDetallesConfiguration : IEntityTypeConfiguration<UsuarioDetalle>
    {
        public void Configure(EntityTypeBuilder<UsuarioDetalle> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__UsuarioD__3214EC0718700972");

            builder.ToTable("UsuarioDetalle");

            builder.Property(e => e.Direccion)
                .HasMaxLength(30)
                .IsUnicode(false);
            builder.Property(e => e.FechaNacimiento).HasColumnType("datetime");
            builder.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);
        }
    }
}
