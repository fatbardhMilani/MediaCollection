using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class gfdg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_Movies_MovieFK",
                table: "UserMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_MoviePlaylists_MoviePlaylistFK",
                table: "UserMovies");

            migrationBuilder.DropIndex(
                name: "IX_UserMovies_MovieFK",
                table: "UserMovies");

            migrationBuilder.DropIndex(
                name: "IX_UserMovies_MoviePlaylistFK",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "MovieFK",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "MoviePlaylistFK",
                table: "UserMovies");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_MoviePlaylistId",
                table: "UserMovies",
                column: "MoviePlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_MoviePlaylists_MoviePlaylistId",
                table: "UserMovies",
                column: "MoviePlaylistId",
                principalTable: "MoviePlaylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_MoviePlaylists_MoviePlaylistId",
                table: "UserMovies");

            migrationBuilder.DropIndex(
                name: "IX_UserMovies_MoviePlaylistId",
                table: "UserMovies");

            migrationBuilder.AddColumn<int>(
                name: "MovieFK",
                table: "UserMovies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MoviePlaylistFK",
                table: "UserMovies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_MovieFK",
                table: "UserMovies",
                column: "MovieFK");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_MoviePlaylistFK",
                table: "UserMovies",
                column: "MoviePlaylistFK");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_Movies_MovieFK",
                table: "UserMovies",
                column: "MovieFK",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_MoviePlaylists_MoviePlaylistFK",
                table: "UserMovies",
                column: "MoviePlaylistFK",
                principalTable: "MoviePlaylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
