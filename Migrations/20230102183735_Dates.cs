using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FlightREST.Migrations
{
    public partial class Dates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticket_user_UserId",
                table: "ticket");

            migrationBuilder.DropIndex(
                name: "IX_ticket_UserId",
                table: "ticket");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ticket");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDateTime",
                table: "flight",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDateTime",
                table: "flight",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalDateTime",
                table: "flight");

            migrationBuilder.DropColumn(
                name: "DepartureDateTime",
                table: "flight");

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "ticket",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ticket_UserId",
                table: "ticket",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ticket_user_UserId",
                table: "ticket",
                column: "UserId",
                principalTable: "user",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
