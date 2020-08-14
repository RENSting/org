using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Org.Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Committees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    FoundDate = table.Column<DateTime>(nullable: false),
                    CurrentSequence = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(nullable: true),
                    FoundDate = table.Column<DateTime>(nullable: false),
                    CurrentSequence = table.Column<int>(nullable: false),
                    CommitteeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_Committees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "Committees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    NativePlace = table.Column<string>(nullable: true),
                    Nation = table.Column<string>(nullable: true),
                    Education = table.Column<string>(nullable: true),
                    StemTitle = table.Column<string>(nullable: true),
                    SocialPosition = table.Column<string>(nullable: true),
                    CareerDate = table.Column<DateTime>(nullable: false),
                    WorkUnit = table.Column<string>(nullable: true),
                    WorkPost = table.Column<string>(nullable: true),
                    WorkCity = table.Column<string>(nullable: true),
                    WorkDistrict = table.Column<string>(nullable: true),
                    WorkAddress = table.Column<string>(nullable: true),
                    ResideCity = table.Column<string>(nullable: true),
                    ResideDistrict = table.Column<string>(nullable: true),
                    ResideAddress = table.Column<string>(nullable: true),
                    IdCardNumber = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Sponsor1 = table.Column<string>(nullable: true),
                    Sponsor2 = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    IsCandidate = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchRanks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BranchId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    AppointDate = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchRanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchRanks_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BranchRanks_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommitteeRanks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CommitteeId = table.Column<int>(nullable: false),
                    Sequence = table.Column<int>(nullable: false),
                    MemberId = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    AppointDate = table.Column<DateTime>(nullable: false),
                    IsRemoved = table.Column<bool>(nullable: false),
                    RemoveDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommitteeRanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommitteeRanks_Committees_CommitteeId",
                        column: x => x.CommitteeId,
                        principalTable: "Committees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommitteeRanks_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberItemLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberId = table.Column<int>(nullable: false),
                    ItemName = table.Column<string>(nullable: true),
                    OldValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberItemLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberItemLogs_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MemberStateLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberId = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    SubCategory = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StateDate = table.Column<DateTime>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberStateLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberStateLogs_Members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CommitteeId",
                table: "Branches",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchRanks_BranchId",
                table: "BranchRanks",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchRanks_MemberId",
                table: "BranchRanks",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeRanks_CommitteeId",
                table: "CommitteeRanks",
                column: "CommitteeId");

            migrationBuilder.CreateIndex(
                name: "IX_CommitteeRanks_MemberId",
                table: "CommitteeRanks",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberItemLogs_MemberId",
                table: "MemberItemLogs",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_BranchId",
                table: "Members",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberStateLogs_MemberId",
                table: "MemberStateLogs",
                column: "MemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BranchRanks");

            migrationBuilder.DropTable(
                name: "CommitteeRanks");

            migrationBuilder.DropTable(
                name: "MemberItemLogs");

            migrationBuilder.DropTable(
                name: "MemberStateLogs");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Committees");
        }
    }
}
