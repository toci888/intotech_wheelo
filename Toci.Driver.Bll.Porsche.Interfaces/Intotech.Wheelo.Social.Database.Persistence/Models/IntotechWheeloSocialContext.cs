using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Wheelo.Social.Database.Persistence.Models;

public partial class IntotechWheeloSocialContext : DbContext
{
    public IntotechWheeloSocialContext()
    {
    }

    public IntotechWheeloSocialContext(DbContextOptions<IntotechWheeloSocialContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Commenttype> Commenttypes { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Groupmember> Groupmembers { get; set; }

    public virtual DbSet<Organizemeeting> Organizemeetings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Intotech.Wheelo.Social;Username=postgres;Password=beatka");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("comments_pkey");

            entity.ToTable("comments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idcommenttypes).HasColumnName("idcommenttypes");

            entity.HasOne(d => d.IdcommenttypesNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.Idcommenttypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comments_idcommenttypes_fkey");
        });

        modelBuilder.Entity<Commenttype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("commenttypes_pkey");

            entity.ToTable("commenttypes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("groups_pkey");

            entity.ToTable("groups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idaccountcreated).HasColumnName("idaccountcreated");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Groupmember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("groupmembers_pkey");

            entity.ToTable("groupmembers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
            entity.Property(e => e.Idgroups).HasColumnName("idgroups");

            entity.HasOne(d => d.IdgroupsNavigation).WithMany(p => p.Groupmembers)
                .HasForeignKey(d => d.Idgroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("groupmembers_idgroups_fkey");
        });

        modelBuilder.Entity<Organizemeeting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("organizemeeting_pkey");

            entity.ToTable("organizemeeting");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idgroups).HasColumnName("idgroups");
            entity.Property(e => e.Meetingdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("meetingdate");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.IdgroupsNavigation).WithMany(p => p.Organizemeetings)
                .HasForeignKey(d => d.Idgroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizemeeting_idgroups_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
