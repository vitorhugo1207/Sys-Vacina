using Microsoft.EntityFrameworkCore.Migrations;

namespace ProgramaEstagio.Data.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Person_PersonID",
                table: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Person_PersonID",
                table: "Address",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Person_PersonID",
                table: "Address");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Person_PersonID",
                table: "Address",
                column: "PersonID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
