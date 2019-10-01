using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class MymMusicPlaylistFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylistAlbums_MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums",
                column: "MyMusicPlaylistFK");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums",
                column: "MyMusicPlaylistFK",
                principalTable: "MyMusicPlaylists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums");

            migrationBuilder.DropIndex(
                name: "IX_MusicPlaylistAlbums_MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums");

            migrationBuilder.DropColumn(
                name: "MyMusicPlaylistFK",
                table: "MusicPlaylistAlbums");
        }
    }
}
