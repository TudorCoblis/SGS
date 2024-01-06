using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    public partial class navprop2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Professor_ProfessorID",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorID",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Professor_ProfessorID",
                table: "Course",
                column: "ProfessorID",
                principalTable: "Professor",
                principalColumn: "ProfessorID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Professor_ProfessorID",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "ProfessorID",
                table: "Course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Professor_ProfessorID",
                table: "Course",
                column: "ProfessorID",
                principalTable: "Professor",
                principalColumn: "ProfessorID");
        }
    }
}
