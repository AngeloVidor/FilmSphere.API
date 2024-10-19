using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmSphere.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ValidateMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MovieName",
                table: "Movie",
                newName: "TrailerUrl");

            migrationBuilder.RenameColumn(
                name: "MovieDescription",
                table: "Movie",
                newName: "ReleaseDate");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginalTitle",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "RunTime",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "OriginalTitle",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "RunTime",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "TrailerUrl",
                table: "Movie",
                newName: "MovieName");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Movie",
                newName: "MovieDescription");
        }
    }
}
