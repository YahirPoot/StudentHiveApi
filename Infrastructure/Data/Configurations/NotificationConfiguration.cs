using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications");
        builder.HasKey(e => e.IdNotification).HasName("PK__Notifica__09D4F166A8339476");

            builder.Property(e => e.IdNotification).HasColumnName("ID_Notification");
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            builder.Property(e => e.IdRequest).HasColumnName("ID_Request");
            builder.Property(e => e.IdUser).HasColumnName("ID_User");
            builder.Property(e => e.Message).IsUnicode(false);

            builder.HasOne(d => d.IdRequestNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.IdRequest)
                .HasConstraintName("FK__Notificat__ID_Re__02FC7413");

            builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Notificat__ID_Us__02084FDA");
    }
}