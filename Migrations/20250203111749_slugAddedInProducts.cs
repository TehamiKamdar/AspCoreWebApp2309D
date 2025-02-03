﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCoreWebApp2309D.Migrations
{
    /// <inheritdoc />
    public partial class slugAddedInProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "tblProducts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "tblProducts");
        }
    }
}
