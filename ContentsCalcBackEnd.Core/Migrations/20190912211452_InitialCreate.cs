using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ContentsCalcBackEnd.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContentsCategoryTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentsCategoryTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentsCalculatorItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 250, nullable: false),
                    ContentsCategoryTypeId = table.Column<int>(nullable: false),
                    Value = table.Column<double>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentsCalculatorItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentsCalculatorItems_ContentsCategoryTypes_ContentsCategoryTypeId",
                        column: x => x.ContentsCategoryTypeId,
                        principalTable: "ContentsCategoryTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContentsCalculatorItems_ContentsCategoryTypeId",
                table: "ContentsCalculatorItems",
                column: "ContentsCategoryTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContentsCalculatorItems");

            migrationBuilder.DropTable(
                name: "ContentsCategoryTypes");
        }
    }
}
