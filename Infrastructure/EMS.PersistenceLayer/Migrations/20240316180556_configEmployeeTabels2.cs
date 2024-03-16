using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.PersistenceLayer.Migrations
{
    /// <inheritdoc />
    public partial class configEmployeeTabels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PaymentMethodId",
                table: "Employees",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PaymentMethodId",
                table: "Employees",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_PaymentMethods_PaymentMethodId",
                table: "Employees",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_PaymentMethods_PaymentMethodId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PaymentMethodId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "Employees");
        }
    }
}
