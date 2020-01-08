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
        public DbSet<Detail> Details { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RepairShop> RepairShops { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ModelCar> ModelCars { get; set; }
        public DbSet<CarCard> CarCards { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<WorkEffort> WorkEfforts { get; set; }
        public DbSet<LinkedDetail> LinkedDetails { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<WorkForCar> WorkForCars { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LinkedOrderDetail> LinkedOrderDetails { get; set; }
        public DbSet<LinkedWorkForCarWork> RecomendedWorks { get; set; }

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

            // WorkEffort
            modelBuilder.Entity<WorkEffort>()
                .HasKey(t => new { t.WorkId, t.ModelCarId });

            modelBuilder.Entity<WorkEffort>()
                .HasOne(sc => sc.Work)
                .WithMany(s => s.WorkEfforts)
                .HasForeignKey(sc => sc.WorkId);

            modelBuilder.Entity<WorkEffort>()
                .HasOne(sc => sc.Model)
                .WithMany(c => c.WorkEfforts)
                .HasForeignKey(sc => sc.ModelCarId);


            // LinkedDetail
            modelBuilder.Entity<LinkedDetail>()
                .HasKey(t => new { t.DetailId, t.ModelCarId });

            modelBuilder.Entity<LinkedDetail>()
                .HasOne(sc => sc.Detail)
                .WithMany(s => s.LinkedDetails)
                .HasForeignKey(sc => sc.DetailId);

            modelBuilder.Entity<LinkedDetail>()
                .HasOne(sc => sc.Model)
                .WithMany(c => c.LinkedDetails)
                .HasForeignKey(sc => sc.ModelCarId);

            // LinkedOrderDetail
            modelBuilder.Entity<LinkedOrderDetail>()
                .HasKey(t => new { t.DetailId, t.OrderId });

            modelBuilder.Entity<LinkedOrderDetail>()
                .HasOne(sc => sc.Detail)
                .WithMany(s => s.LinkedOrderDetails)
                .HasForeignKey(sc => sc.DetailId);

            modelBuilder.Entity<LinkedOrderDetail>()
                .HasOne(sc => sc.Order)
                .WithMany(c => c.LinkedOrderDetails)
                .HasForeignKey(sc => sc.OrderId);


            // LinkedWorkForCarWork
            modelBuilder.Entity<LinkedWorkForCarWork>()
                .HasKey(t => new { t.WorkForCarId, t.WorkId });

            modelBuilder.Entity<LinkedWorkForCarWork>()
                .HasOne(sc => sc.WorkForCar)
                .WithMany(s => s.RecomendedWorks)
                .HasForeignKey(sc => sc.WorkForCarId);

            modelBuilder.Entity<LinkedWorkForCarWork>()
                .HasOne(sc => sc.Work)
                .WithMany(c => c.RecomendedWorks)
                .HasForeignKey(sc => sc.WorkId);



            // WorkForCar
            /*modelBuilder.Entity<WorkForCar>()
                .HasKey(t => new { t.WorkId, t.CarCardId });

            modelBuilder.Entity<WorkForCar>()
                .HasOne(sc => sc.Work)
                .WithMany(s => s.WorkForCars)
                .HasForeignKey(sc => sc.WorkId);

            modelBuilder.Entity<WorkForCar>()
                .HasOne(sc => sc.CarCard)
                .WithMany(c => c.WorkForCars)
                .HasForeignKey(sc => sc.CarCardId);*/


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

            modelBuilder.Entity<Unit>().HasData(new[]
            {
                new Unit { Id = 1, IsDeleted = false, Name = "шт.", FullName = "штука" },
                new Unit { Id = 2, IsDeleted = false, Name = "л.", FullName = "литр" }
            });



            // test
            modelBuilder.Entity<Producer>()
                .HasData(new Producer
                {
                    Id = 1,
                    IsDeleted = false,
                    Name = "BMW"
                });

            modelBuilder.Entity<ModelCar>()
                .HasData(new ModelCar
                { 
                    Id = 1, IsDeleted = false, Name = "X6", ProducerId = 1
                });
        }
    }
}
