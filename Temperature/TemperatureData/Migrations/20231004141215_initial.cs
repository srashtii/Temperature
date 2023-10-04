﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TemperatureData.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SensorLimits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hot = table.Column<double>(type: "float", nullable: false),
                    Cold = table.Column<double>(type: "float", nullable: false),
                    Warm = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorLimits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Temperature = table.Column<double>(type: "float", nullable: false),
                    RecordTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SensorLimits");

            migrationBuilder.DropTable(
                name: "TemperatureRecords");
        }
    }
}
