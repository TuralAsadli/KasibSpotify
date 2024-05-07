using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SymphoSphereApp.Migrations
{
    /// <inheritdoc />
    public partial class AddSongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Song",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Explicit = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Song", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SongUser",
                columns: table => new
                {
                    SongsId = table.Column<int>(type: "int", nullable: false),
                    UsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongUser", x => new { x.SongsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_SongUser_Song_SongsId",
                        column: x => x.SongsId,
                        principalTable: "Song",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SongUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongUser_UsersId",
                table: "SongUser",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongUser");

            migrationBuilder.DropTable(
                name: "Song");
        }
    }
}
