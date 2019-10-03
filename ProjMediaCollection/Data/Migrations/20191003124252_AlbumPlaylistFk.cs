using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class AlbumPlaylistFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums");

            migrationBuilder.RenameColumn(
                name: "MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums",
                newName: "MyMusicPlaylistAlbumFK");

            migrationBuilder.RenameIndex(
                name: "IX_MusicPlaylistAlbums_MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums",
                newName: "IX_MusicPlaylistAlbums_MyMusicPlaylistAlbumFK");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistAlbumFK",
                table: "MusicPlaylistAlbums",
                column: "MyMusicPlaylistAlbumFK",
                principalTable: "MyMusicPlaylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistAlbumFK",
                table: "MusicPlaylistAlbums");

            migrationBuilder.RenameColumn(
                name: "MyMusicPlaylistAlbumFK",
                table: "MusicPlaylistAlbums",
                newName: "MyMusicPlaylistFK");

            migrationBuilder.RenameIndex(
                name: "IX_MusicPlaylistAlbums_MyMusicPlaylistAlbumFK",
                table: "MusicPlaylistAlbums",
                newName: "IX_MusicPlaylistAlbums_MyMusicPlaylistFK");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums",
                column: "MyMusicPlaylistFK",
                principalTable: "MyMusicPlaylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
