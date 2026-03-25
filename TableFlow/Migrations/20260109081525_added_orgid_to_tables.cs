using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TableFlow.Migrations
{
    /// <inheritdoc />
    public partial class added_orgid_to_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrganisationId",
                table: "Tables",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganisationId",
                table: "Tables");
        }
    }
}
