using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace NRDCL.Site.Service.Migrations
{
    public partial class SiteInitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer_tbl",
                columns: table => new
                {
                    CustomerCID = table.Column<string>(type: "text", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: true),
                    MobileNumber = table.Column<string>(type: "text", nullable: true),
                    MailAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_tbl", x => x.CustomerCID);
                });

            migrationBuilder.CreateTable(
                name: "Site_tbl",
                columns: table => new
                {
                    SiteID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerCID = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    SiteName = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Distance = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_tbl", x => x.SiteID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_tbl");

            migrationBuilder.DropTable(
                name: "Site_tbl");
        }
    }
}
