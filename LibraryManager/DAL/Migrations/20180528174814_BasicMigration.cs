using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DAL.Migrations
{
    public partial class BasicMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Denide",
                table: "Users",
                newName: "Permissions");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                type: "nvarchar(9)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(30)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(253)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Users",
                type: "nvarchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "StoragePlacesStoragePlaceId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateTable(
                name: "HireHistory",
                columns: table => new
                {
                    HireId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HireHistory", x => x.HireId);
                });

            migrationBuilder.CreateTable(
                name: "Mediums",
                columns: table => new
                {
                    MediumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Cover = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    HireHistoryHireId = table.Column<int>(nullable: true),
                    MediumType = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mediums", x => x.MediumId);
                    table.ForeignKey(
                        name: "FK_Mediums_HireHistory_HireHistoryHireId",
                        column: x => x.HireHistoryHireId,
                        principalTable: "HireHistory",
                        principalColumn: "HireId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StoragePlaces",
                columns: table => new
                {
                    StoragePlaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HireHistoryHireId = table.Column<int>(nullable: true),
                    MediumsMediumId = table.Column<int>(nullable: true),
                    StoragePlaceName = table.Column<string>(type: "nvarchar(60)", nullable: false),
                    StorageStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoragePlaces", x => x.StoragePlaceId);
                    table.ForeignKey(
                        name: "FK_StoragePlaces_HireHistory_HireHistoryHireId",
                        column: x => x.HireHistoryHireId,
                        principalTable: "HireHistory",
                        principalColumn: "HireId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoragePlaces_Mediums_MediumsMediumId",
                        column: x => x.MediumsMediumId,
                        principalTable: "Mediums",
                        principalColumn: "MediumId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_StoragePlacesStoragePlaceId",
                table: "Users",
                column: "StoragePlacesStoragePlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Mediums_HireHistoryHireId",
                table: "Mediums",
                column: "HireHistoryHireId");

            migrationBuilder.CreateIndex(
                name: "IX_StoragePlaces_HireHistoryHireId",
                table: "StoragePlaces",
                column: "HireHistoryHireId");

            migrationBuilder.CreateIndex(
                name: "IX_StoragePlaces_MediumsMediumId",
                table: "StoragePlaces",
                column: "MediumsMediumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_StoragePlaces_StoragePlacesStoragePlaceId",
                table: "Users",
                column: "StoragePlacesStoragePlaceId",
                principalTable: "StoragePlaces",
                principalColumn: "StoragePlaceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_StoragePlaces_StoragePlacesStoragePlaceId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "StoragePlaces");

            migrationBuilder.DropTable(
                name: "Mediums");

            migrationBuilder.DropTable(
                name: "HireHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_StoragePlacesStoragePlaceId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StoragePlacesStoragePlaceId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Permissions",
                table: "Users",
                newName: "Denide");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(9)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(253)");

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Users",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
