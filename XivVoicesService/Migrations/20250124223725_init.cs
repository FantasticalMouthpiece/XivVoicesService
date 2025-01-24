using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XivVoicesService.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Speaker = table.Column<string>(type: "text", nullable: false),
                    Sentence = table.Column<string>(type: "text", nullable: false),
                    NpcId = table.Column<string>(type: "text", nullable: false),
                    SkeletonId = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    Gender = table.Column<string>(type: "text", nullable: false),
                    Race = table.Column<string>(type: "text", nullable: false),
                    Tribe = table.Column<string>(type: "text", nullable: false),
                    Eyes = table.Column<string>(type: "text", nullable: false),
                    Folder = table.Column<string>(type: "text", nullable: false),
                    User = table.Column<string>(type: "text", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");
        }
    }
}
