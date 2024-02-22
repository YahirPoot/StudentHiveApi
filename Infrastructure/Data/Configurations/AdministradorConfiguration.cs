using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class AdministradorConfiguration : IEntityTypeConfiguration<Administrador>
{
    public void Configure(EntityTypeBuilder<Administrador> builder)
    {
        builder.ToTable("Administrador");
        builder.HasKey(e => e.IdAdmin).HasName("PK__Administ__69F56766502B3540");

            builder.Property(e => e.IdAdmin).HasColumnName("ID_Admin");
            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.IdRol).HasColumnName("ID_Rol");
            builder.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdRolNavigation).WithMany(p => p.Administrador)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Administr__ID_Ro__4BAC3F29");
    }
}