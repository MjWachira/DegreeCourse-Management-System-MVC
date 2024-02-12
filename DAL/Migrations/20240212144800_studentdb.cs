using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class studentdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    course_id = table.Column<int>(type: "int", nullable: false),
                    course_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    course_description = table.Column<string>(type: "text", nullable: true),
                    credit_hours = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Courses__8F1EF7AE965A2685", x => x.course_id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    student_id = table.Column<int>(type: "int", nullable: false),
                    student_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    date_of_birth = table.Column<DateOnly>(type: "date", nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    phone_number = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Students__2A33069AA14E42D7", x => x.student_id);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    enrollment_id = table.Column<int>(type: "int", nullable: false),
                    student_id = table.Column<int>(type: "int", nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: true),
                    enrollment_date = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Enrollme__6D24AA7A3B855BFE", x => x.enrollment_id);
                    table.ForeignKey(
                        name: "FK__Enrollmen__cours__3C69FB99",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "course_id");
                    table.ForeignKey(
                        name: "FK__Enrollmen__stude__3B75D760",
                        column: x => x.student_id,
                        principalTable: "Students",
                        principalColumn: "student_id");
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "int", nullable: false),
                    enrollment_id = table.Column<int>(type: "int", nullable: true),
                    grade = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Grades__3A8F732C45E536F8", x => x.grade_id);
                    table.ForeignKey(
                        name: "FK__Grades__enrollme__3F466844",
                        column: x => x.enrollment_id,
                        principalTable: "Enrollments",
                        principalColumn: "enrollment_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_course_id",
                table: "Enrollments",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_student_id",
                table: "Enrollments",
                column: "student_id");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_enrollment_id",
                table: "Grades",
                column: "enrollment_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
