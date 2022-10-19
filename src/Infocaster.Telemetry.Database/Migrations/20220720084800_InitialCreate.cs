using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infocaster.Telemetry.Database.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppTelemetryReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTelemetryReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppTelemetry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ValueInt = table.Column<int>(type: "int", nullable: true),
                    ValueBool = table.Column<bool>(type: "bit", nullable: true),
                    ValueDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ValueString = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    AppTelemetryReportId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTelemetry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTelemetry_AppTelemetryReports_AppTelemetryReportId",
                        column: x => x.AppTelemetryReportId,
                        principalTable: "AppTelemetryReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppTelemetry_AppTelemetryReportId",
                table: "AppTelemetry",
                column: "AppTelemetryReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppTelemetry");

            migrationBuilder.DropTable(
                name: "AppTelemetryReports");
        }
    }
}
