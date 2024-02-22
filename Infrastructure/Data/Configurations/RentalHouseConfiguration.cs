using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentHive.Domain.Entities;

namespace StudentHiveApi.Infrastructure.Data.Configurations;

public class RentalHouseConfiguration : IEntityTypeConfiguration<RentalHouse>
{
    public void Configure(EntityTypeBuilder<RentalHouse> builder)
    {
        builder.ToTable("RentalHouses");
        builder.HasKey(e => e.IdPublication).HasName("PK__RentalHo__D4F61A3BA22BE63D");

            builder.HasIndex(e => e.IdLocation, "UQ__RentalHo__2F2C70A616A44D91").IsUnique();

            builder.HasIndex(e => e.IdHouseService, "UQ__RentalHo__BBD08A225A4C5D1A").IsUnique();

            builder.HasIndex(e => e.IdRentalHouseDetail, "UQ__RentalHo__EDFA085F55A2B5E7").IsUnique();

            builder.Property(e => e.IdPublication).HasColumnName("ID_Publication");
            builder.Property(e => e.Description).IsUnicode(false);
            builder.Property(e => e.IdHouseService).HasColumnName("ID_HouseService");
            builder.Property(e => e.IdLocation).HasColumnName("ID_Location");
            builder.Property(e => e.IdRentalHouseDetail).HasColumnName("ID_RentalHouseDetail");
            builder.Property(e => e.IdTypeReport).HasColumnName("ID_TypeReport");
            builder.Property(e => e.IdUser).HasColumnName("ID_User");
            builder.Property(e => e.PublicationDate).HasColumnType("datetime");
            builder.Property(e => e.Title)
                .HasMaxLength(400)
                .IsUnicode(false);
            builder.Property(e => e.TypeHouse)
                .HasMaxLength(100)
                .IsUnicode(false);
            builder.Property(e => e.WhoElse)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.HasOne(d => d.IdHouseServiceNavigation).WithOne(p => p.RentalHouses)
                .HasForeignKey<RentalHouse>(d => d.IdHouseService)
                .HasConstraintName("FK__RentalHou__ID_Ho__6383C8BA");

            builder.HasOne(d => d.IdLocationNavigation).WithOne(p => p.RentalHouses)
                .HasForeignKey<RentalHouse>(d => d.IdLocation)
                .HasConstraintName("FK__RentalHou__ID_Lo__628FA481");

            builder.HasOne(d => d.IdRentalHouseDetailNavigation).WithOne(p => p.RentalHouses)
                .HasForeignKey<RentalHouse>(d => d.IdRentalHouseDetail)
                .HasConstraintName("FK__RentalHou__ID_Re__619B8048");

            builder.HasOne(d => d.IdTypeReportNavigation).WithMany(p => p.RentalHouses)
                .HasForeignKey(d => d.IdTypeReport)
                .HasConstraintName("FK__RentalHou__ID_Ty__5EBF139D");

            builder.HasOne(d => d.IdUserNavigation).WithMany(p => p.RentalHouses)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__RentalHou__ID_Us__6477ECF3");
    }
}