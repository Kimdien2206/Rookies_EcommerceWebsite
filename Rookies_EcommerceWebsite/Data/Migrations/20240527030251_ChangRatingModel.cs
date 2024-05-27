using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rookies_EcommerceWebsite.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangRatingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_AuthorId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_AuthorId",
                table: "Ratings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a4dd231-10cc-47c6-9f28-28254911f354");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3be22992-acc9-4012-ab07-9d21bd13d1c3");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Ratings");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a8daea2c-cb21-4341-8e84-e4acfd923923", null, "User", null },
                    { "e41ec221-7b89-4391-a62b-cb63ea171765", null, "Admin", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8daea2c-cb21-4341-8e84-e4acfd923923");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e41ec221-7b89-4391-a62b-cb63ea171765");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Ratings");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "Ratings",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1a4dd231-10cc-47c6-9f28-28254911f354", null, "Admin", null },
                    { "3be22992-acc9-4012-ab07-9d21bd13d1c3", null, "User", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_AuthorId",
                table: "Ratings",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_AuthorId",
                table: "Ratings",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
