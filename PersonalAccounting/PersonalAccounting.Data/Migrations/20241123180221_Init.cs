using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PersonalAccounting.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MiddleName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    UserName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "character varying(311)", maxLength: 311, nullable: false),
                    DateTimeRegister = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TypeAccount = table.Column<int>(type: "integer", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    DateTimeTokenExpired = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TelegramUserSession",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uuid", nullable: false),
                    TelegramId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramUserSession", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_TelegramUserSession_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThinkAccountPlanned",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TypeOperation = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DatePlanned = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateCompleted = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThinkAccountPlanned", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThinkAccountPlanned_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThinkSample",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ShortDescription = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    TypeOperation = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThinkSample", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThinkSample_User_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBalance",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBalance", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserBalance_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagThinkRelation",
                columns: table => new
                {
                    ThinkId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagThinkRelation", x => new { x.TagId, x.ThinkId });
                    table.ForeignKey(
                        name: "FK_TagThinkRelation_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagThinkRelation_ThinkAccountPlanned_ThinkId",
                        column: x => x.ThinkId,
                        principalTable: "ThinkAccountPlanned",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserBalanceOperation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BalanceUserId = table.Column<long>(type: "bigint", nullable: false),
                    ChangeAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    DateChange = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReasonChange = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBalanceOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBalanceOperation_UserBalance_BalanceUserId",
                        column: x => x.BalanceUserId,
                        principalTable: "UserBalance",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tag_UserId",
                table: "Tag",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TagThinkRelation_ThinkId",
                table: "TagThinkRelation",
                column: "ThinkId");

            migrationBuilder.CreateIndex(
                name: "IX_TelegramUserSession_TelegramId",
                table: "TelegramUserSession",
                column: "TelegramId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TelegramUserSession_UserId",
                table: "TelegramUserSession",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThinkAccountPlanned_UserId",
                table: "ThinkAccountPlanned",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThinkSample_AuthorId",
                table: "ThinkSample",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBalanceOperation_BalanceUserId",
                table: "UserBalanceOperation",
                column: "BalanceUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TagThinkRelation");

            migrationBuilder.DropTable(
                name: "TelegramUserSession");

            migrationBuilder.DropTable(
                name: "ThinkSample");

            migrationBuilder.DropTable(
                name: "UserBalanceOperation");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "ThinkAccountPlanned");

            migrationBuilder.DropTable(
                name: "UserBalance");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
