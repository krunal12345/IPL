using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IPL.Migrations
{
    /// <inheritdoc />
    public partial class fluentapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Trophies",
                table: "Teams",
                newName: "Total trophies");

            migrationBuilder.RenameColumn(
                name: "TotalRunsScored",
                table: "Players",
                newName: "TotalRuns");

            migrationBuilder.RenameColumn(
                name: "JerseyNumber",
                table: "Players",
                newName: "ShirtNumber");

            migrationBuilder.AlterTable(
                name: "Teams",
                comment: "Teams Data Table");

            migrationBuilder.AlterTable(
                name: "Players",
                comment: "Players table");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "Teams",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "FanBaseType",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 3,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Total trophies",
                table: "Teams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Players",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "LastName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Players",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "FirstName",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TotalRuns",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ShirtNumber",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "FancyName",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                computedColumnSql: "CONCAT(ShortName, ' : ', Name)");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Teams_Name",
                table: "Teams",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Teams_Name",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "FancyName",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "Total trophies",
                table: "Teams",
                newName: "Trophies");

            migrationBuilder.RenameColumn(
                name: "TotalRuns",
                table: "Players",
                newName: "TotalRunsScored");

            migrationBuilder.RenameColumn(
                name: "ShirtNumber",
                table: "Players",
                newName: "JerseyNumber");

            migrationBuilder.AlterTable(
                name: "Teams",
                oldComment: "Teams Data Table");

            migrationBuilder.AlterTable(
                name: "Players",
                oldComment: "Players table");

            migrationBuilder.AlterColumn<string>(
                name: "ShortName",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<int>(
                name: "FanBaseType",
                table: "Teams",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "Trophies",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldDefaultValue: "LastName");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldDefaultValue: "FirstName");

            migrationBuilder.AlterColumn<int>(
                name: "TotalRunsScored",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "JerseyNumber",
                table: "Players",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);
        }
    }
}
