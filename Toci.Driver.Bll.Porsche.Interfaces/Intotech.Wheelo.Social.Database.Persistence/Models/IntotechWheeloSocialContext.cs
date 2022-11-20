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

    public virtual DbSet<Commenttype> Commenttypes { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Groupmember> Groupmembers { get; set; }

    public virtual DbSet<Groupspost> Groupsposts { get; set; }

    public virtual DbSet<Groupspostscomment> Groupspostscomments { get; set; }

    public virtual DbSet<Meetingskippedaccount> Meetingskippedaccounts { get; set; }

    public virtual DbSet<Organizemeeting> Organizemeetings { get; set; }

    public virtual DbSet<Usercomment> Usercomments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Intotech.Wheelo.Social;Username=postgres;Password=beatka");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
            entity.Property(e => e.Privacy).HasColumnName("privacy");
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
            entity.Property(e => e.Idaccountwhoadded).HasColumnName("idaccountwhoadded");
            entity.Property(e => e.Idgroups).HasColumnName("idgroups");
            entity.Property(e => e.Level).HasColumnName("level");

            entity.HasOne(d => d.IdgroupsNavigation).WithMany(p => p.Groupmembers)
                .HasForeignKey(d => d.Idgroups)
                .HasConstraintName("groupmembers_idgroups_fkey");
        });

        modelBuilder.Entity<Groupspost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("groupsposts_pkey");

            entity.ToTable("groupsposts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
            entity.Property(e => e.Idgroups).HasColumnName("idgroups");

            entity.HasOne(d => d.IdgroupsNavigation).WithMany(p => p.Groupsposts)
                .HasForeignKey(d => d.Idgroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("groupsposts_idgroups_fkey");
        });

        modelBuilder.Entity<Groupspostscomment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("groupspostscomments_pkey");

            entity.ToTable("groupspostscomments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idaccountcommenting).HasColumnName("idaccountcommenting");
            entity.Property(e => e.Idcommenttypes).HasColumnName("idcommenttypes");
            entity.Property(e => e.Idgroupspostscomments).HasColumnName("idgroupspostscomments");
            entity.Property(e => e.Idpostcommented).HasColumnName("idpostcommented");

            entity.HasOne(d => d.IdcommenttypesNavigation).WithMany(p => p.Groupspostscomments)
                .HasForeignKey(d => d.Idcommenttypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("groupspostscomments_idcommenttypes_fkey");

            entity.HasOne(d => d.IdgroupspostscommentsNavigation).WithMany(p => p.InverseIdgroupspostscommentsNavigation)
                .HasForeignKey(d => d.Idgroupspostscomments)
                .HasConstraintName("groupspostscomments_idgroupspostscomments_fkey");

            entity.HasOne(d => d.IdpostcommentedNavigation).WithMany(p => p.Groupspostscomments)
                .HasForeignKey(d => d.Idpostcommented)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("groupspostscomments_idpostcommented_fkey");
        });

        modelBuilder.Entity<Meetingskippedaccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("meetingskippedaccounts_pkey");

            entity.ToTable("meetingskippedaccounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
            entity.Property(e => e.Idgroups).HasColumnName("idgroups");
            entity.Property(e => e.Idorganizemeeting).HasColumnName("idorganizemeeting");

            entity.HasOne(d => d.IdgroupsNavigation).WithMany(p => p.Meetingskippedaccounts)
                .HasForeignKey(d => d.Idgroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("meetingskippedaccounts_idgroups_fkey");

            entity.HasOne(d => d.IdorganizemeetingNavigation).WithMany(p => p.Meetingskippedaccounts)
                .HasForeignKey(d => d.Idorganizemeeting)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("meetingskippedaccounts_idorganizemeeting_fkey");
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
            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
            entity.Property(e => e.Idgroups).HasColumnName("idgroups");
            entity.Property(e => e.Isover)
                .HasDefaultValueSql("false")
                .HasColumnName("isover");
            entity.Property(e => e.Meetingdate)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("meetingdate");
            entity.Property(e => e.Name).HasColumnName("name");

            entity.HasOne(d => d.IdgroupsNavigation).WithMany(p => p.Organizemeetings)
                .HasForeignKey(d => d.Idgroups)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizemeeting_idgroups_fkey");
        });

        modelBuilder.Entity<Usercomment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("usercomments_pkey");

            entity.ToTable("usercomments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idaccountcommented).HasColumnName("idaccountcommented");
            entity.Property(e => e.Idaccountcommenting).HasColumnName("idaccountcommenting");
            entity.Property(e => e.Idcommenttypes).HasColumnName("idcommenttypes");
            entity.Property(e => e.Idusercomments).HasColumnName("idusercomments");

            entity.HasOne(d => d.IdcommenttypesNavigation).WithMany(p => p.Usercomments)
                .HasForeignKey(d => d.Idcommenttypes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("usercomments_idcommenttypes_fkey");

            entity.HasOne(d => d.IdusercommentsNavigation).WithMany(p => p.InverseIdusercommentsNavigation)
                .HasForeignKey(d => d.Idusercomments)
                .HasConstraintName("usercomments_idusercomments_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
