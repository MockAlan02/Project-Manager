using ManagerApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class AsignacionUsuarioConfiguration : IEntityTypeConfiguration<AsignacionUsuario>
    {
        public void Configure(EntityTypeBuilder<AsignacionUsuario> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Asignaci__3214EC074B43E6D5");

            builder.ToTable("AsignacionUsuario");

            builder.HasOne(d => d.IdTareaNavigation).WithMany(p => p.AsignacionUsuarios)
                .HasForeignKey(d => d.IdTarea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Tarea");

            builder.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.AsignacionUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Usuario");
        }
    }
}
