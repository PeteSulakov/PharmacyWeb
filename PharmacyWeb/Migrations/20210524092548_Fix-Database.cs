using Microsoft.EntityFrameworkCore.Migrations;

namespace PharmacyWeb.Migrations
{
    public partial class FixDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_MedicineForm_MedicineFormId",
                table: "Medicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineForm",
                table: "MedicineForm");

            migrationBuilder.RenameTable(
                name: "MedicineForm",
                newName: "MedicineForms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineForms",
                table: "MedicineForms",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b36bb0d-2d46-4875-817c-00f03fa7f79e",
                column: "ConcurrencyStamp",
                value: "19438c20-8f32-487c-8a77-2b313243a24b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6eeeeb7-76b0-4980-86f4-19e43538ccae",
                column: "ConcurrencyStamp",
                value: "267501af-792c-4a06-beb2-8d141cdfc41d");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_MedicineForms_MedicineFormId",
                table: "Medicines",
                column: "MedicineFormId",
                principalTable: "MedicineForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_MedicineForms_MedicineFormId",
                table: "Medicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MedicineForms",
                table: "MedicineForms");

            migrationBuilder.RenameTable(
                name: "MedicineForms",
                newName: "MedicineForm");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MedicineForm",
                table: "MedicineForm",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b36bb0d-2d46-4875-817c-00f03fa7f79e",
                column: "ConcurrencyStamp",
                value: "b614b866-1d3b-4bf3-a31d-86442aa7b5a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6eeeeb7-76b0-4980-86f4-19e43538ccae",
                column: "ConcurrencyStamp",
                value: "34ef4e2c-0fd9-4b48-ac51-e82b5f1e3015");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_MedicineForm_MedicineFormId",
                table: "Medicines",
                column: "MedicineFormId",
                principalTable: "MedicineForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
