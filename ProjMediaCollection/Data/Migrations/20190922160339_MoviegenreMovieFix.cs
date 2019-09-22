﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjMediaCollection.Data.Migrations
{
    public partial class MoviegenreMovieFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "MovieGenresMovies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MovieGenresMovies",
                nullable: false,
                defaultValue: 0);
        }
    }
}
