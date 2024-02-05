using StudentHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentHive.Infrastructure.Data.Configurations;

public class RentalHouseConfiguration : IEntityTypeConfiguration<RentalHouse>
{
    public void Configure(EntityTypeBuilder<RentalHouse> builder)
    {
        builder.ToTable("RentalHouses");
        builder.HasKey(e => e.IdPublication).HasName("PK__RentalHo__D4F61A3B954A627C");

        builder.Property(e => e.IdPublication).HasColumnName("ID_Publication");
        builder.Property(e => e.Description).IsUnicode(false);
        builder.Property(e => e.IdHouseLocation).HasColumnName("ID_HouseLocation");
        builder.Property(e => e.IdHouseService).HasColumnName("ID_HouseService");
        builder.Property(e => e.IdRentalHouseDetail).HasColumnName("ID_RentalHouseDetail");
        builder.Property(e => e.IdTypeHouseRental).HasColumnName("ID_TypeHouseRental");
        builder.Property(e => e.IdUser).HasColumnName("ID_User");
        builder.Property(e => e.PublicationDate).HasColumnType("datetime");
        builder.Property(e => e.Title)
            .HasMaxLength(400)
            .IsUnicode(false);

        builder.HasOne(d => d.IdHouseLocationNavigation).WithMany(p => p.RentalHouse)
            .HasForeignKey(d => d.IdHouseLocation)
            .HasConstraintName("FK__RentalHou__ID_Ho__6EF57B66");

        builder.HasOne(d => d.IdHouseServiceNavigation).WithMany(p => p.RentalHouse)
            .HasForeignKey(d => d.IdHouseService)
            .HasConstraintName("FK__RentalHou__ID_Ho__6FE99F9F");

        builder.HasOne(d => d.IdRentalHouseDetailNavigation).WithMany(p => p.RentalHouse)
            .HasForeignKey(d => d.IdRentalHouseDetail)
            .HasConstraintName("FK__RentalHou__ID_Re__6D0D32F4");

        builder.HasOne(d => d.IdTypeHouseRentalNavigation).WithMany(p => p.RentalHouse)
            .HasForeignKey(d => d.IdTypeHouseRental)
            .HasConstraintName("FK__RentalHou__ID_Ty__6E01572D");

        builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.RentalHouse)
            .HasForeignKey(d => d.IdUser)
            .HasConstraintName("FK__RentalHou__ID_Us__70DDC3D8");
    }
}