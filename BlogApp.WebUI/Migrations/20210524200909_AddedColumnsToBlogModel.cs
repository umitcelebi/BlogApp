using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogApp.WebUI.Migrations
{
    public partial class AddedColumnsToBlogModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHome",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSlider",
                table: "Blogs",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHome",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "IsSlider",
                table: "Blogs");
        }
    }
}
