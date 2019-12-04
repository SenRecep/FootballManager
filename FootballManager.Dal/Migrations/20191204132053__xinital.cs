using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FootballManager.Dal.Migrations
{
    public partial class _xinital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoachSkills",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoachSkills", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Nations",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Nationality = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSkills",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Playerid = table.Column<int>(nullable: false),
                    GoolKeeping = table.Column<int>(nullable: false),
                    Defending = table.Column<int>(nullable: false),
                    Technical = table.Column<int>(nullable: false),
                    Attacking = table.Column<int>(nullable: false),
                    Speed = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSkills", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Postalcodes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    PostalCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postalcodes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Stadiums",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    StadiumName = table.Column<string>(nullable: false),
                    Capacity = table.Column<int>(nullable: false),
                    Founded = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadiums", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Coachs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Firstname = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Nationid = table.Column<int>(nullable: false),
                    WeeklyPaid = table.Column<double>(nullable: false),
                    CoachSkillid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coachs", x => x.id);
                    table.ForeignKey(
                        name: "FK_Coachs_CoachSkills_CoachSkillid",
                        column: x => x.CoachSkillid,
                        principalTable: "CoachSkills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Coachs_Nations_Nationid",
                        column: x => x.Nationid,
                        principalTable: "Nations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    PostalCodeid = table.Column<int>(nullable: false),
                    Adresses = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Adresses_Postalcodes_PostalCodeid",
                        column: x => x.PostalCodeid,
                        principalTable: "Postalcodes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Seasonid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.id);
                    table.ForeignKey(
                        name: "FK_Leagues_Seasons_Seasonid",
                        column: x => x.Seasonid,
                        principalTable: "Seasons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    ClubName = table.Column<string>(nullable: false),
                    Founded = table.Column<int>(nullable: false),
                    Stadiumid = table.Column<int>(nullable: false),
                    Coachid = table.Column<int>(nullable: true),
                    Leagueid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.id);
                    table.ForeignKey(
                        name: "FK_Teams_Coachs_Coachid",
                        column: x => x.Coachid,
                        principalTable: "Coachs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Leagues_Leagueid",
                        column: x => x.Leagueid,
                        principalTable: "Leagues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teams_Stadiums_Stadiumid",
                        column: x => x.Stadiumid,
                        principalTable: "Stadiums",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FirstTeamid = table.Column<int>(nullable: true),
                    SecondTeamid = table.Column<int>(nullable: true),
                    ScoreFirstTeam = table.Column<int>(nullable: false),
                    ScoreSecondTeam = table.Column<int>(nullable: false),
                    IsPlayed = table.Column<bool>(nullable: false),
                    Leagueid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_FirstTeamid",
                        column: x => x.FirstTeamid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Leagues_Leagueid",
                        column: x => x.Leagueid,
                        principalTable: "Leagues",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_SecondTeamid",
                        column: x => x.SecondTeamid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Firstname = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Nationid = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Foot = table.Column<string>(nullable: false),
                    WeeklyPaid = table.Column<double>(nullable: false),
                    MarketPriceValue = table.Column<double>(nullable: false),
                    PlayerSkillid1 = table.Column<int>(nullable: true),
                    PlayerSkillid = table.Column<int>(nullable: true),
                    Number = table.Column<int>(nullable: false),
                    Teamid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.id);
                    table.ForeignKey(
                        name: "FK_Players_Nations_Nationid",
                        column: x => x.Nationid,
                        principalTable: "Nations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Players_PlayerSkills_PlayerSkillid1",
                        column: x => x.PlayerSkillid1,
                        principalTable: "PlayerSkills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Teams_Teamid",
                        column: x => x.Teamid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trophies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    Place = table.Column<int>(nullable: false),
                    teamid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trophies", x => x.id);
                    table.ForeignKey(
                        name: "FK_Trophies_Teams_teamid",
                        column: x => x.teamid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Firstname = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Adressid = table.Column<int>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    TagName = table.Column<string>(nullable: true),
                    Money = table.Column<decimal>(nullable: false),
                    Teamid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                    table.ForeignKey(
                        name: "FK_Users_Adresses_Adressid",
                        column: x => x.Adressid,
                        principalTable: "Adresses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Teams_Teamid",
                        column: x => x.Teamid,
                        principalTable: "Teams",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CreateUserid = table.Column<int>(nullable: false),
                    UpdateDate = table.Column<DateTime>(nullable: true),
                    UpdateUserid = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Playerid = table.Column<int>(nullable: false),
                    PlayerDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.id);
                    table.ForeignKey(
                        name: "FK_Descriptions_Players_Playerid",
                        column: x => x.Playerid,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_PostalCodeid",
                table: "Adresses",
                column: "PostalCodeid");

            migrationBuilder.CreateIndex(
                name: "IX_Coachs_CoachSkillid",
                table: "Coachs",
                column: "CoachSkillid");

            migrationBuilder.CreateIndex(
                name: "IX_Coachs_Nationid",
                table: "Coachs",
                column: "Nationid");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_Playerid",
                table: "Descriptions",
                column: "Playerid");

            migrationBuilder.CreateIndex(
                name: "IX_Leagues_Seasonid",
                table: "Leagues",
                column: "Seasonid");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_FirstTeamid",
                table: "Matches",
                column: "FirstTeamid");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Leagueid",
                table: "Matches",
                column: "Leagueid");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_SecondTeamid",
                table: "Matches",
                column: "SecondTeamid");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Nationid",
                table: "Players",
                column: "Nationid");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerSkillid1",
                table: "Players",
                column: "PlayerSkillid1");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Teamid",
                table: "Players",
                column: "Teamid");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Coachid",
                table: "Teams",
                column: "Coachid");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Leagueid",
                table: "Teams",
                column: "Leagueid");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_Stadiumid",
                table: "Teams",
                column: "Stadiumid");

            migrationBuilder.CreateIndex(
                name: "IX_Trophies_teamid",
                table: "Trophies",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Adressid",
                table: "Users",
                column: "Adressid");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Teamid",
                table: "Users",
                column: "Teamid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Trophies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "PlayerSkills");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Postalcodes");

            migrationBuilder.DropTable(
                name: "Coachs");

            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Stadiums");

            migrationBuilder.DropTable(
                name: "CoachSkills");

            migrationBuilder.DropTable(
                name: "Nations");

            migrationBuilder.DropTable(
                name: "Seasons");
        }
    }
}
