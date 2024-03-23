using ManagerApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistencia.Data.Configuration
{
    public class TareaConfiguration : IEntityTypeConfiguration<Tarea>
    {
        public void Configure(EntityTypeBuilder<Tarea> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Tarea__3214EC0748EF09C3");

           builder.ToTable("Tarea");

            builder.Property(e => e.Detalles)
                .HasMaxLength(30)
                .IsUnicode(false);
           builder.Property(e => e.ExpireTime).HasColumnType("datetime");

           builder.HasOne(d => d.Proyecto).WithMany(p => p.Tareas)
                .HasForeignKey(d => d.ProyectoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Fk_Proyecto");
        }
    }
}
