using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NRDCL.Order.Service.Migrations
{
    public partial class OrderInitMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order_tbl",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerCID = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    PriceAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    TransportAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    AdvanceBalance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_tbl", x => x.OrderID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order_tbl");
        }
    }
}
