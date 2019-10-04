using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class seriePlaylist1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MySeriePlaylists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlaylistName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    MySeriePlaylistSerieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MySeriePlaylists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MySeriePlaylists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MySeriePlaylistSeries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MySeriePlaylistId = table.Column<int>(nullable: false),
                    SerieId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MySeriePlaylistSeries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MySeriePlaylistSeries_MySeriePlaylists_MySeriePlaylistId",
                        column: x => x.MySeriePlaylistId,
                        principalTable: "MySeriePlaylists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MySeriePlaylistSeries_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MySeriePlaylists_UserId",
                table: "MySeriePlaylists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MySeriePlaylistSeries_MySeriePlaylistId",
                table: "MySeriePlaylistSeries",
                column: "MySeriePlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_MySeriePlaylistSeries_SerieId",
                table: "MySeriePlaylistSeries",
                column: "SerieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MySeriePlaylistSeries");

            migrationBuilder.DropTable(
                name: "MySeriePlaylists");
        }
    }
}
