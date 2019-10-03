using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class updateMyMusicPlayListAlbum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistAlbumFK",
                table: "MusicPlaylistAlbums");

            migrationBuilder.DropIndex(
                name: "IX_MusicPlaylistAlbums_MyMusicPlaylistAlbumFK",
                table: "MusicPlaylistAlbums");

            migrationBuilder.DropColumn(
                name: "MyMusicPlaylistAlbumFK",
                table: "MusicPlaylistAlbums");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistId",
                table: "MusicPlaylistAlbums");

            migrationBuilder.DropIndex(
                name: "IX_MusicPlaylistAlbums_MyMusicPlaylistId",
                table: "MusicPlaylistAlbums");

            migrationBuilder.AddColumn<int>(
                name: "MyMusicPlaylistAlbumFK",
                table: "MusicPlaylistAlbums",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylistAlbums_MyMusicPlaylistAlbumFK",
                table: "MusicPlaylistAlbums",
                column: "MyMusicPlaylistAlbumFK");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistAlbumFK",
                table: "MusicPlaylistAlbums",
                column: "MyMusicPlaylistAlbumFK",
                principalTable: "MyMusicPlaylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
