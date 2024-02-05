using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentHive.Domain.Entities;
using StudentHive.Infrastructure.Data.Configurations;

namespace StudentHive.Infrastructure.Data;

public partial class StudentHiveDbContext : DbContext
{
    public StudentHiveDbContext()
    {
    }

    public StudentHiveDbContext(DbContextOptions<StudentHiveDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HouseLocation> HouseLocations { get; set; }

    public virtual DbSet<HouseService> HouseServices { get; set; }

    public virtual DbSet<RentalHouse> RentalHouse { get; set; }

    public virtual DbSet<RentalHouseDetail> RentalHouseDetails { get; set; }

    public virtual DbSet<TypeHouseRental> TypesHouseRental { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new HouseLocationConfiguration());
        modelBuilder.ApplyConfiguration(new HouseServiceConfiguration());
        modelBuilder.ApplyConfiguration(new RentalHouseConfiguration());
        modelBuilder.ApplyConfiguration(new RentalHouseDetailConfiguration());
        modelBuilder.ApplyConfiguration(new TypeHouseRentalConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
