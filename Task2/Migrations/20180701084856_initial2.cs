using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Task2.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarOwner_Cars_CarId",
                table: "CarOwner");

            migrationBuilder.DropForeignKey(
                name: "FK_CarOwner_Owners_OwnerId",
                table: "CarOwner");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarOwner",
                table: "CarOwner");

            migrationBuilder.RenameTable(
                name: "CarOwner",
                newName: "CarOwners");

            migrationBuilder.RenameIndex(
                name: "IX_CarOwner_OwnerId",
                table: "CarOwners",
                newName: "IX_CarOwners_OwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Owners",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Owners",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarOwners",
                table: "CarOwners",
                columns: new[] { "CarId", "OwnerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarOwners_Cars_CarId",
                table: "CarOwners",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarOwners_Owners_OwnerId",
                table: "CarOwners",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarOwners_Cars_CarId",
                table: "CarOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_CarOwners_Owners_OwnerId",
                table: "CarOwners");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarOwners",
                table: "CarOwners");

            migrationBuilder.RenameTable(
                name: "CarOwners",
                newName: "CarOwner");

            migrationBuilder.RenameIndex(
                name: "IX_CarOwners_OwnerId",
                table: "CarOwner",
                newName: "IX_CarOwner_OwnerId");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Owners",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Owners",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarOwner",
                table: "CarOwner",
                columns: new[] { "CarId", "OwnerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarOwner_Cars_CarId",
                table: "CarOwner",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarOwner_Owners_OwnerId",
                table: "CarOwner",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
