using Microsoft.EntityFrameworkCore.Migrations;

namespace NRDCL.Customer.Service.Migrations
{
    public partial class CustomerInitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerTable",
                columns: table => new
                {
                    CustomerCID = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    CustomerName = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    MobileNumber = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: true),
                    MailAddress = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTable", x => x.CustomerCID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerTable");
        }
    }
}
