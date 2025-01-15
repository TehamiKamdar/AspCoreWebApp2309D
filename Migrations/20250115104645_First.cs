using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCoreWebApp2309D.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Customer_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Customer_City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Customer_Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Customer_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
