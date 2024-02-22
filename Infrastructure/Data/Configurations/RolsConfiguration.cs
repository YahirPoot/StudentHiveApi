using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class RolConfiguration : IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Rols");
        builder.HasKey(e => e.IdRol).HasName("PK__Rols__202AD220FD3012F7");

            builder.Property(e => e.IdRol).HasColumnName("ID_Rol");
            builder.Property(e => e.NombreRol)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_Rol");
    }
}