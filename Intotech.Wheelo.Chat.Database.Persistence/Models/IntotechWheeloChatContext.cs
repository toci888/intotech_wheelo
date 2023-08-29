using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Intotech.Wheelo.Chat.Database.Persistence.Models;

public partial class IntotechWheeloChatContext : DbContext
{
    public IntotechWheeloChatContext(Func<IntotechWheeloChatContext> value)
    {
    }

    public IntotechWheeloChatContext(DbContextOptions<IntotechWheeloChatContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accountchat> Accountchats { get; set; }

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
        modelBuilder.Entity<Accountchat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accountchat_pkey");

            entity.ToTable("accountchat");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Firstname).HasColumnName("firstname");
            entity.Property(e => e.Hasmanyaccount).HasColumnName("hasmanyaccount");
            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
            entity.Property(e => e.Lastname).HasColumnName("lastname");
            entity.Property(e => e.Memberemail).HasColumnName("memberemail");
            entity.Property(e => e.Pushtoken).HasColumnName("pushtoken");
        });

        modelBuilder.Entity<Accountsidentifier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accountsidentifiers_pkey");

            entity.ToTable("accountsidentifiers");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Idroom).HasColumnName("idroom");

            entity.HasOne(d => d.IdroomNavigation).WithMany(p => p.Accountsidentifiers)
                .HasForeignKey(d => d.Idroom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("accountsidentifiers_idroom_fkey");
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
            entity.Property(e => e.Email).HasColumnName("email");
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
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Emailinvited).HasColumnName("emailinvited");
            entity.Property(e => e.Idaccountinvited).HasColumnName("idaccountinvited");
            entity.Property(e => e.Idacount).HasColumnName("idacount");
            entity.Property(e => e.Idroom).HasColumnName("idroom");

            entity.HasOne(d => d.IdroomNavigation).WithMany(p => p.Conversationinvitations)
                .HasForeignKey(d => d.Idroom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("conversationinvitations_idroom_fkey");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("messages_pkey");

            entity.ToTable("messages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Authoremail).HasColumnName("authoremail");
            entity.Property(e => e.Createdat)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("createdat");
            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
            entity.Property(e => e.Idroom).HasColumnName("idroom");
            entity.Property(e => e.Message1).HasColumnName("message");

            entity.HasOne(d => d.IdroomNavigation).WithMany(p => p.Messages)
                .HasForeignKey(d => d.Idroom)
                .OnDelete(DeleteBehavior.ClientSetNull)
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
            entity.Property(e => e.Owneremail).HasColumnName("owneremail");
            entity.Property(e => e.Owneridaccount).HasColumnName("owneridaccount");
            entity.Property(e => e.Roomid).HasColumnName("roomid");
            entity.Property(e => e.Roomname).HasColumnName("roomname");
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
            entity.Property(e => e.Idroom).HasColumnName("idroom");
            entity.Property(e => e.Isapproved)
                .HasDefaultValueSql("false")
                .HasColumnName("isapproved");
            entity.Property(e => e.Memberemail).HasColumnName("memberemail");
            entity.Property(e => e.Memberidaccount).HasColumnName("memberidaccount");
            entity.Property(e => e.Roomid).HasColumnName("roomid");

            entity.HasOne(d => d.IdroomNavigation).WithMany(p => p.Roomsaccounts)
                .HasForeignKey(d => d.Idroom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("roomsaccounts_idroom_fkey");
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
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
