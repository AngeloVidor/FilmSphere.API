using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmSphere.DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixedUserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UseId",
                table: "Users",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "UseId");
        }
    }
}
