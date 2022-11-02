using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MobilearningBackEnd.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    introduction = table.Column<string>(type: "text", nullable: false),
                    task = table.Column<string>(type: "text", nullable: false),
                    process = table.Column<string>(type: "text", nullable: false),
                    information = table.Column<List<string>>(type: "text[]", nullable: false),
                    evaluation = table.Column<string>(type: "text", nullable: false),
                    conclusion = table.Column<string>(type: "text", nullable: false),
                    references = table.Column<List<string>>(type: "text[]", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    subtitle = table.Column<string>(type: "text", nullable: false),
                    imageURL = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    cpf = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userId = table.Column<int>(type: "integer", nullable: false),
                    portugueseWord = table.Column<string>(type: "text", nullable: false),
                    englishWord = table.Column<string>(type: "text", nullable: false),
                    portugueseDefinition = table.Column<string>(type: "text", nullable: false),
                    englishDefinition = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUser = table.Column<int>(type: "integer", nullable: false),
                    nivel = table.Column<string>(type: "text", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                    table.ForeignKey(
                        name: "FK_Students_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idUser = table.Column<int>(type: "integer", nullable: false),
                    graduation = table.Column<string>(type: "text", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.id);
                    table.ForeignKey(
                        name: "FK_Teachers_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "UserActivities",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    idUser = table.Column<int>(type: "integer", nullable: false),
                    idActivity = table.Column<int>(type: "integer", nullable: false),
                    currentStage = table.Column<string>(type: "text", nullable: false),
                    progress = table.Column<double>(type: "double precision", nullable: false),
                    startDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    endDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    userid = table.Column<int>(type: "integer", nullable: true),
                    activityid = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActivities", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserActivities_Activities_activityid",
                        column: x => x.activityid,
                        principalTable: "Activities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_UserActivities_Users_userid",
                        column: x => x.userid,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_userid",
                table: "Students",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_userid",
                table: "Teachers",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivities_activityid",
                table: "UserActivities",
                column: "activityid");

            migrationBuilder.CreateIndex(
                name: "IX_UserActivities_userid",
                table: "UserActivities",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "UserActivities");

            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
