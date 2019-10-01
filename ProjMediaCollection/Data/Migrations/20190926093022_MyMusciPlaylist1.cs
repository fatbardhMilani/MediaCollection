using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class MyMusciPlaylist1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyMusicPlaylists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlaylistName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    MyMusicPlayListAlbumId = table.Column<int>(nullable: false),
                    MyMusicPlayListSongId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyMusicPlaylists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyMusicPlaylists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MusicPlaylistAlbums",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyMusicPlaylistId = table.Column<int>(nullable: false),
                    AlbumId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicPlaylistAlbums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicPlaylistAlbums_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MusicPlaylistAlbums_MyMusicPlaylists_MyMusicPlaylistId",
                        column: x => x.MyMusicPlaylistId,
                        principalTable: "MyMusicPlaylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MyMusicPlaylistSongs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyMusicPlaylistId = table.Column<int>(nullable: false),
                    SongId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyMusicPlaylistSongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MyMusicPlaylistSongs_MyMusicPlaylists_MyMusicPlaylistId",
                        column: x => x.MyMusicPlaylistId,
                        principalTable: "MyMusicPlaylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MyMusicPlaylistSongs_Songs_SongId",
                        column: x => x.SongId,
                        principalTable: "Songs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylistAlbums_AlbumId",
                table: "MusicPlaylistAlbums",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicPlaylistAlbums_MyMusicPlaylistId",
                table: "MusicPlaylistAlbums",
                column: "MyMusicPlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_MyMusicPlaylists_UserId",
                table: "MyMusicPlaylists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MyMusicPlaylistSongs_MyMusicPlaylistId",
                table: "MyMusicPlaylistSongs",
                column: "MyMusicPlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_MyMusicPlaylistSongs_SongId",
                table: "MyMusicPlaylistSongs",
                column: "SongId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicPlaylistAlbums");

            migrationBuilder.DropTable(
                name: "MyMusicPlaylistSongs");

            migrationBuilder.DropTable(
                name: "MyMusicPlaylists");
        }
    }
}
