using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class ReconfigureModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActingCredit_Actors_ActorId",
                table: "ActingCredit");

            migrationBuilder.DropForeignKey(
                name: "FK_ActingCredit_Shows_ShowId",
                table: "ActingCredit");

            migrationBuilder.DropTable(
                name: "GenreShow");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActingCredit",
                table: "ActingCredit");

            migrationBuilder.DropIndex(
                name: "IX_ActingCredit_ActorId",
                table: "ActingCredit");

            migrationBuilder.RenameTable(
                name: "ActingCredit",
                newName: "ActingCredits");

            migrationBuilder.RenameIndex(
                name: "IX_ActingCredit_ShowId",
                table: "ActingCredits",
                newName: "IX_ActingCredits_ShowId");

            migrationBuilder.AlterColumn<int>(
                name: "ActingCreditId",
                table: "ActingCredits",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActingCredits",
                table: "ActingCredits",
                columns: new[] { "ActorId", "ShowId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActingCredits_Actors_ActorId",
                table: "ActingCredits",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActingCredits_Shows_ShowId",
                table: "ActingCredits",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActingCredits_Actors_ActorId",
                table: "ActingCredits");

            migrationBuilder.DropForeignKey(
                name: "FK_ActingCredits_Shows_ShowId",
                table: "ActingCredits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActingCredits",
                table: "ActingCredits");

            migrationBuilder.RenameTable(
                name: "ActingCredits",
                newName: "ActingCredit");

            migrationBuilder.RenameIndex(
                name: "IX_ActingCredits_ShowId",
                table: "ActingCredit",
                newName: "IX_ActingCredit_ShowId");

            migrationBuilder.AlterColumn<int>(
                name: "ActingCreditId",
                table: "ActingCredit",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActingCredit",
                table: "ActingCredit",
                column: "ActingCreditId");

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "GenreShow",
                columns: table => new
                {
                    GenreShowId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    ShowId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreShow", x => x.GenreShowId);
                    table.ForeignKey(
                        name: "FK_GenreShow_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreShow_Shows_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Shows",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActingCredit_ActorId",
                table: "ActingCredit",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreShow_GenreId",
                table: "GenreShow",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreShow_ShowId",
                table: "GenreShow",
                column: "ShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActingCredit_Actors_ActorId",
                table: "ActingCredit",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "ActorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActingCredit_Shows_ShowId",
                table: "ActingCredit",
                column: "ShowId",
                principalTable: "Shows",
                principalColumn: "ShowId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
