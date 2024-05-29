using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.PersistenceLayer.Migrations
{
    /// <inheritdoc />
    public partial class fixContracts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WorkplaceItemId",
                table: "Contracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_WorkplaceItemId",
                table: "Contracts",
                column: "WorkplaceItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_WorkplaceDict_WorkplaceItemId",
                table: "Contracts",
                column: "WorkplaceItemId",
                principalTable: "WorkplaceDict",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_WorkplaceDict_WorkplaceItemId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_WorkplaceItemId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "WorkplaceItemId",
                table: "Contracts");
        }
    }
}
