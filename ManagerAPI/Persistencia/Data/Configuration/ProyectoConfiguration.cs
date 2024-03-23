
using ManagerApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ProyectoConfiguration : IEntityTypeConfiguration<Proyecto>
    {
        public void Configure(EntityTypeBuilder<Proyecto> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Proyecto__3214EC0780431996");

            builder.ToTable("Proyecto");

            builder.Property(e => e.EndTime).HasColumnType("datetime");
            builder.Property(e => e.Nombre)
                .HasMaxLength(20)
                .IsUnicode(false);
            builder.Property(e => e.StartTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        }
    }
}
