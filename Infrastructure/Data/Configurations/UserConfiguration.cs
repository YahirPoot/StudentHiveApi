using StudentHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentHive.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(e => e.IdUser).HasName("PK__Users__ED4DE442CAC8CA63");

        builder.Property(e => e.IdUser).HasColumnName("ID_User");
        builder.Property(e => e.Email)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.Genderu)
            .HasMaxLength(10)
            .IsUnicode(false);
        builder.Property(e => e.LastName).IsUnicode(false);
        builder.Property(e => e.Name).IsUnicode(false);
        builder.Property(e => e.Password)
            .HasMaxLength(50)
            .IsUnicode(false);
        builder.Property(e => e.ProfilePhotoUrl).IsUnicode(false);
        builder.Property(e => e.UserAge).HasColumnName("User_Age");
    }
}