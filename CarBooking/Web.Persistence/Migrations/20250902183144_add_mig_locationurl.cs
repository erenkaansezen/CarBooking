using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_mig_locationurl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VideoDescription",
                table: "Banners");

            migrationBuilder.RenameColumn(
                name: "VideoUrl",
                table: "Banners",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "LocationUrl",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationUrl",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Banners",
                newName: "VideoUrl");

            migrationBuilder.AddColumn<string>(
                name: "VideoDescription",
                table: "Banners",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
