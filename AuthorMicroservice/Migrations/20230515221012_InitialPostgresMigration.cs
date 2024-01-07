using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AuthorMicroservice.Migrations
{
    public partial class InitialPostgresMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    IdAuthor = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Lastname = table.Column<string>(type: "text", nullable: true),
                    Birthdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AuthorGuid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.IdAuthor);
                });

            migrationBuilder.CreateTable(
                name: "AcademicGrades",
                columns: table => new
                {
                    IdAcademicGrade = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CenterAcademic = table.Column<string>(type: "text", nullable: true),
                    DateGrade = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdAuthor = table.Column<int>(type: "integer", nullable: false),
                    AuthorIdAuthor = table.Column<int>(type: "integer", nullable: true),
                    AcademicGradeGuid = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicGrades", x => x.IdAcademicGrade);
                    table.ForeignKey(
                        name: "FK_AcademicGrades_Authors_AuthorIdAuthor",
                        column: x => x.AuthorIdAuthor,
                        principalTable: "Authors",
                        principalColumn: "IdAuthor");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGrades_AuthorIdAuthor",
                table: "AcademicGrades",
                column: "AuthorIdAuthor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicGrades");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
