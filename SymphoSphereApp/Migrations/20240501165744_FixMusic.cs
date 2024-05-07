using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SymphoSphereApp.Migrations
{
    /// <inheritdoc />
    public partial class FixMusic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongUser_Song_SongsId",
                table: "SongUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Song",
                table: "Song");

            migrationBuilder.RenameTable(
                name: "Song",
                newName: "Songs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Songs",
                table: "Songs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SongUser_Songs_SongsId",
                table: "SongUser",
                column: "SongsId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SongUser_Songs_SongsId",
                table: "SongUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Songs",
                table: "Songs");

            migrationBuilder.RenameTable(
                name: "Songs",
                newName: "Song");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Song",
                table: "Song",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SongUser_Song_SongsId",
                table: "SongUser",
                column: "SongsId",
                principalTable: "Song",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
