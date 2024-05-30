using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.PersistenceLayer.Migrations
{
    /// <inheritdoc />
    public partial class contractType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractType",
                table: "Contracts",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContractType",
                table: "Contracts");
        }
    }
}
