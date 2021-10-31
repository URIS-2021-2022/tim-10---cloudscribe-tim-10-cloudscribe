﻿using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace cloudscribe.Core.Storage.EFCore.MSSQL.Migrations
{
    public partial class changes20171005 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cs_UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cs_UserToken", x => new { x.UserId, x.SiteId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateIndex(
                name: "IX_cs_UserToken_SiteId",
                table: "cs_UserToken",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_cs_UserToken_UserId",
                table: "cs_UserToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cs_UserToken");
        }
    }
}
