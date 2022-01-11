using Microsoft.EntityFrameworkCore.Migrations;

namespace DalLibrary.Migrations
{
    public partial class AFId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "advert_features",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "id",
                table: "advert_features");
        }
    }
}
