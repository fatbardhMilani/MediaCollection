using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class UserMoviesfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_AspNetUsers_USerId",
                table: "UserMovies");

            migrationBuilder.RenameColumn(
                name: "USerId",
                table: "UserMovies",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMovies_USerId",
                table: "UserMovies",
                newName: "IX_UserMovies_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_AspNetUsers_UserId",
                table: "UserMovies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_AspNetUsers_UserId",
                table: "UserMovies");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserMovies",
                newName: "USerId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMovies_UserId",
                table: "UserMovies",
                newName: "IX_UserMovies_USerId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_AspNetUsers_USerId",
                table: "UserMovies",
                column: "USerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
