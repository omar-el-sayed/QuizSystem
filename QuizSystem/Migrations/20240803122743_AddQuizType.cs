using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddQuizType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuizType",
                table: "Quizzes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstructorId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestionLevel",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_InstructorId",
                table: "Questions",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Instructors_InstructorId",
                table: "Questions",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Instructors_InstructorId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_InstructorId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuizType",
                table: "Quizzes");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionLevel",
                table: "Questions");
        }
    }
}
