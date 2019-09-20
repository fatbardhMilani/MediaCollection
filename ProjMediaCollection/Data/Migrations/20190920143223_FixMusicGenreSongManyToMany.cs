using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class FixMusicGenreSongManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicGenres_Songs_SongId",
                table: "MusicGenres");

            migrationBuilder.DropIndex(
                name: "IX_MusicGenres_SongId",
                table: "MusicGenres");

            migrationBuilder.DropColumn(
                name: "SongId",
                table: "MusicGenres");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SongId",
                table: "MusicGenres",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicGenres_SongId",
                table: "MusicGenres",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicGenres_Songs_SongId",
                table: "MusicGenres",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
