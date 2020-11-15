using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cambialo.Api.Migrations
{
    public partial class AddArticleStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Changes_OfferChangeId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Changes_RequestedChangeId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_OfferChangeId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_RequestedChangeId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "OfferChangeId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "RequestedChangeId",
                table: "Articles");

            migrationBuilder.AddColumn<Guid>(
                name: "OfferInChangeId",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestedInChangeId",
                table: "Articles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Articles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_OfferInChangeId",
                table: "Articles",
                column: "OfferInChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_RequestedInChangeId",
                table: "Articles",
                column: "RequestedInChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Changes_OfferInChangeId",
                table: "Articles",
                column: "OfferInChangeId",
                principalTable: "Changes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Changes_RequestedInChangeId",
                table: "Articles",
                column: "RequestedInChangeId",
                principalTable: "Changes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Changes_OfferInChangeId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Changes_RequestedInChangeId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_OfferInChangeId",
                table: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Articles_RequestedInChangeId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "OfferInChangeId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "RequestedInChangeId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Articles");

            migrationBuilder.AddColumn<Guid>(
                name: "OfferChangeId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "RequestedChangeId",
                table: "Articles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_OfferChangeId",
                table: "Articles",
                column: "OfferChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_RequestedChangeId",
                table: "Articles",
                column: "RequestedChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Changes_OfferChangeId",
                table: "Articles",
                column: "OfferChangeId",
                principalTable: "Changes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Changes_RequestedChangeId",
                table: "Articles",
                column: "RequestedChangeId",
                principalTable: "Changes",
                principalColumn: "Id");
        }
    }
}
