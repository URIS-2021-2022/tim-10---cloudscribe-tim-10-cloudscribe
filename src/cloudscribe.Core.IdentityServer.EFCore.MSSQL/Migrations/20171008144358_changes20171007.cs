using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace cloudscribe.Core.IdentityServer.EFCore.MSSQL.Migrations
{
    public partial class changes20171007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrefixClientClaims",
                table: "csids_Clients");

            migrationBuilder.AlterColumn<string>(
                name: "FrontChannelLogoutUri",
                table: "csids_Clients",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BackChannelLogoutUri",
                table: "csids_Clients",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientClaimsPrefix",
                table: "csids_Clients",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ConsentLifetime",
                table: "csids_Clients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "csids_Clients",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PairWiseSubjectSalt",
                table: "csids_Clients",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "csids_ClientProps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_csids_ClientPropss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_csids_ClientPropss_csids_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "csids_Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_csids_ClientPropss_ClientId",
                table: "csids_ClientProps",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "csids_ClientProps");

            migrationBuilder.DropColumn(
                name: "ClientClaimsPrefix",
                table: "csids_Clients");

            migrationBuilder.DropColumn(
                name: "ConsentLifetime",
                table: "csids_Clients");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "csids_Clients");

            migrationBuilder.DropColumn(
                name: "PairWiseSubjectSalt",
                table: "csids_Clients");

            migrationBuilder.AlterColumn<string>(
                name: "FrontChannelLogoutUri",
                table: "csids_Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BackChannelLogoutUri",
                table: "csids_Clients",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PrefixClientClaims",
                table: "csids_Clients",
                nullable: false,
                defaultValue: false);
        }
    }
}
