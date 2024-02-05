using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab3.Migrations
{
    /// <inheritdoc />
    public partial class UseKeyNotation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentCourseId",
                table: "StudentCourses",
                newName: "RelatedCourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RelatedCourseId",
                table: "StudentCourses",
                newName: "StudentCourseId");
        }
    }
}
