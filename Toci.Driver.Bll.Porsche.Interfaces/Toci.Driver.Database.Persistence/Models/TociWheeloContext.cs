using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class TociWheeloContext : DbContext
    {
        public TociWheeloContext()
        {
        }

        public TociWheeloContext(DbContextOptions<TociWheeloContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Carsbrand> Carsbrands { get; set; }
        public virtual DbSet<Carsmodel> Carsmodels { get; set; }
        public virtual DbSet<Friend> Friends { get; set; }
        public virtual DbSet<Friendsuggestion> Friendsuggestions { get; set; }
        public virtual DbSet<Geographicregion> Geographicregions { get; set; }
        public virtual DbSet<Invitation> Invitations { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Userscollocation> Userscollocations { get; set; }
        public virtual DbSet<Userslocation> Userslocations { get; set; }
        public virtual DbSet<Usersworktime> Usersworktimes { get; set; }
        public virtual DbSet<Vfriend> Vfriends { get; set; }
        public virtual DbSet<Vfriendsuggestion> Vfriendsuggestions { get; set; }
        public virtual DbSet<Vinvitation> Vinvitations { get; set; }
        public virtual DbSet<Vuserscollocation> Vuserscollocations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Toci.Wheelo;Username=postgres;Password=beatka");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("cars");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Availableseats).HasColumnName("availableseats");

                entity.Property(e => e.Datewhen)
                    .HasColumnName("datewhen")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idcarsbrands).HasColumnName("idcarsbrands");

                entity.Property(e => e.Idcarsmodels).HasColumnName("idcarsmodels");

                entity.Property(e => e.Idusers).HasColumnName("idusers");

                entity.HasOne(d => d.IdcarsbrandsNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.Idcarsbrands)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cars_idcarsbrands_fkey");

                entity.HasOne(d => d.IdcarsmodelsNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.Idcarsmodels)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cars_idcarsmodels_fkey");

                entity.HasOne(d => d.IdusersNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.Idusers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cars_idusers_fkey");
            });

            modelBuilder.Entity<Carsbrand>(entity =>
            {
                entity.ToTable("carsbrands");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Brand).HasColumnName("brand");
            });

            modelBuilder.Entity<Carsmodel>(entity =>
            {
                entity.ToTable("carsmodels");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idcarsbrands).HasColumnName("idcarsbrands");

                entity.Property(e => e.Model).HasColumnName("model");

                entity.HasOne(d => d.IdcarsbrandsNavigation)
                    .WithMany(p => p.Carsmodels)
                    .HasForeignKey(d => d.Idcarsbrands)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("carsmodels_idcarsbrands_fkey");
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.ToTable("friends");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datewhen)
                    .HasColumnName("datewhen")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idfriend).HasColumnName("idfriend");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.HasOne(d => d.IdfriendNavigation)
                    .WithMany(p => p.FriendIdfriendNavigations)
                    .HasForeignKey(d => d.Idfriend)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("friends_idfriend_fkey");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.FriendIduserNavigations)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("friends_iduser_fkey");
            });

            modelBuilder.Entity<Friendsuggestion>(entity =>
            {
                entity.ToTable("friendsuggestions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datewhen)
                    .HasColumnName("datewhen")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idsuggested).HasColumnName("idsuggested");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.HasOne(d => d.IdsuggestedNavigation)
                    .WithMany(p => p.FriendsuggestionIdsuggestedNavigations)
                    .HasForeignKey(d => d.Idsuggested)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("friendsuggestions_idsuggested_fkey");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.FriendsuggestionIduserNavigations)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("friendsuggestions_iduser_fkey");
            });

            modelBuilder.Entity<Geographicregion>(entity =>
            {
                entity.ToTable("geographicregion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idparent).HasColumnName("idparent");

                entity.Property(e => e.Idshit).HasColumnName("idshit");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.HasOne(d => d.IdparentNavigation)
                    .WithMany(p => p.InverseIdparentNavigation)
                    .HasForeignKey(d => d.Idparent)
                    .HasConstraintName("geographicregion_idparent_fkey");
            });

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.ToTable("invitations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datewhen)
                    .HasColumnName("datewhen")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idinvited).HasColumnName("idinvited");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.HasOne(d => d.IdinvitedNavigation)
                    .WithMany(p => p.InvitationIdinvitedNavigations)
                    .HasForeignKey(d => d.Idinvited)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("invitations_idinvited_fkey");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.InvitationIduserNavigations)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("invitations_iduser_fkey");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datewhen)
                    .HasColumnName("datewhen")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.Idgeographicregion).HasColumnName("idgeographicregion");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname");

                entity.HasOne(d => d.IdgeographicregionNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Idgeographicregion)
                    .HasConstraintName("users_idgeographicregion_fkey");
            });

            modelBuilder.Entity<Userscollocation>(entity =>
            {
                entity.ToTable("userscollocations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Datewhen)
                    .HasColumnName("datewhen")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idcollocated).HasColumnName("idcollocated");

                entity.Property(e => e.Iduser).HasColumnName("iduser");

                entity.HasOne(d => d.IdcollocatedNavigation)
                    .WithMany(p => p.UserscollocationIdcollocatedNavigations)
                    .HasForeignKey(d => d.Idcollocated)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userscollocations_idcollocated_fkey");

                entity.HasOne(d => d.IduserNavigation)
                    .WithMany(p => p.UserscollocationIduserNavigations)
                    .HasForeignKey(d => d.Iduser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userscollocations_iduser_fkey");
            });

            modelBuilder.Entity<Userslocation>(entity =>
            {
                entity.ToTable("userslocations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cityfrom).HasColumnName("cityfrom");

                entity.Property(e => e.Cityto).HasColumnName("cityto");

                entity.Property(e => e.Coordinatesfrom).HasColumnName("coordinatesfrom");

                entity.Property(e => e.Coordinatesto).HasColumnName("coordinatesto");

                entity.Property(e => e.Datewhen)
                    .HasColumnName("datewhen")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idusers).HasColumnName("idusers");

                entity.Property(e => e.Streetfrom).HasColumnName("streetfrom");

                entity.Property(e => e.Streetto).HasColumnName("streetto");

                entity.HasOne(d => d.IdusersNavigation)
                    .WithMany(p => p.Userslocations)
                    .HasForeignKey(d => d.Idusers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("userslocations_idusers_fkey");
            });

            modelBuilder.Entity<Usersworktime>(entity =>
            {
                entity.ToTable("usersworktime");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idusers).HasColumnName("idusers");

                entity.Property(e => e.Workendhour).HasColumnName("workendhour");

                entity.Property(e => e.Workstarthour).HasColumnName("workstarthour");

                entity.HasOne(d => d.IdusersNavigation)
                    .WithMany(p => p.Usersworktimes)
                    .HasForeignKey(d => d.Idusers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usersworktime_idusers_fkey");
            });

            modelBuilder.Entity<Vfriend>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vfriends");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Suggestedname).HasColumnName("suggestedname");

                entity.Property(e => e.Suggestedsurname).HasColumnName("suggestedsurname");

                entity.Property(e => e.Suggesteduserid).HasColumnName("suggesteduserid");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<Vfriendsuggestion>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vfriendsuggestions");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Suggestedname).HasColumnName("suggestedname");

                entity.Property(e => e.Suggestedsurname).HasColumnName("suggestedsurname");

                entity.Property(e => e.Suggesteduserid).HasColumnName("suggesteduserid");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<Vinvitation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vinvitations");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Suggestedname).HasColumnName("suggestedname");

                entity.Property(e => e.Suggestedsurname).HasColumnName("suggestedsurname");

                entity.Property(e => e.Suggesteduserid).HasColumnName("suggesteduserid");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<Vuserscollocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("vuserscollocations");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Suggestedname).HasColumnName("suggestedname");

                entity.Property(e => e.Suggestedsurname).HasColumnName("suggestedsurname");

                entity.Property(e => e.Suggesteduserid).HasColumnName("suggesteduserid");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
