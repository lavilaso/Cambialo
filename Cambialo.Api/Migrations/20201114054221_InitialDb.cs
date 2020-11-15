using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cambialo.Api.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Changes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    FinishedDate = table.Column<DateTime>(nullable: true),
                    ChangeType = table.Column<int>(nullable: false),
                    ChangeStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Changes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    RequestedChangeId = table.Column<Guid>(nullable: true),
                    OfferChangeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Changes_OfferChangeId",
                        column: x => x.OfferChangeId,
                        principalTable: "Changes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Articles_Changes_RequestedChangeId",
                        column: x => x.RequestedChangeId,
                        principalTable: "Changes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_OfferChangeId",
                table: "Articles",
                column: "OfferChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_RequestedChangeId",
                table: "Articles",
                column: "RequestedChangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Changes");
        }
    }
}
