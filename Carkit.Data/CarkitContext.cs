using Carkit.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Carkit.Data
{
    public class CarkitContext : DbContext
    {
        public DbSet<ProducerDetails> ProducersDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RepairShop> RepairShops { get; set; }

        public CarkitContext(DbContextOptions<CarkitContext> options)
                        : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SettingPresetData(modelBuilder);

            /*modelBuilder.Entity<CheckingAccount>()
                .HasOne(a => a.Bank)
                .WithMany();

            modelBuilder.Entity<SigningPerson>()
                .HasOne(a => a.Person)
                .WithMany();
            modelBuilder.Entity<SigningPerson>()
                .HasOne(a => a.Position)
                .WithMany();

            modelBuilder.Entity<Person>()
                .Property(i => i.Sex)
                    .HasConversion(
                        s => s.ToString(),
                        s => Enum.Parse<Sex>(s));

            modelBuilder.Entity<Person>()
                .HasOne(p => p.Branch)
                .WithMany(b => b.People);

            modelBuilder.Entity<PersonPosition>()
                .HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<Branch>()
                .Property(i => i.Code)
                    .HasDefaultValue("000");

            modelBuilder.Entity<CheckingAccount>()
                .HasQueryFilter(itm => !itm.IsDeleted);

            modelBuilder.Entity<SigningPerson>()
                .HasQueryFilter(itm => !itm.IsDeleted);

            modelBuilder.Entity<MaterialProperty>()
                .HasQueryFilter(itm => !itm.IsDeleted);

            modelBuilder.Entity<Material>()
                .Property(i => i.UnitProduction)
                    .HasConversion(
                        s => s.ToString(),
                        s => Enum.Parse<Unit>(s));

            modelBuilder.Entity<Material>()
                .Property(i => i.UnitWarehouse)
                    .HasConversion(
                        s => s.ToString(),
                        s => Enum.Parse<Unit>(s));

            modelBuilder.Entity<MaterialProperty>()
                .Property(i => i.Unit)
                    .HasConversion(
                        s => s.ToString(),
                        s => Enum.Parse<Unit>(s));

            modelBuilder.Entity<MaterialProperty>()
                .Property(i => i.Property)
                    .HasConversion(
                        s => s.ToString(),
                        s => Enum.Parse<UnitProperty>(s));*/
        }

        private void SettingPresetData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(new[]
                {
                    new Role { Id = 1, IsDeleted = false, Name = "admin" },
                    new Role {Id = 2, IsDeleted = false, Name = "visitor"}
                });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1, IsDeleted = false, Name = "Администратор", Password = "111", Phone = "111", RoleId = 1
            });
        }
    }
}
