using StudentHive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StudentHive.Infrastructure.Data.Configurations;

public class TypeHouseRentalConfiguration : IEntityTypeConfiguration<TypesHouseRental>
{
    public void Configure(EntityTypeBuilder<TypesHouseRental> builder)
    {
        builder.ToTable("TypesHouseRental");

        builder.HasKey(e => e.IdTypeHouseRental).HasName("PK__TypesHou__E17AD5E66CBBD0E2");

        builder.Property(e => e.IdTypeHouseRental).HasColumnName("ID_TypeHouseRental");
    }
}