﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Upravuvanje.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Indeks = table.Column<string>(nullable: false),
                    EnrollmentDate = table.Column<DateTime>(nullable: true),
                    AcquireCredits = table.Column<int>(nullable: true),
                    CurrentSemestar = table.Column<int>(nullable: true),
                    EducationLevel = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Degree = table.Column<string>(nullable: true),
                    AcademicRank = table.Column<string>(nullable: true),
                    OfficeNumber = table.Column<string>(nullable: true),
                    HireDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Credits = table.Column<int>(nullable: false),
                    Semestar = table.Column<int>(nullable: false),
                    Programme = table.Column<string>(nullable: true),
                    EducationLevel = table.Column<string>(nullable: true),
                    FirstTeacherId = table.Column<int>(nullable: true),
                    SecondTeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_Teacher_FirstTeacherId",
                        column: x => x.FirstTeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Course_Teacher_SecondTeacherId",
                        column: x => x.SecondTeacherId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Semestar = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: true),
                    Grade = table.Column<int>(nullable: true),
                    SeminalUrl = table.Column<string>(nullable: true),
                    ProjectUrl = table.Column<string>(nullable: true),
                    ExamPoint = table.Column<int>(nullable: true),
                    SeminalPoints = table.Column<int>(nullable: true),
                    ProjectPoints = table.Column<int>(nullable: true),
                    AdditionalPoints = table.Column<int>(nullable: true),
                    FinishDate = table.Column<DateTime>(nullable: true),
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_FirstTeacherId",
                table: "Course",
                column: "FirstTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SecondTeacherId",
                table: "Course",
                column: "SecondTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseId",
                table: "Enrollment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
