using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class editUnitMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Units_UnitId",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "Materials",
                newName: "UnitMaterialId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_UnitId",
                table: "Materials",
                newName: "IX_Materials_UnitMaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Units_UnitMaterialId",
                table: "Materials",
                column: "UnitMaterialId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Units_UnitMaterialId",
                table: "Materials");

            migrationBuilder.RenameColumn(
                name: "UnitMaterialId",
                table: "Materials",
                newName: "UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Materials_UnitMaterialId",
                table: "Materials",
                newName: "IX_Materials_UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Units_UnitId",
                table: "Materials",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
