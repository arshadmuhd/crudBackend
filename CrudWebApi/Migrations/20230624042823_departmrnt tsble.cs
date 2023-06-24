using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudWebApi.Migrations
{
    /// <inheritdoc />
    public partial class departmrnttsble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartmentHeadId",
                table: "Departments",
                newName: "DepartmentHeadName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartmentHeadName",
                table: "Departments",
                newName: "DepartmentHeadId");
        }
    }
}
