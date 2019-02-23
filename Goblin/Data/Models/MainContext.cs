﻿using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Goblin.Data.Models
{
    public class MainContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Remind> Reminds { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options) { }

        public User[] GetUsers()
        {
            return Users.AsNoTracking().ToArray();
        }

        public long[] GetAdmins()
        {
            return Users.Where(x => x.IsAdmin).AsNoTracking().Select(x => x.Vk).ToArray();
        }

        public User[] GetWeatherUsers()
        {
            return Users.Where(x => x.Weather && x.City != "").AsNoTracking().ToArray();
        }

        public User[] GetScheduleUsers()
        {
            return Users.Where(x => x.Schedule && x.Group != 0).AsNoTracking().ToArray();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .Property(b => b.Weather)
                        .HasDefaultValue(false)
                        .ValueGeneratedNever();

            modelBuilder.Entity<User>()
                        .Property(b => b.Schedule)
                        .HasDefaultValue(false)
                        .ValueGeneratedNever();

            modelBuilder.Entity<User>()
                        .Property(b => b.City)
                        .IsRequired(false);

            modelBuilder.Entity<User>()
                        .Property(b => b.Group)
                        .HasDefaultValue(0);

            modelBuilder.Entity<User>()
                        .Property(b => b.Schedule)
                        .HasDefaultValue(false);

            modelBuilder.Entity<User>()
                        .Property(b => b.Weather)
                        .HasDefaultValue(false);
        }
    }
}