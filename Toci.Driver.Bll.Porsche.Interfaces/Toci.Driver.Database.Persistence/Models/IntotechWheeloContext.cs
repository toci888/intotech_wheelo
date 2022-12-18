using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Toci.Driver.Database.Persistence.Models
{
    public partial class IntotechWheeloContext : DbContext
    {
        public IntotechWheeloContext()
        {
        }

        public IntotechWheeloContext(DbContextOptions<IntotechWheeloContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Accountmetadatum> Accountmetadata { get; set; } = null!;
        public virtual DbSet<Accountmode> Accountmodes { get; set; } = null!;
        public virtual DbSet<Accountrole> Accountroles { get; set; } = null!;
        public virtual DbSet<Accountscarslocation> Accountscarslocations { get; set; } = null!;
        public virtual DbSet<Accountscollocation> Accountscollocations { get; set; } = null!;
        public virtual DbSet<Accountslocation> Accountslocations { get; set; } = null!;
        public virtual DbSet<Accountsworktime> Accountsworktimes { get; set; } = null!;
        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Carsbrand> Carsbrands { get; set; } = null!;
        public virtual DbSet<Carsmodel> Carsmodels { get; set; } = null!;
        public virtual DbSet<Colour> Colours { get; set; } = null!;
        public virtual DbSet<Emailsregister> Emailsregisters { get; set; } = null!;
        public virtual DbSet<Failedloginattempt> Failedloginattempts { get; set; } = null!;
        public virtual DbSet<Friend> Friends { get; set; } = null!;
        public virtual DbSet<Friendsuggestion> Friendsuggestions { get; set; } = null!;
        public virtual DbSet<Geographicregion> Geographicregions { get; set; } = null!;
        public virtual DbSet<Invitation> Invitations { get; set; } = null!;
        public virtual DbSet<Notuser> Notusers { get; set; } = null!;
        public virtual DbSet<Occupation> Occupations { get; set; } = null!;
        public virtual DbSet<Occupationsmokercrat> Occupationsmokercrats { get; set; } = null!;
        public virtual DbSet<Passwordstrength> Passwordstrengths { get; set; } = null!;
        public virtual DbSet<Pushtoken> Pushtokens { get; set; } = null!;
        public virtual DbSet<Resetpassword> Resetpasswords { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Statisticstrip> Statisticstrips { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<Tripparticipant> Tripparticipants { get; set; } = null!;
        public virtual DbSet<Userextradatum> Userextradata { get; set; } = null!;
        public virtual DbSet<Vaccountscollocation> Vaccountscollocations { get; set; } = null!;
        public virtual DbSet<Vaccountscollocationsworktrip> Vaccountscollocationsworktrips { get; set; } = null!;
        public virtual DbSet<Vacollocationsgeolocation> Vacollocationsgeolocations { get; set; } = null!;
        public virtual DbSet<Vaworktripgengeolocation> Vaworktripgengeolocations { get; set; } = null!;
        public virtual DbSet<Vcarowner> Vcarowners { get; set; } = null!;
        public virtual DbSet<Vcollocationsgeolocation> Vcollocationsgeolocations { get; set; } = null!;
        public virtual DbSet<Vfriend> Vfriends { get; set; } = null!;
        public virtual DbSet<Vfriendsuggestion> Vfriendsuggestions { get; set; } = null!;
        public virtual DbSet<Vinvitation> Vinvitations { get; set; } = null!;
        public virtual DbSet<Vtripsparticipant> Vtripsparticipants { get; set; } = null!;
        public virtual DbSet<Vworktripgengeolocation> Vworktripgengeolocations { get; set; } = null!;
        public virtual DbSet<Worktrip> Worktrips { get; set; } = null!;
        public virtual DbSet<Worktripgen> Worktripgens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Intotech.Wheelo;Username=postgres;Password=beatka");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Allowsnotifications)
                    .HasColumnName("allowsnotifications")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Emailconfirmed)
                    .HasColumnName("emailconfirmed")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Idrole)
                    .HasColumnName("idrole")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");

                entity.Property(e => e.Refreshtoken).HasColumnName("refreshtoken");

                entity.Property(e => e.Refreshtokenvalid)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("refreshtokenvalid");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.Verificationcode).HasColumnName("verificationcode");

                entity.Property(e => e.Verificationcodevalid)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("verificationcodevalid");

                entity.HasOne(d => d.IdroleNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.Idrole)
                    .HasConstraintName("accounts_idrole_fkey");
            });

            modelBuilder.Entity<Accountmetadatum>(entity =>
            {
                entity.ToTable("accountmetadata");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Idgeographicregion).HasColumnName("idgeographicregion");

                entity.Property(e => e.Idoccupation).HasColumnName("idoccupation");

                entity.Property(e => e.Issmoker)
                    .HasColumnName("issmoker")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Iswithanimals)
                    .HasColumnName("iswithanimals")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Metajson).HasColumnName("metajson");

                entity.Property(e => e.Pesel).HasColumnName("pesel");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.Accountmetadata)
                    .HasForeignKey(d => d.Idaccount)
                    .HasConstraintName("accountmetadata_idaccount_fkey");

                entity.HasOne(d => d.IdgeographicregionNavigation)
                    .WithMany(p => p.Accountmetadata)
                    .HasForeignKey(d => d.Idgeographicregion)
                    .HasConstraintName("accountmetadata_idgeographicregion_fkey");

                entity.HasOne(d => d.IdoccupationNavigation)
                    .WithMany(p => p.Accountmetadata)
                    .HasForeignKey(d => d.Idoccupation)
                    .HasConstraintName("accountmetadata_idoccupation_fkey");
            });

            modelBuilder.Entity<Accountmode>(entity =>
            {
                entity.HasKey(e => e.Idaccount)
                    .HasName("accountmodes_pkey");

                entity.ToTable("accountmodes");

                entity.Property(e => e.Idaccount)
                    .ValueGeneratedNever()
                    .HasColumnName("idaccount");

                entity.Property(e => e.Mode).HasColumnName("mode");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithOne(p => p.Accountmode)
                    .HasForeignKey<Accountmode>(d => d.Idaccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accountmodes_idaccount_fkey");
            });

            modelBuilder.Entity<Accountrole>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("accountroles");

                entity.Property(e => e.Allowsnotifications).HasColumnName("allowsnotifications");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Emailconfirmed).HasColumnName("emailconfirmed");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Refreshtoken).HasColumnName("refreshtoken");

                entity.Property(e => e.Refreshtokenvalid)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("refreshtokenvalid");

                entity.Property(e => e.Rolename).HasColumnName("rolename");

                entity.Property(e => e.Surname).HasColumnName("surname");
            });

            modelBuilder.Entity<Accountscarslocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("accountscarslocations");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Availableseats).HasColumnName("availableseats");

                entity.Property(e => e.Brand).HasColumnName("brand");

                entity.Property(e => e.Cityfrom).HasColumnName("cityfrom");

                entity.Property(e => e.Cityto).HasColumnName("cityto");

                entity.Property(e => e.Colour).HasColumnName("colour");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Model).HasColumnName("model");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Registrationplate).HasColumnName("registrationplate");

                entity.Property(e => e.Rgb).HasColumnName("rgb");

                entity.Property(e => e.Streetfrom).HasColumnName("streetfrom");

                entity.Property(e => e.Streetto).HasColumnName("streetto");

                entity.Property(e => e.Surname).HasColumnName("surname");
            });

            modelBuilder.Entity<Accountscollocation>(entity =>
            {
                entity.ToTable("accountscollocations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Distancefrom).HasColumnName("distancefrom");

                entity.Property(e => e.Distanceto).HasColumnName("distanceto");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Idcollocated).HasColumnName("idcollocated");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.AccountscollocationIdaccountNavigations)
                    .HasForeignKey(d => d.Idaccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accountscollocations_idaccount_fkey");

                entity.HasOne(d => d.IdcollocatedNavigation)
                    .WithMany(p => p.AccountscollocationIdcollocatedNavigations)
                    .HasForeignKey(d => d.Idcollocated)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accountscollocations_idcollocated_fkey");
            });

            modelBuilder.Entity<Accountslocation>(entity =>
            {
                entity.ToTable("accountslocations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Cityfrom).HasColumnName("cityfrom");

                entity.Property(e => e.Cityto).HasColumnName("cityto");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idaccounts).HasColumnName("idaccounts");

                entity.Property(e => e.Latitudefrom).HasColumnName("latitudefrom");

                entity.Property(e => e.Latitudeto).HasColumnName("latitudeto");

                entity.Property(e => e.Longitudefrom).HasColumnName("longitudefrom");

                entity.Property(e => e.Longitudeto).HasColumnName("longitudeto");

                entity.Property(e => e.Streetfrom).HasColumnName("streetfrom");

                entity.Property(e => e.Streetto).HasColumnName("streetto");

                entity.HasOne(d => d.IdaccountsNavigation)
                    .WithMany(p => p.Accountslocations)
                    .HasForeignKey(d => d.Idaccounts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accountslocations_idaccounts_fkey");
            });

            modelBuilder.Entity<Accountsworktime>(entity =>
            {
                entity.ToTable("accountsworktime");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idaccounts).HasColumnName("idaccounts");

                entity.Property(e => e.Workendhour).HasColumnName("workendhour");

                entity.Property(e => e.Workstarthour).HasColumnName("workstarthour");

                entity.HasOne(d => d.IdaccountsNavigation)
                    .WithMany(p => p.Accountsworktimes)
                    .HasForeignKey(d => d.Idaccounts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("accountsworktime_idaccounts_fkey");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("cars");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Availableseats).HasColumnName("availableseats");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idaccounts).HasColumnName("idaccounts");

                entity.Property(e => e.Idcarsbrands).HasColumnName("idcarsbrands");

                entity.Property(e => e.Idcarsmodels).HasColumnName("idcarsmodels");

                entity.Property(e => e.Idcolours).HasColumnName("idcolours");

                entity.Property(e => e.Registrationplate).HasColumnName("registrationplate");

                entity.HasOne(d => d.IdaccountsNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.Idaccounts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cars_idaccounts_fkey");

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

                entity.HasOne(d => d.IdcoloursNavigation)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.Idcolours)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cars_idcolours_fkey");
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

            modelBuilder.Entity<Colour>(entity =>
            {
                entity.ToTable("colours");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Rgb).HasColumnName("rgb");
            });

            modelBuilder.Entity<Emailsregister>(entity =>
            {
                entity.ToTable("emailsregister");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Isverified)
                    .HasColumnName("isverified")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Verificationcode).HasColumnName("verificationcode");
            });

            modelBuilder.Entity<Failedloginattempt>(entity =>
            {
                entity.ToTable("failedloginattempts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Kind).HasColumnName("kind");
            });

            modelBuilder.Entity<Friend>(entity =>
            {
                entity.ToTable("friends");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Idfriend).HasColumnName("idfriend");

                entity.Property(e => e.Method).HasColumnName("method");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.FriendIdaccountNavigations)
                    .HasForeignKey(d => d.Idaccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("friends_idaccount_fkey");

                entity.HasOne(d => d.IdfriendNavigation)
                    .WithMany(p => p.FriendIdfriendNavigations)
                    .HasForeignKey(d => d.Idfriend)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("friends_idfriend_fkey");
            });

            modelBuilder.Entity<Friendsuggestion>(entity =>
            {
                entity.ToTable("friendsuggestions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Idsuggested).HasColumnName("idsuggested");

                entity.Property(e => e.Idsuggestedfriend).HasColumnName("idsuggestedfriend");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.FriendsuggestionIdaccountNavigations)
                    .HasForeignKey(d => d.Idaccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("friendsuggestions_idaccount_fkey");

                entity.HasOne(d => d.IdsuggestedNavigation)
                    .WithMany(p => p.FriendsuggestionIdsuggestedNavigations)
                    .HasForeignKey(d => d.Idsuggested)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("friendsuggestions_idsuggested_fkey");

                entity.HasOne(d => d.IdsuggestedfriendNavigation)
                    .WithMany(p => p.FriendsuggestionIdsuggestedfriendNavigations)
                    .HasForeignKey(d => d.Idsuggestedfriend)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("friendsuggestions_idsuggestedfriend_fkey");
            });

            modelBuilder.Entity<Geographicregion>(entity =>
            {
                entity.ToTable("geographicregion");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idparent).HasColumnName("idparent");

                entity.Property(e => e.Idshit).HasColumnName("idshit");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Nestlevel).HasColumnName("nestlevel");

                entity.HasOne(d => d.IdparentNavigation)
                    .WithMany(p => p.InverseIdparentNavigation)
                    .HasForeignKey(d => d.Idparent)
                    .HasConstraintName("geographicregion_idparent_fkey");
            });

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.ToTable("invitations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Idinvited).HasColumnName("idinvited");

                entity.Property(e => e.Origin).HasColumnName("origin");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.InvitationIdaccountNavigations)
                    .HasForeignKey(d => d.Idaccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("invitations_idaccount_fkey");

                entity.HasOne(d => d.IdinvitedNavigation)
                    .WithMany(p => p.InvitationIdinvitedNavigations)
                    .HasForeignKey(d => d.Idinvited)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("invitations_idinvited_fkey");
            });

            modelBuilder.Entity<Notuser>(entity =>
            {
                entity.ToTable("notuser");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Searchid).HasColumnName("searchid");
            });

            modelBuilder.Entity<Occupation>(entity =>
            {
                entity.ToTable("occupations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Occupationsmokercrat>(entity =>
            {
                entity.ToTable("occupationsmokercrat");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Idoccupation).HasColumnName("idoccupation");

                entity.Property(e => e.Issmoker)
                    .HasColumnName("issmoker")
                    .HasDefaultValueSql("false");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.Occupationsmokercrats)
                    .HasForeignKey(d => d.Idaccount)
                    .HasConstraintName("occupationsmokercrat_idaccount_fkey");

                entity.HasOne(d => d.IdoccupationNavigation)
                    .WithMany(p => p.Occupationsmokercrats)
                    .HasForeignKey(d => d.Idoccupation)
                    .HasConstraintName("occupationsmokercrat_idoccupation_fkey");
            });

            modelBuilder.Entity<Passwordstrength>(entity =>
            {
                entity.ToTable("passwordstrength");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Level).HasColumnName("level");
            });

            modelBuilder.Entity<Pushtoken>(entity =>
            {
                entity.ToTable("pushtokens");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.Pushtokens)
                    .HasForeignKey(d => d.Idaccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pushtokens_idaccount_fkey");
            });

            modelBuilder.Entity<Resetpassword>(entity =>
            {
                entity.ToTable("resetpassword");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Verificationcode).HasColumnName("verificationcode");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Statisticstrip>(entity =>
            {
                entity.ToTable("statisticstrips");

                entity.HasIndex(e => e.Tripdate, "statisticstrips_tripdate_key")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idgeographicregion).HasColumnName("idgeographicregion");

                entity.Property(e => e.Tripcars).HasColumnName("tripcars");

                entity.Property(e => e.Tripdate).HasColumnName("tripdate");

                entity.Property(e => e.Trippeople).HasColumnName("trippeople");

                entity.HasOne(d => d.IdgeographicregionNavigation)
                    .WithMany(p => p.Statisticstrips)
                    .HasForeignKey(d => d.Idgeographicregion)
                    .HasConstraintName("statisticstrips_idgeographicregion_fkey");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("trips");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Fromhour).HasColumnName("fromhour");

                entity.Property(e => e.Idinitiatoraccount).HasColumnName("idinitiatoraccount");

                entity.Property(e => e.Idworktrip).HasColumnName("idworktrip");

                entity.Property(e => e.Iscurrent)
                    .HasColumnName("iscurrent")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Leftseats).HasColumnName("leftseats");

                entity.Property(e => e.Summary).HasColumnName("summary");

                entity.Property(e => e.Tohour).HasColumnName("tohour");

                entity.Property(e => e.Tripdate).HasColumnName("tripdate");

                entity.HasOne(d => d.IdinitiatoraccountNavigation)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.Idinitiatoraccount)
                    .HasConstraintName("trips_idinitiatoraccount_fkey");

                entity.HasOne(d => d.IdworktripNavigation)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.Idworktrip)
                    .HasConstraintName("trips_idworktrip_fkey");
            });

            modelBuilder.Entity<Tripparticipant>(entity =>
            {
                entity.ToTable("tripparticipants");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Idtrip).HasColumnName("idtrip");

                entity.Property(e => e.Isoccasion)
                    .HasColumnName("isoccasion")
                    .HasDefaultValueSql("false");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.Tripparticipants)
                    .HasForeignKey(d => d.Idaccount)
                    .HasConstraintName("tripparticipants_idaccount_fkey");

                entity.HasOne(d => d.IdtripNavigation)
                    .WithMany(p => p.Tripparticipants)
                    .HasForeignKey(d => d.Idtrip)
                    .HasConstraintName("tripparticipants_idtrip_fkey");
            });

            modelBuilder.Entity<Userextradatum>(entity =>
            {
                entity.ToTable("userextradata");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Method).HasColumnName("method");

                entity.Property(e => e.Origin).HasColumnName("origin");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.Tokendatajson).HasColumnName("tokendatajson");

                entity.HasOne(d => d.IdaccountNavigation)
                    .WithMany(p => p.Userextradata)
                    .HasForeignKey(d => d.Idaccount)
                    .HasConstraintName("userextradata_idaccount_fkey");
            });

            modelBuilder.Entity<Vaccountscollocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vaccountscollocations");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Distancefrom).HasColumnName("distancefrom");

                entity.Property(e => e.Distanceto).HasColumnName("distanceto");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Suggestedaccountid).HasColumnName("suggestedaccountid");

                entity.Property(e => e.Suggestedname).HasColumnName("suggestedname");

                entity.Property(e => e.Suggestedsurname).HasColumnName("suggestedsurname");

                entity.Property(e => e.Surname).HasColumnName("surname");
            });

            modelBuilder.Entity<Vaccountscollocationsworktrip>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vaccountscollocationsworktrip");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Distancefrom).HasColumnName("distancefrom");

                entity.Property(e => e.Distanceto).HasColumnName("distanceto");

                entity.Property(e => e.Fromhour).HasColumnName("fromhour");

                entity.Property(e => e.Latitudefrom).HasColumnName("latitudefrom");

                entity.Property(e => e.Latitudeto).HasColumnName("latitudeto");

                entity.Property(e => e.Longitudefrom).HasColumnName("longitudefrom");

                entity.Property(e => e.Longitudeto).HasColumnName("longitudeto");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Suggestedaccountid).HasColumnName("suggestedaccountid");

                entity.Property(e => e.Suggestedname).HasColumnName("suggestedname");

                entity.Property(e => e.Suggestedsurname).HasColumnName("suggestedsurname");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.Tohour).HasColumnName("tohour");
            });

            modelBuilder.Entity<Vacollocationsgeolocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vacollocationsgeolocations");

                entity.Property(e => e.Accountidcollocated).HasColumnName("accountidcollocated");

                entity.Property(e => e.Fromhour).HasColumnName("fromhour");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Isdriver).HasColumnName("isdriver");

                entity.Property(e => e.Latitudefrom).HasColumnName("latitudefrom");

                entity.Property(e => e.Latitudeto).HasColumnName("latitudeto");

                entity.Property(e => e.Longitudefrom).HasColumnName("longitudefrom");

                entity.Property(e => e.Longitudeto).HasColumnName("longitudeto");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Searchid).HasColumnName("searchid");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.Tohour).HasColumnName("tohour");
            });

            modelBuilder.Entity<Vaworktripgengeolocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vaworktripgengeolocations");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Fromhour).HasColumnName("fromhour");

                entity.Property(e => e.Isdriver).HasColumnName("isdriver");

                entity.Property(e => e.Latitudefrom).HasColumnName("latitudefrom");

                entity.Property(e => e.Latitudeto).HasColumnName("latitudeto");

                entity.Property(e => e.Longitudefrom).HasColumnName("longitudefrom");

                entity.Property(e => e.Longitudeto).HasColumnName("longitudeto");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Searchid).HasColumnName("searchid");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.Tohour).HasColumnName("tohour");
            });

            modelBuilder.Entity<Vcarowner>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vcarowner");

                entity.Property(e => e.Availableseats).HasColumnName("availableseats");

                entity.Property(e => e.Brand).HasColumnName("brand");

                entity.Property(e => e.Colour).HasColumnName("colour");

                entity.Property(e => e.Model).HasColumnName("model");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Registrationplate).HasColumnName("registrationplate");

                entity.Property(e => e.Rgb).HasColumnName("rgb");

                entity.Property(e => e.Surname).HasColumnName("surname");
            });

            modelBuilder.Entity<Vcollocationsgeolocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vcollocationsgeolocations");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Fromhour).HasColumnName("fromhour");

                entity.Property(e => e.Latitudefrom).HasColumnName("latitudefrom");

                entity.Property(e => e.Latitudeto).HasColumnName("latitudeto");

                entity.Property(e => e.Longitudefrom).HasColumnName("longitudefrom");

                entity.Property(e => e.Longitudeto).HasColumnName("longitudeto");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Searchid).HasColumnName("searchid");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.Tohour).HasColumnName("tohour");
            });

            modelBuilder.Entity<Vfriend>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vfriends");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Friendaccountid).HasColumnName("friendaccountid");

                entity.Property(e => e.Friendname).HasColumnName("friendname");

                entity.Property(e => e.Friendsurname).HasColumnName("friendsurname");

                entity.Property(e => e.Method).HasColumnName("method");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Surname).HasColumnName("surname");
            });

            modelBuilder.Entity<Vfriendsuggestion>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vfriendsuggestions");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Suggestedaccountid).HasColumnName("suggestedaccountid");

                entity.Property(e => e.Suggestedfriendid).HasColumnName("suggestedfriendid");

                entity.Property(e => e.Suggestedfriendname).HasColumnName("suggestedfriendname");

                entity.Property(e => e.Suggestedfriendsurname).HasColumnName("suggestedfriendsurname");

                entity.Property(e => e.Suggestedname).HasColumnName("suggestedname");

                entity.Property(e => e.Suggestedsurname).HasColumnName("suggestedsurname");

                entity.Property(e => e.Surname).HasColumnName("surname");
            });

            modelBuilder.Entity<Vinvitation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vinvitations");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Suggestedaccountid).HasColumnName("suggestedaccountid");

                entity.Property(e => e.Suggestedname).HasColumnName("suggestedname");

                entity.Property(e => e.Suggestedsurname).HasColumnName("suggestedsurname");

                entity.Property(e => e.Surname).HasColumnName("surname");
            });

            modelBuilder.Entity<Vtripsparticipant>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vtripsparticipants");

                entity.Property(e => e.Accountid).HasColumnName("accountid");

                entity.Property(e => e.Fromhour).HasColumnName("fromhour");

                entity.Property(e => e.Iscurrent).HasColumnName("iscurrent");

                entity.Property(e => e.Isoccasion).HasColumnName("isoccasion");

                entity.Property(e => e.Leftseats).HasColumnName("leftseats");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Suggestedaccountid).HasColumnName("suggestedaccountid");

                entity.Property(e => e.Suggestedname).HasColumnName("suggestedname");

                entity.Property(e => e.Suggestedsurname).HasColumnName("suggestedsurname");

                entity.Property(e => e.Summary).HasColumnName("summary");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.Tohour).HasColumnName("tohour");

                entity.Property(e => e.Tripdate).HasColumnName("tripdate");

                entity.Property(e => e.Tripid).HasColumnName("tripid");
            });

            modelBuilder.Entity<Vworktripgengeolocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vworktripgengeolocations");

                entity.Property(e => e.Accountidcollocated).HasColumnName("accountidcollocated");

                entity.Property(e => e.Fromhour).HasColumnName("fromhour");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Latitudefrom).HasColumnName("latitudefrom");

                entity.Property(e => e.Latitudeto).HasColumnName("latitudeto");

                entity.Property(e => e.Longitudefrom).HasColumnName("longitudefrom");

                entity.Property(e => e.Longitudeto).HasColumnName("longitudeto");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Searchid).HasColumnName("searchid");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.Property(e => e.Tohour).HasColumnName("tohour");
            });

            modelBuilder.Entity<Worktrip>(entity =>
            {
                entity.ToTable("worktrip");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acceptabledistance).HasColumnName("acceptabledistance");

                entity.Property(e => e.Cityfrom).HasColumnName("cityfrom");

                entity.Property(e => e.Cityto).HasColumnName("cityto");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Driverpassenger)
                    .HasColumnName("driverpassenger")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Fromhour).HasColumnName("fromhour");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Idgeographiclocationfrom).HasColumnName("idgeographiclocationfrom");

                entity.Property(e => e.Idgeographiclocationto).HasColumnName("idgeographiclocationto");

                entity.Property(e => e.Isuser).HasColumnName("isuser");

                entity.Property(e => e.Latitudefrom).HasColumnName("latitudefrom");

                entity.Property(e => e.Latitudeto).HasColumnName("latitudeto");

                entity.Property(e => e.Longitudefrom).HasColumnName("longitudefrom");

                entity.Property(e => e.Longitudeto).HasColumnName("longitudeto");

                entity.Property(e => e.Postcodefrom).HasColumnName("postcodefrom");

                entity.Property(e => e.Postcodeto).HasColumnName("postcodeto");

                entity.Property(e => e.Searchid).HasColumnName("searchid");

                entity.Property(e => e.Streetfrom).HasColumnName("streetfrom");

                entity.Property(e => e.Streetto).HasColumnName("streetto");

                entity.Property(e => e.Tohour).HasColumnName("tohour");

                entity.HasOne(d => d.IdgeographiclocationfromNavigation)
                    .WithMany(p => p.WorktripIdgeographiclocationfromNavigations)
                    .HasForeignKey(d => d.Idgeographiclocationfrom)
                    .HasConstraintName("worktrip_idgeographiclocationfrom_fkey");

                entity.HasOne(d => d.IdgeographiclocationtoNavigation)
                    .WithMany(p => p.WorktripIdgeographiclocationtoNavigations)
                    .HasForeignKey(d => d.Idgeographiclocationto)
                    .HasConstraintName("worktrip_idgeographiclocationto_fkey");
            });

            modelBuilder.Entity<Worktripgen>(entity =>
            {
                entity.ToTable("worktripgen");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Acceptabledistance).HasColumnName("acceptabledistance");

                entity.Property(e => e.Cityfrom).HasColumnName("cityfrom");

                entity.Property(e => e.Cityto).HasColumnName("cityto");

                entity.Property(e => e.Createdat)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("createdat")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Driverpassenger)
                    .HasColumnName("driverpassenger")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Fromhour).HasColumnName("fromhour");

                entity.Property(e => e.Idaccount).HasColumnName("idaccount");

                entity.Property(e => e.Idgeographiclocationfrom).HasColumnName("idgeographiclocationfrom");

                entity.Property(e => e.Idgeographiclocationto).HasColumnName("idgeographiclocationto");

                entity.Property(e => e.Isuser).HasColumnName("isuser");

                entity.Property(e => e.Latitudefrom).HasColumnName("latitudefrom");

                entity.Property(e => e.Latitudeto).HasColumnName("latitudeto");

                entity.Property(e => e.Longitudefrom).HasColumnName("longitudefrom");

                entity.Property(e => e.Longitudeto).HasColumnName("longitudeto");

                entity.Property(e => e.Postcodefrom).HasColumnName("postcodefrom");

                entity.Property(e => e.Postcodeto).HasColumnName("postcodeto");

                entity.Property(e => e.Searchid).HasColumnName("searchid");

                entity.Property(e => e.Streetfrom).HasColumnName("streetfrom");

                entity.Property(e => e.Streetto).HasColumnName("streetto");

                entity.Property(e => e.Tohour).HasColumnName("tohour");

                entity.HasOne(d => d.IdgeographiclocationfromNavigation)
                    .WithMany(p => p.WorktripgenIdgeographiclocationfromNavigations)
                    .HasForeignKey(d => d.Idgeographiclocationfrom)
                    .HasConstraintName("worktripgen_idgeographiclocationfrom_fkey");

                entity.HasOne(d => d.IdgeographiclocationtoNavigation)
                    .WithMany(p => p.WorktripgenIdgeographiclocationtoNavigations)
                    .HasForeignKey(d => d.Idgeographiclocationto)
                    .HasConstraintName("worktripgen_idgeographiclocationto_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
