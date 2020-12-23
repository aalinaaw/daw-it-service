using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAWProject.Migrations
{
    public partial class AddOneToManyUserTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ServiceType_TicketTypeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets");

            migrationBuilder.AlterColumn<Guid>(
                name: "TicketTypeId",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ServiceType_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_ServiceType_TicketTypeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets");

            migrationBuilder.AlterColumn<Guid>(
                name: "TicketTypeId",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_ServiceType_TicketTypeId",
                table: "Tickets",
                column: "TicketTypeId",
                principalTable: "ServiceType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
