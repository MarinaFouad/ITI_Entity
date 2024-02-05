using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab3.Migrations
{
    /// <inheritdoc />
    public partial class useForeignDepatNotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepartmentID",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "DepatmentID",
                table: "Students",
                newName: "DepatID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepatID",
                table: "Students",
                column: "DepatID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepatID",
                table: "Students",
                column: "DepatID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepatID",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_DepatID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "DepatID",
                table: "Students",
                newName: "DepatmentID");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentID",
                table: "Students",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentID",
                table: "Students",
                column: "DepartmentID",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
