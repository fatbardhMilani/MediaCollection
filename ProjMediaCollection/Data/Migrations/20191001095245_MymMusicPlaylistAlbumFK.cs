using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class MymMusicPlaylistAlbumFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums");

            migrationBuilder.AlterColumn<int>(
                name: "MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums",
                column: "MyMusicPlaylistFK",
                principalTable: "MyMusicPlaylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums");

            migrationBuilder.AlterColumn<int>(
                name: "MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums",
                column: "MyMusicPlaylistFK",
                principalTable: "MyMusicPlaylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
