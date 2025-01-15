using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCoreWebApp2309D.Migrations
{
    /// <inheritdoc />
    public partial class kuchbhi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Customer_Password",
                table: "customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Customer_Password",
                table: "customers");
        }
    }
}
