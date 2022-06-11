﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mathematio.Migrations
{
    public partial class LinkingAccountsAndDbEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LinkId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "AspNetUsers");
        }
    }
}
