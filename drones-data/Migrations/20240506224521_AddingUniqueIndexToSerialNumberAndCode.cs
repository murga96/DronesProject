using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace drones_data.Migrations
{
    /// <inheritdoc />
    public partial class AddingUniqueIndexToSerialNumberAndCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Medicines_Code",
                table: "Medicines",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drones_SerialNumber",
                table: "Drones",
                column: "SerialNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Medicines_Code",
                table: "Medicines");

            migrationBuilder.DropIndex(
                name: "IX_Drones_SerialNumber",
                table: "Drones");
        }
    }
}
