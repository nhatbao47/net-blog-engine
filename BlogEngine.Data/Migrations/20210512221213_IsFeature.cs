using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogEngine.Data.Migrations
{
    public partial class IsFeature : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeature",
                table: "Post",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeature",
                table: "Post");
        }
    }
}
