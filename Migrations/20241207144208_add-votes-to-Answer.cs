using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace social.Migrations
{
    /// <inheritdoc />
    public partial class addvotestoAnswer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AnswerId",
                table: "Votes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VotesCount",
                table: "Answers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Votes_AnswerId",
                table: "Votes",
                column: "AnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Answers_AnswerId",
                table: "Votes",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Answers_AnswerId",
                table: "Votes");

            migrationBuilder.DropIndex(
                name: "IX_Votes_AnswerId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "AnswerId",
                table: "Votes");

            migrationBuilder.DropColumn(
                name: "VotesCount",
                table: "Answers");
        }
    }
}
