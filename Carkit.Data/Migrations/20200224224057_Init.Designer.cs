﻿// <auto-generated />
using System;
using Carkit.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Carkit.Data.Migrations
{
    [DbContext(typeof(CarkitContext))]
    [Migration("20200224224057_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Carkit.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarCardId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("Kilometrage");

                    b.Property<int?>("UserId");

                    b.Property<string>("VIN");

                    b.HasKey("Id");

                    b.HasIndex("CarCardId");

                    b.HasIndex("UserId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("Carkit.Data.Models.CarCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("ModelCarId");

                    b.Property<string>("VINMask");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("ModelCarId");

                    b.ToTable("CarCards");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            ModelCarId = 1,
                            Year = 2013
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            ModelCarId = 2,
                            Year = 2015
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            ModelCarId = 1,
                            Year = 2020
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            ModelCarId = 2,
                            Year = 2019
                        });
                });

            modelBuilder.Entity("Carkit.Data.Models.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cost");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<int>("ProducerDetailsId");

                    b.Property<int>("WorkId");

                    b.HasKey("Id");

                    b.HasIndex("ProducerDetailsId");

                    b.HasIndex("WorkId");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cost = 200m,
                            IsDeleted = false,
                            Name = "Масло 2",
                            ProducerDetailsId = 2,
                            WorkId = 2
                        },
                        new
                        {
                            Id = 2,
                            Cost = 300m,
                            IsDeleted = false,
                            Name = "Масло 3",
                            ProducerDetailsId = 3,
                            WorkId = 2
                        },
                        new
                        {
                            Id = 3,
                            Cost = 500m,
                            IsDeleted = false,
                            Name = "Масло 1",
                            ProducerDetailsId = 1,
                            WorkId = 2
                        },
                        new
                        {
                            Id = 4,
                            Cost = 2000m,
                            IsDeleted = false,
                            Name = "Зимняя резина",
                            ProducerDetailsId = 4,
                            WorkId = 3
                        },
                        new
                        {
                            Id = 5,
                            Cost = 25000m,
                            IsDeleted = false,
                            Name = "Краска",
                            ProducerDetailsId = 2,
                            WorkId = 4
                        });
                });

            modelBuilder.Entity("Carkit.Data.Models.LinkedDetail", b =>
                {
                    b.Property<int>("DetailId");

                    b.Property<int>("ModelCarId");

                    b.Property<double>("Count");

                    b.Property<int>("Id");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsOriginal");

                    b.Property<int>("UnitId");

                    b.HasKey("DetailId", "ModelCarId");

                    b.HasIndex("ModelCarId");

                    b.HasIndex("UnitId");

                    b.ToTable("LinkedDetails");

                    b.HasData(
                        new
                        {
                            DetailId = 1,
                            ModelCarId = 1,
                            Count = 1.0,
                            Id = 1,
                            IsDeleted = false,
                            IsOriginal = true,
                            UnitId = 1
                        },
                        new
                        {
                            DetailId = 2,
                            ModelCarId = 1,
                            Count = 1.0,
                            Id = 2,
                            IsDeleted = false,
                            IsOriginal = false,
                            UnitId = 1
                        },
                        new
                        {
                            DetailId = 3,
                            ModelCarId = 1,
                            Count = 1.0,
                            Id = 3,
                            IsDeleted = false,
                            IsOriginal = false,
                            UnitId = 1
                        },
                        new
                        {
                            DetailId = 2,
                            ModelCarId = 2,
                            Count = 1.0,
                            Id = 2,
                            IsDeleted = false,
                            IsOriginal = true,
                            UnitId = 1
                        });
                });

            modelBuilder.Entity("Carkit.Data.Models.LinkedOrderDetail", b =>
                {
                    b.Property<int>("DetailId");

                    b.Property<int>("OrderId");

                    b.Property<double>("Count");

                    b.Property<int>("Id");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("UnitId");

                    b.HasKey("DetailId", "OrderId");

                    b.HasIndex("OrderId");

                    b.HasIndex("UnitId");

                    b.ToTable("LinkedOrderDetails");
                });

            modelBuilder.Entity("Carkit.Data.Models.LinkedWorkForCarWork", b =>
                {
                    b.Property<int>("WorkForCarId");

                    b.Property<int>("WorkId");

                    b.Property<int>("Id");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("WorkForCarId", "WorkId");

                    b.HasIndex("WorkId");

                    b.ToTable("RecomendedWorks");
                });

            modelBuilder.Entity("Carkit.Data.Models.ModelCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("ProducerId");

                    b.HasKey("Id");

                    b.HasIndex("ProducerId");

                    b.ToTable("ModelCars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "X6",
                            ProducerId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "730",
                            ProducerId = 1
                        });
                });

            modelBuilder.Entity("Carkit.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId");

                    b.Property<decimal>("Cost");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("RepairShopId");

                    b.Property<double>("TimePeriod");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("RepairShopId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Carkit.Data.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("County");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Producers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "BMW"
                        });
                });

            modelBuilder.Entity("Carkit.Data.Models.ProducerDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("TrustLevel");

                    b.HasKey("Id");

                    b.ToTable("ProducersDetails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Производитель1",
                            TrustLevel = 10
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Производитель2",
                            TrustLevel = 8
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Производитель3",
                            TrustLevel = 7
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Производитель4",
                            TrustLevel = 5
                        });
                });

            modelBuilder.Entity("Carkit.Data.Models.RepairShop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("RepairShops");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Какая-то адресс",
                            IsDeleted = false
                        });
                });

            modelBuilder.Entity("Carkit.Data.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "visitor"
                        });
                });

            modelBuilder.Entity("Carkit.Data.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FullName");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Units");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FullName = "штука",
                            IsDeleted = false,
                            Name = "шт."
                        },
                        new
                        {
                            Id = 2,
                            FullName = "литр",
                            IsDeleted = false,
                            Name = "л."
                        });
                });

            modelBuilder.Entity("Carkit.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Phone")
                        .IsRequired();

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Администратор",
                            Password = "111",
                            Phone = "111",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Carkit.Data.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Hours");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Works");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Hours = 4.0,
                            IsDeleted = false,
                            Name = "Замена колодок"
                        },
                        new
                        {
                            Id = 2,
                            Hours = 0.25,
                            IsDeleted = false,
                            Name = "Замена масла"
                        },
                        new
                        {
                            Id = 3,
                            Hours = 2.0,
                            IsDeleted = false,
                            Name = "Смена резины"
                        },
                        new
                        {
                            Id = 4,
                            Hours = 24.0,
                            IsDeleted = false,
                            Name = "Покраска"
                        });
                });

            modelBuilder.Entity("Carkit.Data.Models.WorkEffort", b =>
                {
                    b.Property<int>("WorkId");

                    b.Property<int>("ModelCarId");

                    b.Property<double>("Hours");

                    b.Property<int>("Id");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("WorkId", "ModelCarId");

                    b.HasIndex("ModelCarId");

                    b.ToTable("WorkEfforts");
                });

            modelBuilder.Entity("Carkit.Data.Models.WorkForCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarCardId");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("Kilometrage");

                    b.HasKey("Id");

                    b.HasIndex("CarCardId");

                    b.ToTable("WorkForCars");
                });

            modelBuilder.Entity("Carkit.Data.Models.Car", b =>
                {
                    b.HasOne("Carkit.Data.Models.CarCard", "CarCard")
                        .WithMany("Cars")
                        .HasForeignKey("CarCardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Carkit.Data.Models.User", "User")
                        .WithMany("Cars")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Carkit.Data.Models.CarCard", b =>
                {
                    b.HasOne("Carkit.Data.Models.ModelCar", "Model")
                        .WithMany()
                        .HasForeignKey("ModelCarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Carkit.Data.Models.Detail", b =>
                {
                    b.HasOne("Carkit.Data.Models.ProducerDetails", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerDetailsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Carkit.Data.Models.Work", "Work")
                        .WithMany("Details")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Carkit.Data.Models.LinkedDetail", b =>
                {
                    b.HasOne("Carkit.Data.Models.Detail", "Detail")
                        .WithMany("LinkedDetails")
                        .HasForeignKey("DetailId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Carkit.Data.Models.ModelCar", "Model")
                        .WithMany("LinkedDetails")
                        .HasForeignKey("ModelCarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Carkit.Data.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Carkit.Data.Models.LinkedOrderDetail", b =>
                {
                    b.HasOne("Carkit.Data.Models.Detail", "Detail")
                        .WithMany("LinkedOrderDetails")
                        .HasForeignKey("DetailId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Carkit.Data.Models.Order", "Order")
                        .WithMany("LinkedOrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Carkit.Data.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Carkit.Data.Models.LinkedWorkForCarWork", b =>
                {
                    b.HasOne("Carkit.Data.Models.WorkForCar", "WorkForCar")
                        .WithMany("RecomendedWorks")
                        .HasForeignKey("WorkForCarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Carkit.Data.Models.Work", "Work")
                        .WithMany("RecomendedWorks")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Carkit.Data.Models.ModelCar", b =>
                {
                    b.HasOne("Carkit.Data.Models.Producer", "Producer")
                        .WithMany()
                        .HasForeignKey("ProducerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Carkit.Data.Models.Order", b =>
                {
                    b.HasOne("Carkit.Data.Models.Car", "Car")
                        .WithMany("Orders")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Carkit.Data.Models.RepairShop", "RepairShop")
                        .WithMany("Orders")
                        .HasForeignKey("RepairShopId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Carkit.Data.Models.User", b =>
                {
                    b.HasOne("Carkit.Data.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Carkit.Data.Models.WorkEffort", b =>
                {
                    b.HasOne("Carkit.Data.Models.ModelCar", "Model")
                        .WithMany("WorkEfforts")
                        .HasForeignKey("ModelCarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Carkit.Data.Models.Work", "Work")
                        .WithMany("WorkEfforts")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Carkit.Data.Models.WorkForCar", b =>
                {
                    b.HasOne("Carkit.Data.Models.CarCard", "CarCard")
                        .WithMany("WorkForCars")
                        .HasForeignKey("CarCardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
