using ManagerApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Usuario__3214EC07F1C6ACF9");

            builder.ToTable("Usuario");

            builder.Property(e => e.Contrasena)
                .HasMaxLength(20)
                .IsUnicode(false);
            builder.Property(e => e.Correo)
                .HasMaxLength(30)
                .IsUnicode(false);
            builder.Property(e => e.Rol)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.HasOne(d => d.IdUsuarioDetallesNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdUsuarioDetalles)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_UsuarioDetalles");
        }
    }
}
