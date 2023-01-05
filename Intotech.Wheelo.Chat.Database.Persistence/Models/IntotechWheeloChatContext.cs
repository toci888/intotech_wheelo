using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class IntotechWheeloChatContext : DbContext
{
    public IntotechWheeloChatContext()
    {
    }

    public IntotechWheeloChatContext(DbContextOptions<IntotechWheeloChatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accountsidentifier> Accountsidentifiers { get; set; }

    public virtual DbSet<Connecteduser> Connectedusers { get; set; }

    public virtual DbSet<Conversationinvitation> Conversationinvitations { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roomsaccount> Roomsaccounts { get; set; }

    public virtual DbSet<Useractivity> Useractivities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Intotech.Wheelo.Chat;Username=postgres;Password=beatka");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accountsidentifier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accountsidentifiers_pkey");

            entity.ToTable("accountsidentifiers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
        });

        modelBuilder.Entity<Connecteduser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("connectedusers_pkey");

            entity.ToTable("connectedusers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
        });

        modelBuilder.Entity<Conversationinvitation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("conversationinvitations_pkey");

            entity.ToTable("conversationinvitations");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
            entity.Property(e => e.Idaccountinvited).HasColumnName("idaccountinvited");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("messages_pkey");

            entity.ToTable("messages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idauthor).HasColumnName("idauthor");
            entity.Property(e => e.Message1).HasColumnName("message");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rooms_pkey");

            entity.ToTable("rooms");

            entity.HasIndex(e => e.Roomid, "rooms_roomid_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Ownerid).HasColumnName("ownerid");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Type)
                .HasDefaultValueSql("1")
                .HasColumnName("type");
        });

        modelBuilder.Entity<Roomsaccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roomsaccounts_pkey");

            entity.ToTable("roomsaccounts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idmember).HasColumnName("idmember");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
        });

        modelBuilder.Entity<Useractivity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("useractivity_pkey");

            entity.ToTable("useractivity");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Connectedfrom)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("connectedfrom");
            entity.Property(e => e.Connectedto)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("connectedto");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
