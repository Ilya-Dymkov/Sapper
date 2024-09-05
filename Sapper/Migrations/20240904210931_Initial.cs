using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sapper.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameInfoResponses",
                columns: table => new
                {
                    Game_id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Width = table.Column<uint>(type: "INTEGER", nullable: false),
                    Height = table.Column<uint>(type: "INTEGER", nullable: false),
                    Mines_count = table.Column<uint>(type: "INTEGER", nullable: false),
                    Completed = table.Column<bool>(type: "INTEGER", nullable: false),
                    CountSafeCells = table.Column<uint>(type: "INTEGER", nullable: false),
                    Field = table.Column<string>(type: "TEXT", nullable: false),
                    TrueField = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameInfoResponses", x => x.Game_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameInfoResponses");
        }
    }
}
