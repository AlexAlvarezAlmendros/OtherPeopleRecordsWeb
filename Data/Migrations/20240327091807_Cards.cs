using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OtherPeopleRecordsWeb.Data.Migrations
{
    /// <inheritdoc />
    public partial class Cards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Subtitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SpotifyLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    YoutubeLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AppleMusicLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InstagramLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SoundCloudLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BeatStarsLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TwitterLink = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ubicacion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IMG = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    VIDEO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    cardType = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
