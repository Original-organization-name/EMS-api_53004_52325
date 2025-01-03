using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.Contracts.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OccupationCodeDict",
                columns: table => new
                {
                    Code = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationCodeDict", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "PositionDict",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionDict", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkplaceDict",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkplaceDict", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uuid", nullable: false),
                    EmploymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ConclusionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PositionItemId = table.Column<Guid>(type: "uuid", nullable: true),
                    WorkplaceItemId = table.Column<Guid>(type: "uuid", nullable: true),
                    OccupationCodeItemId = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TerminationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FteNumerator = table.Column<int>(type: "integer", nullable: false),
                    FteDenominator = table.Column<int>(type: "integer", nullable: false),
                    Salary = table.Column<decimal>(type: "numeric", nullable: false),
                    SalaryType = table.Column<int>(type: "integer", nullable: false),
                    ContractType = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_OccupationCodeDict_OccupationCodeItemId",
                        column: x => x.OccupationCodeItemId,
                        principalTable: "OccupationCodeDict",
                        principalColumn: "Code");
                    table.ForeignKey(
                        name: "FK_Contracts_PositionDict_PositionItemId",
                        column: x => x.PositionItemId,
                        principalTable: "PositionDict",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contracts_WorkplaceDict_WorkplaceItemId",
                        column: x => x.WorkplaceItemId,
                        principalTable: "WorkplaceDict",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_OccupationCodeItemId",
                table: "Contracts",
                column: "OccupationCodeItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_PositionItemId",
                table: "Contracts",
                column: "PositionItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_WorkplaceItemId",
                table: "Contracts",
                column: "WorkplaceItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "OccupationCodeDict");

            migrationBuilder.DropTable(
                name: "PositionDict");

            migrationBuilder.DropTable(
                name: "WorkplaceDict");
        }
    }
}
