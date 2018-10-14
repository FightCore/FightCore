using Microsoft.EntityFrameworkCore.Migrations;

namespace FightCore.Data.Migrations
{
    public partial class AddSecondUserSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "680f3083-462f-4c8f-ba9a-c09a44145495", "test2@test.com", true, false, null, "TEST2@TEST.COM", "TEST2", "AQAAAAEAACcQAAAAEEF7WgDaqY347VdczNcxXwYb6F7IkpBvK5zRg/PU/t5hYIAgKGZanV5GJEco41ILUQ==", null, false, "WYJC6FNA3WBJEXMXPVVNJTJOB3ZQLL2D", false, "test2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { 2, "680f3083-462f-4c8f-ba9a-c09a44145495" });
        }
    }
}
