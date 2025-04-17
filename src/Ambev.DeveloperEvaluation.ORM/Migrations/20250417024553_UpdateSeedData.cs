using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("052999d6-55ba-4d6f-8aa6-0e9a6f55fe98"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("2799cd43-3d1c-49bb-8e99-28e4d0446d30"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("32c2b0af-1c48-4565-a8ec-d098a270d41a"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("7e0614ee-dc98-4853-bf74-5eb8181716a3"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("9b081e2f-80fd-4fdb-80da-75feecc90dea"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("be998d06-073b-467c-9642-6cc4fb4c5e81"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamptz",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "DiscountPercent", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("0723df67-ea44-4209-a50b-defc6cbb6f4d"), new Guid("20000000-0000-0000-0000-000000000001"), 10, new Guid("10000000-0000-0000-0000-000000000002"), 1, 6.49m },
                    { new Guid("13005882-89f7-4cfc-a2bf-92e848f43fba"), new Guid("20000000-0000-0000-0000-000000000001"), 0, new Guid("10000000-0000-0000-0000-000000000001"), 1, 9.99m },
                    { new Guid("35776d72-ff63-4db4-9fdb-eb6fa0a97618"), new Guid("20000000-0000-0000-0000-000000000003"), 20, new Guid("10000000-0000-0000-0000-000000000001"), 2, 9.99m },
                    { new Guid("a046a95b-ab9e-47eb-a906-302821d6ce2d"), new Guid("20000000-0000-0000-0000-000000000003"), 20, new Guid("10000000-0000-0000-0000-000000000002"), 1, 6.49m },
                    { new Guid("a5be6148-2b33-488b-a065-fa0f694ad47d"), new Guid("20000000-0000-0000-0000-000000000002"), 0, new Guid("10000000-0000-0000-0000-000000000004"), 1, 7.89m },
                    { new Guid("deae7c81-b0fe-4da9-b087-958bc8f33f1b"), new Guid("20000000-0000-0000-0000-000000000002"), 0, new Guid("10000000-0000-0000-0000-000000000003"), 3, 2.50m }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Password", "Phone" },
                values: new object[] { "$2a$11$h2EUNdIDgEsG9N3nv42TEuFu9Ed/aiOk8d7cKqUK.2fk8pa/aPsUe", "+5511999990001" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Password", "Phone" },
                values: new object[] { "$2a$11$LDUQB0rCTzo2M/z/6SKBXORLNXGP3tWd1nzbjBBbMfTloMz/k/J8S", "+5511999990002" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Password", "Phone" },
                values: new object[] { "$2a$11$RlmX/nv0rhiddrN2DizMBO4kLFQLpt.DEmwVyIMrAnJQj6X4oQXdO", "+5511999990003" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("0723df67-ea44-4209-a50b-defc6cbb6f4d"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("13005882-89f7-4cfc-a2bf-92e848f43fba"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("35776d72-ff63-4db4-9fdb-eb6fa0a97618"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("a046a95b-ab9e-47eb-a906-302821d6ce2d"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("a5be6148-2b33-488b-a065-fa0f694ad47d"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("deae7c81-b0fe-4da9-b087-958bc8f33f1b"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamptz",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "DiscountPercent", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("052999d6-55ba-4d6f-8aa6-0e9a6f55fe98"), new Guid("20000000-0000-0000-0000-000000000003"), 20, new Guid("10000000-0000-0000-0000-000000000002"), 1, 6.49m },
                    { new Guid("2799cd43-3d1c-49bb-8e99-28e4d0446d30"), new Guid("20000000-0000-0000-0000-000000000002"), 0, new Guid("10000000-0000-0000-0000-000000000004"), 1, 7.89m },
                    { new Guid("32c2b0af-1c48-4565-a8ec-d098a270d41a"), new Guid("20000000-0000-0000-0000-000000000001"), 10, new Guid("10000000-0000-0000-0000-000000000002"), 1, 6.49m },
                    { new Guid("7e0614ee-dc98-4853-bf74-5eb8181716a3"), new Guid("20000000-0000-0000-0000-000000000002"), 0, new Guid("10000000-0000-0000-0000-000000000003"), 3, 2.50m },
                    { new Guid("9b081e2f-80fd-4fdb-80da-75feecc90dea"), new Guid("20000000-0000-0000-0000-000000000001"), 0, new Guid("10000000-0000-0000-0000-000000000001"), 1, 9.99m },
                    { new Guid("be998d06-073b-467c-9642-6cc4fb4c5e81"), new Guid("20000000-0000-0000-0000-000000000003"), 20, new Guid("10000000-0000-0000-0000-000000000001"), 2, 9.99m }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Password", "Phone" },
                values: new object[] { "Admin@123", "+55 11 99999-0001" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Password", "Phone" },
                values: new object[] { "Joao@123", "+55 11 99999-0002" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Password", "Phone" },
                values: new object[] { "Maria@123", "+55 11 99999-0003" });
        }
    }
}
