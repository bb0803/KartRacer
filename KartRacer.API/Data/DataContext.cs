using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using KartRacer.API.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using KartRacer.API.Models.User;

namespace KartRacer.API.Data
{
    public partial class DataContext: IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Chassis> Chassis { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<DriverSetting> DriverSettings { get; set; } = null!;
        public DbSet<Engine> Engines { get; set; } = null!;
        public DbSet<Entry> Entries { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<EventSession> EventSessions { get; set; } = null!;
        public DbSet<Part> Parts { get; set; } = null!;
        public DbSet<RaceGrid> RaceGrids { get; set; } = null!;
        public DbSet<Tyre> Tyres { get; set; } = null!;
        public DbSet<Series> Series { get; set; } = null!;
        public DbSet<SeriesPoint> SeriesPoints { get; set; } = null!;
        public DbSet<Session> Sessions { get; set; } = null!;
        public DbSet<SessionLapTime> SessionLapTimes { get; set; } = null!;
        public DbSet<SetupFavourite> SetupFavourites { get; set; } = null!;
        public DbSet<Setup> Setups { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<UserSetting> UserSettings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // done in data annonations
            //modelBuilder.Entity<Shareholder>(entity =>
            //{
            //    entity.Property(e => e.Name).HasMaxLength(250);

            //    entity.Property(e => e.Description).HasMaxLength(50);

            //});

            //modelBuilder.Entity<LookupValue>().HasKey(lv => new { lv.Type, lv.Key });

            //modelBuilder.Entity<Book>(entity =>
            //{
            //    entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EA09FAB742")
            //        .IsUnique();

            //    entity.Property(e => e.Image).HasMaxLength(250);

            //    entity.Property(e => e.Isbn)
            //        .HasMaxLength(50)
            //        .HasColumnName("ISBN");

            //    entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            //    entity.Property(e => e.Summary).HasMaxLength(250);

            //    entity.Property(e => e.Title).HasMaxLength(50);

            //    entity.HasOne(d => d.Author)
            //        .WithMany(p => p.Books)
            //        .HasForeignKey(d => d.AuthorId)
            //        .HasConstraintName("FK_Books_ToTable");
            //}
            //);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER",
                    Id = "8343074e-8623-4e1a-b0c1-84fb8678c8f3"
                },
                new IdentityRole
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = "c7ac6cfe-1f10-4baf-b604-cde350db9554"
                }
            );

            var hasher = new PasswordHasher<ApplicationUser>();

            //modelBuilder.Entity<ApplicationUser>().HasData(
            //    new ApplicationUser
            //    {
            //        Id = "8e448afa-f008-446e-a52f-13c449803c2e",
            //        Email = "admin@project51.com",
            //        NormalizedEmail = "ADMIN@project51.COM",
            //        UserName = "admin@project51.com",
            //        FirstName = "Admin",
            //        FullName = "Admin",
            //        NormalizedUserName = "ADMIN@project51.COM",
            //        PasswordHash = hasher.HashPassword(null, "P@ssword1")
            //    },
            //    new ApplicationUser
            //    {
            //        Id = "30a24107-d279-4e37-96fd-01af5b38cb27",
            //        Email = "user@project51.com",
            //        NormalizedEmail = "USER@Project51.COM",
            //        UserName = "user@Project51.com",
            //        FirstName = "User",
            //        FullName = "User",
            //        NormalizedUserName = "USER@Project51.COM",
            //        PasswordHash = hasher.HashPassword(null, "P@ssword1")
            //    }
            //);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "8343074e-8623-4e1a-b0c1-84fb8678c8f3",
                    UserId = "30a24107-d279-4e37-96fd-01af5b38cb27"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "c7ac6cfe-1f10-4baf-b604-cde350db9554",
                    UserId = "8e448afa-f008-446e-a52f-13c449803c2e"
                }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
