using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HaydiKafem.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ColdDrinks",
                columns: table => new
                {
                    ColdDrinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColdDrinkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColdDrinkImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColdDrinkPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColdDrinks", x => x.ColdDrinkId);
                });

            migrationBuilder.CreateTable(
                name: "Deserts",
                columns: table => new
                {
                    DesertId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesertName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesertImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesertPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deserts", x => x.DesertId);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoodPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.FoodId);
                });

            migrationBuilder.CreateTable(
                name: "HotDrinks",
                columns: table => new
                {
                    HotDrinkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotDrinkName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotDrinkImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotDrinkPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotDrinks", x => x.HotDrinkId);
                });

            migrationBuilder.CreateTable(
                name: "IceCreams",
                columns: table => new
                {
                    IceCreamId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IceCreamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IceCreamImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IceCreamPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IceCreams", x => x.IceCreamId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColdDrinks");

            migrationBuilder.DropTable(
                name: "Deserts");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "HotDrinks");

            migrationBuilder.DropTable(
                name: "IceCreams");
        }
    }
}
