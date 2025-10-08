using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoursesMVC.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TraineeId",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Results_TraineeId",
                table: "Results",
                column: "TraineeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Traines_TraineeId",
                table: "Results",
                column: "TraineeId",
                principalTable: "Traines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Traines_TraineeId",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Results_TraineeId",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "TraineeId",
                table: "Results");
        }
    }
}
