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

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roomsaccount> Roomsaccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Intotech.Wheelo.Chat;Username=postgres;Password=beatka");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accountsidentifier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accountsidentifiers_pkey");

            entity.ToTable("accountsidentifiers");

            entity.HasIndex(e => e.Roomid, "accountsidentifiers_roomid_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accountid).HasColumnName("accountid");
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
            entity.Property(e => e.Idroom).HasColumnName("idroom");
            entity.Property(e => e.Message1).HasColumnName("message");

            entity.HasOne(d => d.IdroomNavigation).WithMany(p => p.Messages)
                .HasForeignKey(d => d.Idroom)
                .HasConstraintName("messages_idroom_fkey");
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
            entity.Property(e => e.Idmember).HasColumnName("idmember");
            entity.Property(e => e.Idroom).HasColumnName("idroom");

            entity.HasOne(d => d.IdroomNavigation).WithMany(p => p.Roomsaccounts)
                .HasForeignKey(d => d.Idroom)
                .HasConstraintName("roomsaccounts_idroom_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
