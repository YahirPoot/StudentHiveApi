using StudentHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentHive.Infrastructure.Data.Configurations;

public class HouseLocationConfiguration : IEntityTypeConfiguration<HouseLocation>
{
    public void Configure(EntityTypeBuilder<HouseLocation> builder)
    {
        builder.ToTable("HouseLocations");
        builder.HasKey(e => e.IdHouseLocation).HasName("PK__HouseLoc__7D562921943A0BF6");

        builder.Property(e => e.IdHouseLocation).HasColumnName("ID_HouseLocation");
        builder.Property(e => e.Address)
            .HasMaxLength(400)
            .IsUnicode(false);
        builder.Property(e => e.City)
            .HasMaxLength(400)
            .IsUnicode(false);
        builder.Property(e => e.Country)
            .HasMaxLength(400)
            .IsUnicode(false);
        builder.Property(e => e.Neighborhood)
            .HasMaxLength(400)
            .IsUnicode(false);
        builder.Property(e => e.State)
            .HasMaxLength(400)
            .IsUnicode(false);
    }
}