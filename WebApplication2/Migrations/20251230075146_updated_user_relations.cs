using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class updated_user_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Users_PermissionId",
                table: "Users",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_PermissionModels_PermissionId",
                table: "Users",
                column: "PermissionId",
                principalTable: "PermissionModels",
                principalColumn: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_PermissionModels_PermissionId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_PermissionId",
                table: "Users");
        }
    }
}
