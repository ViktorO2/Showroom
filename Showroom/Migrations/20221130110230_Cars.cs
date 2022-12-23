using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Showroom.Migrations
{
    public partial class Cars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarPictureURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable=table.Column<bool>(type:"bit", nullable: false),
                       
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                }) ;
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
