using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class urlTrailer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UrlTrailer",
                table: "Movies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrlTrailer",
                table: "Movies");
        }
    }
}
