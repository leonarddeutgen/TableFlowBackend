using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableFlow.Migrations
{
    /// <inheritdoc />
    public partial class updated_permissionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxOrganisations",
                table: "PermissionModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaxRooms",
                table: "PermissionModels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermissionText",
                table: "PermissionModels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxOrganisations",
                table: "PermissionModels");

            migrationBuilder.DropColumn(
                name: "MaxRooms",
                table: "PermissionModels");

            migrationBuilder.DropColumn(
                name: "PermissionText",
                table: "PermissionModels");
        }
    }
}
