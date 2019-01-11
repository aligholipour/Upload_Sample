using Microsoft.EntityFrameworkCore.Migrations;

namespace Upload_Sample.Migrations
{
    public partial class Add_Colum_TrackCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrackCount",
                table: "Albums",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrackCount",
                table: "Albums");
        }
    }
}
