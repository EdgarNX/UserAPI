using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UserAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { new Guid("6b1eea43-5597-45a6-bdea-e68c60564247"), "Edgar", "123456" },
                    { new Guid("a052a63d-fa53-44d5-a197-83089818a676"), "Ianko", "123456" },
                    { new Guid("cb554ed6-8fa7-4b8d-8d90-55cc6a3e0074"), "Fernando", "123456" },
                    { new Guid("8e2f0a16-4c09-44c7-ba56-8dc62dfd792d"), "Paul", "123456" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
