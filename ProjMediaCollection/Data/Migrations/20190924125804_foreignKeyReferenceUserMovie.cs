using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class foreignKeyReferenceUserMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_Movies_MovieFK",
                table: "UserMovies");

            migrationBuilder.DropIndex(
                name: "IX_UserMovies_MovieFK",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "MovieFK",
                table: "UserMovies");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_MovieId",
                table: "UserMovies",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_Movies_MovieId",
                table: "UserMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_Movies_MovieId",
                table: "UserMovies");

            migrationBuilder.DropIndex(
                name: "IX_UserMovies_MovieId",
                table: "UserMovies");

            migrationBuilder.AddColumn<int>(
                name: "MovieFK",
                table: "UserMovies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_MovieFK",
                table: "UserMovies",
                column: "MovieFK");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_Movies_MovieFK",
                table: "UserMovies",
                column: "MovieFK",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
