using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WandioMobilePhones.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: true),
                    Manufacturer = table.Column<string>(maxLength: 60, nullable: true),
                    Size = table.Column<string>(maxLength: 60, nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    ScreenSizeAndResolution = table.Column<string>(maxLength: 60, nullable: true),
                    Procesor = table.Column<string>(maxLength: 60, nullable: true),
                    Memory = table.Column<string>(maxLength: 60, nullable: true),
                    OS = table.Column<string>(maxLength: 40, nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Video = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PhotoUrl = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneMobileAggregateId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Phones_PhoneMobileAggregateId",
                        column: x => x.PhoneMobileAggregateId,
                        principalTable: "Phones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_PhoneMobileAggregateId",
                table: "Images",
                column: "PhoneMobileAggregateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Phones");
        }
    }
}
