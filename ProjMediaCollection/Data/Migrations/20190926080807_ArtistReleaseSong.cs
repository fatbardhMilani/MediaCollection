using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class ArtistReleaseSong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Artist",
                table: "Songs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Release",
                table: "Songs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Artist",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Release",
                table: "Songs");
        }
    }
}
