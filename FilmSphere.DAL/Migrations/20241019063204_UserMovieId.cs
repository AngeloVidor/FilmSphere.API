using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmSphere.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserMovieId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_Users_UserId",
                table: "UserMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovie",
                table: "UserMovie");

            migrationBuilder.RenameTable(
                name: "UserMovie",
                newName: "Movie");

            migrationBuilder.RenameIndex(
                name: "IX_UserMovie_UserId",
                table: "Movie",
                newName: "IX_Movie_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Users_UserId",
                table: "Movie",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Users_UserId",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "UserMovie");

            migrationBuilder.RenameIndex(
                name: "IX_Movie_UserId",
                table: "UserMovie",
                newName: "IX_UserMovie_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovie",
                table: "UserMovie",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_Users_UserId",
                table: "UserMovie",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
