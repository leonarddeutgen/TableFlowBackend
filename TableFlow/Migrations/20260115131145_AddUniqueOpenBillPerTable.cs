using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableFlow.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueOpenBillPerTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bills_TableId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "Bills");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_TableId",
                table: "Bills",
                column: "TableId",
                unique: true,
                filter: "[Status] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bills_TableId",
                table: "Bills");

            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "Bills",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_TableId",
                table: "Bills",
                column: "TableId");
        }
    }
}
