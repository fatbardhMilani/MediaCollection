using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class MoviePlaylist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_AspNetUsers_UserId",
                table: "UserMovies");

            migrationBuilder.DropIndex(
                name: "IX_UserMovies_UserId",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserMovies");

            migrationBuilder.AddColumn<int>(
                name: "MoviePlaylistId",
                table: "UserMovies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MoviePlaylists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePlaylists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviePlaylists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_MoviePlaylistId",
                table: "UserMovies",
                column: "MoviePlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_MoviePlaylists_UserId",
                table: "MoviePlaylists",
                column: "UserId");

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

            migrationBuilder.DropTable(
                name: "MoviePlaylists");

            migrationBuilder.DropIndex(
                name: "IX_UserMovies_MoviePlaylistId",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "MoviePlaylistId",
                table: "UserMovies");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserMovies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_UserId",
                table: "UserMovies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_AspNetUsers_UserId",
                table: "UserMovies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
