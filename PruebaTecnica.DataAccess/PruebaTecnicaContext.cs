using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace PruebaTecnica.Models.Entities;

public partial class PruebaTecnicaContext : DbContext
{
    private readonly string _connectionStrings;

    public PruebaTecnicaContext(IConfiguration appConfiguration)
    {
        _connectionStrings = appConfiguration.GetConnectionString("PruebaTecnica")!;
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarAvailable> CarAvailables { get; set; }

    public virtual DbSet<CarBrand> CarBrands { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseSqlServer(_connectionStrings, p => {
                p.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                p.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Car__3214EC071FEAD502");

            entity.ToTable("Car");

            entity.HasOne(d => d.CarBrandNavigation).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarBrand)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Car__CarBrand__440B1D61");
        });

        modelBuilder.Entity<CarAvailable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarAvail__3214EC07BB9F760E");

            entity.ToTable("CarAvailable");

            entity.HasOne(d => d.Car).WithMany(p => p.CarAvailables)
                .HasForeignKey(d => d.CarId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarAvaila__CarId__46E78A0C");

            entity.HasOne(d => d.CollectionLocation).WithMany(p => p.CarAvailableCollectionLocations)
                .HasForeignKey(d => d.CollectionLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarAvaila__Colle__47DBAE45");

            entity.HasOne(d => d.ReturnLocation).WithMany(p => p.CarAvailableReturnLocations)
                .HasForeignKey(d => d.ReturnLocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CarAvaila__Retur__48CFD27E");
        });

        modelBuilder.Entity<CarBrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CarBrand__3214EC0709815D6C");

            entity.ToTable("CarBrand");

            entity.Property(e => e.CarBrandName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__City__3214EC076DC8251A");

            entity.ToTable("City");

            entity.Property(e => e.CityName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Cities)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__City__Department__3C69FB99");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Country__3214EC07C6C64C1D");

            entity.ToTable("Country");

            entity.Property(e => e.CountryName)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07B786FE8B");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Departments)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Departmen__Count__398D8EEE");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC0718196FED");

            entity.ToTable("Location");

            entity.Property(e => e.LocationName)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.City).WithMany(p => p.Locations)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Location__CityId__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
