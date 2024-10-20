using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmSphere.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Back : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CharacterName",
                table: "Cast",
                newName: "CharacterName5");

            migrationBuilder.RenameColumn(
                name: "ActorName",
                table: "Cast",
                newName: "CharacterName4");

            migrationBuilder.AddColumn<string>(
                name: "ActorName1",
                table: "Cast",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ActorName2",
                table: "Cast",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ActorName3",
                table: "Cast",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ActorName4",
                table: "Cast",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ActorName5",
                table: "Cast",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CharacterName1",
                table: "Cast",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CharacterName2",
                table: "Cast",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CharacterName3",
                table: "Cast",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActorName1",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "ActorName2",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "ActorName3",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "ActorName4",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "ActorName5",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "CharacterName1",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "CharacterName2",
                table: "Cast");

            migrationBuilder.DropColumn(
                name: "CharacterName3",
                table: "Cast");

            migrationBuilder.RenameColumn(
                name: "CharacterName5",
                table: "Cast",
                newName: "CharacterName");

            migrationBuilder.RenameColumn(
                name: "CharacterName4",
                table: "Cast",
                newName: "ActorName");
        }
    }
}
