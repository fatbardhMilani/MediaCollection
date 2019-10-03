using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class SerieGenreSerie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SerieGenresSeries",
                columns: table => new
                {
                    SerieId = table.Column<int>(nullable: false),
                    SeriesGenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerieGenresSeries", x => new { x.SeriesGenreId, x.SerieId });
                    table.ForeignKey(
                        name: "FK_SerieGenresSeries_Series_SerieId",
                        column: x => x.SerieId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SerieGenresSeries_SeriesGenres_SeriesGenreId",
                        column: x => x.SeriesGenreId,
                        principalTable: "SeriesGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SerieGenresSeries_SerieId",
                table: "SerieGenresSeries",
                column: "SerieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SerieGenresSeries");
        }
    }
}
