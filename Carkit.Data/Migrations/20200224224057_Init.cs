using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Carkit.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    County = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProducersDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    TrustLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducersDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepairShops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairShops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Hours = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ModelCars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ProducerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelCars_Producers_ProducerId",
                        column: x => x.ProducerId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Cost = table.Column<decimal>(nullable: false),
                    ProducerDetailsId = table.Column<int>(nullable: false),
                    WorkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_ProducersDetails_ProducerDetailsId",
                        column: x => x.ProducerDetailsId,
                        principalTable: "ProducersDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Details_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarCards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    VINMask = table.Column<string>(nullable: true),
                    ModelCarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarCards_ModelCars_ModelCarId",
                        column: x => x.ModelCarId,
                        principalTable: "ModelCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkEfforts",
                columns: table => new
                {
                    WorkId = table.Column<int>(nullable: false),
                    ModelCarId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Hours = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkEfforts", x => new { x.WorkId, x.ModelCarId });
                    table.ForeignKey(
                        name: "FK_WorkEfforts_ModelCars_ModelCarId",
                        column: x => x.ModelCarId,
                        principalTable: "ModelCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkEfforts_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkedDetails",
                columns: table => new
                {
                    DetailId = table.Column<int>(nullable: false),
                    ModelCarId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsOriginal = table.Column<bool>(nullable: false),
                    Count = table.Column<double>(nullable: false),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedDetails", x => new { x.DetailId, x.ModelCarId });
                    table.ForeignKey(
                        name: "FK_LinkedDetails_Details_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkedDetails_ModelCars_ModelCarId",
                        column: x => x.ModelCarId,
                        principalTable: "ModelCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkedDetails_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CarCardId = table.Column<int>(nullable: false),
                    Kilometrage = table.Column<int>(nullable: false),
                    VIN = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarCards_CarCardId",
                        column: x => x.CarCardId,
                        principalTable: "CarCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WorkForCars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CarCardId = table.Column<int>(nullable: false),
                    Kilometrage = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkForCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkForCars_CarCards_CarCardId",
                        column: x => x.CarCardId,
                        principalTable: "CarCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CarId = table.Column<int>(nullable: false),
                    RepairShopId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    TimePeriod = table.Column<double>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_RepairShops_RepairShopId",
                        column: x => x.RepairShopId,
                        principalTable: "RepairShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecomendedWorks",
                columns: table => new
                {
                    WorkForCarId = table.Column<int>(nullable: false),
                    WorkId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecomendedWorks", x => new { x.WorkForCarId, x.WorkId });
                    table.ForeignKey(
                        name: "FK_RecomendedWorks_WorkForCars_WorkForCarId",
                        column: x => x.WorkForCarId,
                        principalTable: "WorkForCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecomendedWorks_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LinkedOrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    DetailId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Count = table.Column<double>(nullable: false),
                    UnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedOrderDetails", x => new { x.DetailId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_LinkedOrderDetails_Details_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Details",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkedOrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LinkedOrderDetails_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "County", "IsDeleted", "Name" },
                values: new object[] { 1, null, false, "BMW" });

            migrationBuilder.InsertData(
                table: "ProducersDetails",
                columns: new[] { "Id", "IsDeleted", "Name", "TrustLevel" },
                values: new object[,]
                {
                    { 1, false, "Производитель1", 10 },
                    { 2, false, "Производитель2", 8 },
                    { 3, false, "Производитель3", 7 },
                    { 4, false, "Производитель4", 5 }
                });

            migrationBuilder.InsertData(
                table: "RepairShops",
                columns: new[] { "Id", "Address", "IsDeleted" },
                values: new object[] { 1, "Какая-то адресс", false });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "admin" },
                    { 2, false, "visitor" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "FullName", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, "штука", false, "шт." },
                    { 2, "литр", false, "л." }
                });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "Id", "Hours", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 4.0, false, "Замена колодок" },
                    { 2, 0.25, false, "Замена масла" },
                    { 3, 2.0, false, "Смена резины" },
                    { 4, 24.0, false, "Покраска" }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "Cost", "IsDeleted", "Name", "ProducerDetailsId", "WorkId" },
                values: new object[,]
                {
                    { 1, 200m, false, "Масло 2", 2, 2 },
                    { 2, 300m, false, "Масло 3", 3, 2 },
                    { 3, 500m, false, "Масло 1", 1, 2 },
                    { 4, 2000m, false, "Зимняя резина", 4, 3 },
                    { 5, 25000m, false, "Краска", 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "ModelCars",
                columns: new[] { "Id", "IsDeleted", "Name", "ProducerId" },
                values: new object[,]
                {
                    { 1, false, "X6", 1 },
                    { 2, false, "730", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "IsDeleted", "Name", "Password", "Phone", "RoleId" },
                values: new object[] { 1, false, "Администратор", "111", "111", 1 });

            migrationBuilder.InsertData(
                table: "CarCards",
                columns: new[] { "Id", "IsDeleted", "ModelCarId", "VINMask", "Year" },
                values: new object[,]
                {
                    { 1, false, 1, null, 2013 },
                    { 3, false, 1, null, 2020 },
                    { 2, false, 2, null, 2015 },
                    { 4, false, 2, null, 2019 }
                });

            migrationBuilder.InsertData(
                table: "LinkedDetails",
                columns: new[] { "DetailId", "ModelCarId", "Count", "Id", "IsDeleted", "IsOriginal", "UnitId" },
                values: new object[,]
                {
                    { 1, 1, 1.0, 1, false, true, 1 },
                    { 2, 1, 1.0, 2, false, false, 1 },
                    { 2, 2, 1.0, 2, false, true, 1 },
                    { 3, 1, 1.0, 3, false, false, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarCards_ModelCarId",
                table: "CarCards",
                column: "ModelCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarCardId",
                table: "Cars",
                column: "CarCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_UserId",
                table: "Cars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_ProducerDetailsId",
                table: "Details",
                column: "ProducerDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_WorkId",
                table: "Details",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedDetails_ModelCarId",
                table: "LinkedDetails",
                column: "ModelCarId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedDetails_UnitId",
                table: "LinkedDetails",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedOrderDetails_OrderId",
                table: "LinkedOrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedOrderDetails_UnitId",
                table: "LinkedOrderDetails",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelCars_ProducerId",
                table: "ModelCars",
                column: "ProducerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CarId",
                table: "Orders",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_RepairShopId",
                table: "Orders",
                column: "RepairShopId");

            migrationBuilder.CreateIndex(
                name: "IX_RecomendedWorks_WorkId",
                table: "RecomendedWorks",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkEfforts_ModelCarId",
                table: "WorkEfforts",
                column: "ModelCarId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkForCars_CarCardId",
                table: "WorkForCars",
                column: "CarCardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LinkedDetails");

            migrationBuilder.DropTable(
                name: "LinkedOrderDetails");

            migrationBuilder.DropTable(
                name: "RecomendedWorks");

            migrationBuilder.DropTable(
                name: "WorkEfforts");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "WorkForCars");

            migrationBuilder.DropTable(
                name: "ProducersDetails");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "RepairShops");

            migrationBuilder.DropTable(
                name: "CarCards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ModelCars");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Producers");
        }
    }
}
