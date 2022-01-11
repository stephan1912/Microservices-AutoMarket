using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DalLibrary.Migrations
{
    public partial class BlobImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "name",
                table: "images");

            migrationBuilder.AddColumn<byte[]>(
                name: "imagedata",
                table: "images",
                type: "MediumBlob",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imagedata",
                table: "images");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "images",
                type: "varchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
