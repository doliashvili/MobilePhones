using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WandioMobilePhones.Infrastructure.Migrations
{
    public partial class addSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "PhoneMobileAggregateId", "PhotoUrl" },
                values: new object[,]
                {
                    { new Guid("1852010e-d095-4468-a882-b481dc444501"), null, "fb.com" },
                    { new Guid("a6aa3c2c-80ff-4407-a10d-49aeb8966a3a"), null, "fb.com" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "Manufacturer", "Memory", "Name", "OS", "Price", "Procesor", "ScreenSizeAndResolution", "Size", "Video", "Weight" },
                values: new object[,]
                {
                    { new Guid("55dc3d14-5b55-4da2-9f69-b864a72c6cb2"), "Apple", "32gb", "IPhone 10", "IOS", 1000m, "AppleI8Proccess", "500px", "XL", "youtube.com", 200.5 },
                    { new Guid("135726ed-aede-48b7-849e-31350954613a"), "Apple", "32gb", "IPhone 11", "IOS", 1500m, "AppleI8Proccess", "500px", "X", "youtube.com", 200.5 },
                    { new Guid("22a5963f-327b-4c43-8d79-00a82375bd53"), "Samsung", "64gb", "Galaxy", "Android", 500m, "SAMSUNGI8Proccess", "500px", "XL", "youtube.com", 200.5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("1852010e-d095-4468-a882-b481dc444501"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("a6aa3c2c-80ff-4407-a10d-49aeb8966a3a"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("135726ed-aede-48b7-849e-31350954613a"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("22a5963f-327b-4c43-8d79-00a82375bd53"));

            migrationBuilder.DeleteData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: new Guid("55dc3d14-5b55-4da2-9f69-b864a72c6cb2"));
        }
    }
}
