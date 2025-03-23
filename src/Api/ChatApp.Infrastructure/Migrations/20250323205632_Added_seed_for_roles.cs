using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChatApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Added_seed_for_roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1947bbb7-ac8e-47dc-ba7d-9cb7aec80674"), null, "Admin" },
                    { new Guid("bbce769f-31a1-4d55-8075-ef06db38aec1"), null, "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1947bbb7-ac8e-47dc-ba7d-9cb7aec80674"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("bbce769f-31a1-4d55-8075-ef06db38aec1"));
        }
    }
}
