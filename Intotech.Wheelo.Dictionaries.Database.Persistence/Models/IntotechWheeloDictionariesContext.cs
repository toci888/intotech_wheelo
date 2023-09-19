using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Wheelo.Dictionaries.Database.Persistence.Models;

public partial class IntotechWheeloDictionariesContext : DbContext
{
    public IntotechWheeloDictionariesContext()
    {
    }

    public IntotechWheeloDictionariesContext(DbContextOptions<IntotechWheeloDictionariesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Carsbrand> Carsbrands { get; set; }

    public virtual DbSet<Carsmodel> Carsmodels { get; set; }

    public virtual DbSet<Colour> Colours { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Intotech.Wheelo.Dictionaries;Username=postgres;Password=beatka");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carsbrand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("carsbrands_pkey");

            entity.ToTable("carsbrands");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Brand).HasColumnName("brand");
        });

        modelBuilder.Entity<Carsmodel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("carsmodels_pkey");

            entity.ToTable("carsmodels");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idcarsbrands).HasColumnName("idcarsbrands");
            entity.Property(e => e.Model).HasColumnName("model");

            entity.HasOne(d => d.IdcarsbrandsNavigation).WithMany(p => p.Carsmodels)
                .HasForeignKey(d => d.Idcarsbrands)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("carsmodels_idcarsbrands_fkey");
        });

        modelBuilder.Entity<Colour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("colours_pkey");

            entity.ToTable("colours");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Rgb).HasColumnName("rgb");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
