using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Wheelo.I18n.Database.Persistence.Models;

public partial class IntotechWheeloI18nContext : DbContext
{
    public IntotechWheeloI18nContext()
    {
    }

    public IntotechWheeloI18nContext(DbContextOptions<IntotechWheeloI18nContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Language> Languages { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Translation> Translations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Intotech.Wheelo.I18n;Username=postgres;Password=beatka");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Language>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("languages_pkey");

            entity.ToTable("languages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Language1).HasColumnName("language");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tags_pkey");

            entity.ToTable("tags");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tag1).HasColumnName("tag");
        });

        modelBuilder.Entity<Translation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("translations_pkey");

            entity.ToTable("translations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Idlanguages).HasColumnName("idlanguages");
            entity.Property(e => e.Idtag).HasColumnName("idtag");

            entity.HasOne(d => d.IdlanguagesNavigation).WithMany(p => p.Translations)
                .HasForeignKey(d => d.Idlanguages)
                .HasConstraintName("translations_idlanguages_fkey");

            entity.HasOne(d => d.IdtagNavigation).WithMany(p => p.Translations)
                .HasForeignKey(d => d.Idtag)
                .HasConstraintName("translations_idtag_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
