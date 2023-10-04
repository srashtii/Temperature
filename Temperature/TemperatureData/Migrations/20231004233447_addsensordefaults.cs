using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemperatureData.Migrations
{
    /// <inheritdoc />
    public partial class addsensordefaults : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SensorLimits",
                columns: new[] { "Id", "Cold", "Hot", "Warm" },
                values: new object[] { 1, 22.0, 35.0, 0.0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SensorLimits",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
