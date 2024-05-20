using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScheduleDAL.Migrations
{
    /// <inheritdoc />
    public partial class changeTemeToTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Teme",
                table: "Meals",
                newName: "Time");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Time",
                table: "Meals",
                newName: "Teme");
        }
    }
}
