using StudentHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentHive.Infrastructure.Data.Configurations;

public class RentalHouseDetailConfiguration : IEntityTypeConfiguration<RentalHouseDetail>
{
    public void Configure(EntityTypeBuilder<RentalHouseDetail> builder)
    {
        builder.ToTable("RentalHouseDetails");

        builder.HasKey(e => e.IdRentalHouseDetail).HasName("PK__RentalHo__EDFA085E2CA7EF52");

        builder.Property(e => e.IdRentalHouseDetail).HasColumnName("ID_RentalHouseDetail");
    }
}