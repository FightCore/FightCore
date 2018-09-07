using Microsoft.EntityFrameworkCore.Migrations;

namespace FightCore.Data.Migrations
{
    public partial class Userseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "680f3083-462f-4c8f-ba9a-c09a44145495", "user@test.nl", true, false, null, "USER@TEST.NL", "USER@TEST.NL", "AQAAAAEAACcQAAAAEEF7WgDaqY347VdczNcxXwYb6F7IkpBvK5zRg/PU/t5hYIAgKGZanV5GJEco41ILUQ==", null, false, "WYJC6FNA3WBJEXMXPVVNJTJOB3ZQLL2D", false, "user@test.nl" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { 1, "680f3083-462f-4c8f-ba9a-c09a44145495" });
        }
    }
}
