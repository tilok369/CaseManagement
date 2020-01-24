using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASACaseManagement.Services.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseFiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    CaseNumber = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Respondents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 200, nullable: false),
                    CaseFileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respondents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respondents_CaseFiles_CaseFileId",
                        column: x => x.CaseFileId,
                        principalTable: "CaseFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CaseFiles",
                columns: new[] { "Id", "CaseNumber", "CreationDate", "Description", "Title" },
                values: new object[] { 1, "1001-001", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of disputes between a landlord and tenant goes here.", "Disputes between a landlord and tenant" });

            migrationBuilder.InsertData(
                table: "CaseFiles",
                columns: new[] { "Id", "CaseNumber", "CreationDate", "Description", "Title" },
                values: new object[] { 2, "2001-002", new DateTime(2020, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of committed homicide felony offense goes here.", "Committed homicide felony offense" });

            migrationBuilder.InsertData(
                table: "CaseFiles",
                columns: new[] { "Id", "CaseNumber", "CreationDate", "Description", "Title" },
                values: new object[] { 3, "3001-003", new DateTime(2020, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Description of traffic rules violation goes here.", "Traffic rules violation" });

            migrationBuilder.InsertData(
                table: "Respondents",
                columns: new[] { "Id", "Address", "CaseFileId", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Village: V1, Post Office: PO1, Thana: T1, District: D1, Division: Dv1, Bangladesh", 1, new DateTime(1988, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Shafiq", "Anwar" },
                    { 2, "Village: V2, Post Office: PO2, Thana: T2, District: D2, Division: Dv2, Bangladesh", 1, new DateTime(1984, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mohammad", "Hasan" },
                    { 3, "Village: V3, Post Office: PO3, Thana: T3, District: D3, Division: Dv3, Bangladesh", 2, new DateTime(1988, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ahmed", "Arefin" },
                    { 4, "Village: V4, Post Office: PO4, Thana: T4, District: D4, Division: Dv4, Bangladesh", 2, new DateTime(1988, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bilkis", "Banu" },
                    { 5, "Village: V5, Post Office: PO5, Thana: T5, District: D5, Division: Dv5, Bangladesh", 3, new DateTime(1996, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zebunnesa", "Begum" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Respondents_CaseFileId",
                table: "Respondents",
                column: "CaseFileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respondents");

            migrationBuilder.DropTable(
                name: "CaseFiles");
        }
    }
}
