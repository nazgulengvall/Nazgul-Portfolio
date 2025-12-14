using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeviceRegistry.Api.Migrations
{
    /// <inheritdoc />
    public partial class RenameCreatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAtUtc",
                table: "Devices",
                newName: "CreatedAt");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Devices",
                newName: "CreatedAtUtc");
        }
    }
}
