﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SymphoSphereApp.Migrations
{
    /// <inheritdoc />
    public partial class AddFilePathToSong : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Songs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Songs");
        }
    }
}
