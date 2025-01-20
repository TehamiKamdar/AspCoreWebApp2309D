using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCoreWebApp2309D.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyonUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_customers_User_Id",
                table: "customers",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_tblUsers_User_Id",
                table: "customers",
                column: "User_Id",
                principalTable: "tblUsers",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_tblUsers_User_Id",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_customers_User_Id",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "customers");
        }
    }
}
