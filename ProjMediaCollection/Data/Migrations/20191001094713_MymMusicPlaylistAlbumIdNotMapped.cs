using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class MymMusicPlaylistAlbumIdNotMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistId",
                table: "MusicPlaylistAlbums");

            migrationBuilder.DropForeignKey(
                name: "FK_MyMusicPlaylistSongs_MyMusicPlaylists_MyMusicPlaylistId",
                table: "MyMusicPlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_MyMusicPlaylistSongs_MyMusicPlaylistId",
                table: "MyMusicPlaylistSongs");

            migrationBuilder.DropIndex(
                name: "IX_MusicPlaylistAlbums_MyMusicPlaylistId",
                table: "MusicPlaylistAlbums");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_MyMusicPlaylistSongs_MyMusicPlaylistId",
                table: "MyMusicPlaylistSongs",
                column: "MyMusicPlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylistAlbums_MyMusicPlaylistId",
                table: "MusicPlaylistAlbums",
                column: "MyMusicPlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistId",
                table: "MusicPlaylistAlbums",
                column: "MyMusicPlaylistId",
                principalTable: "MyMusicPlaylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyMusicPlaylistSongs_MyMusicPlaylists_MyMusicPlaylistId",
                table: "MyMusicPlaylistSongs",
                column: "MyMusicPlaylistId",
                principalTable: "MyMusicPlaylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
