using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentHive.Domain.Entities;

public partial class StudentHiveDbContext : DbContext
{
    public StudentHiveDbContext()
    {
    }

    public StudentHiveDbContext(DbContextOptions<StudentHiveDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administrador { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<HouseService> HouseServices { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<RentalHouseDetail> RentalHouseDetails { get; set; }

    public virtual DbSet<RentalHouse> RentalHouses { get; set; }

    public virtual DbSet<ReportType> ReportTypes { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<ReservationConfirmed> ReservationsConfirmed { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<User> Users { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseSqlServer("Name=ConnectionStrings:gemDevelopment");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Administrador>(entity =>
        // {
            
        // });

        // modelBuilder.Entity<Event>(entity =>
        // {
            
        // });

        // modelBuilder.Entity<HouseService>(entity =>
        // {
            
        // });

        // modelBuilder.Entity<Image>(entity =>
        // {
            
        // });

        // modelBuilder.Entity<Location>(entity =>
        // {
            
        // });

        // modelBuilder.Entity<Notification>(entity =>
        // {
            
        // });

        // modelBuilder.Entity<RentalHouseDetail>(entity =>
        // {
            
        // });

        // modelBuilder.Entity<RentalHouse>(entity =>
        // {
            
        // });

        // modelBuilder.Entity<ReportType>(entity =>
        // {
            
        // });

        // modelBuilder.Entity<Report>(entity =>
        // {
            
        // });

        // modelBuilder.Entity<Request>(entity =>
        // {
            
        // });

        // modelBuilder.Entity<ReservationConfirmed>(entity =>
        // {
        
        // });

        // modelBuilder.Entity<Rol>(entity =>
        // {
            
        // });

        // modelBuilder.Entity<User>(entity =>
        // {
            
        // });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
