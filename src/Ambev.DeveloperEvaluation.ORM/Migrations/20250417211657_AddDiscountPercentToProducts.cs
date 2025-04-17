using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class AddDiscountPercentToProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "Id", "CartId", "DiscountPercent", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("12be4215-669c-4958-86bb-c5056cd1f808"), new Guid("20000000-0000-0000-0000-000000000002"), 0, new Guid("10000000-0000-0000-0000-000000000004"), 1, 7.89m },
                    { new Guid("392c34cd-4203-43ab-a892-29df2aa970f2"), new Guid("20000000-0000-0000-0000-000000000001"), 0, new Guid("10000000-0000-0000-0000-000000000001"), 1, 9.99m },
                    { new Guid("54b97796-a7a8-4983-9f88-41041a1031d6"), new Guid("20000000-0000-0000-0000-000000000003"), 20, new Guid("10000000-0000-0000-0000-000000000002"), 1, 6.49m },
                    { new Guid("72614c05-b966-4160-96e3-d10ab90d6378"), new Guid("20000000-0000-0000-0000-000000000001"), 10, new Guid("10000000-0000-0000-0000-000000000002"), 1, 6.49m },
                    { new Guid("ec963663-57bc-4923-bc2d-b69334e5c8c1"), new Guid("20000000-0000-0000-0000-000000000002"), 0, new Guid("10000000-0000-0000-0000-000000000003"), 3, 2.50m },
                    { new Guid("edb86825-4fe3-4579-8904-ccdea9c2a93f"), new Guid("20000000-0000-0000-0000-000000000003"), 20, new Guid("10000000-0000-0000-0000-000000000001"), 2, 9.99m }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"),
                column: "DiscountPercent",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"),
                column: "DiscountPercent",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"),
                column: "DiscountPercent",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"),
                column: "DiscountPercent",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"),
                column: "DiscountPercent",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                column: "Password",
                value: "$2a$11$HHQdS.0NHbe7/3s1OVZfCeg98n6x4nXygz0PVR.0ITYvE2IflnqUW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "Password",
                value: "$2a$11$TIrnhb5ArG0C2mTpfNnKi.uK9ADF26XBaIVClAuqJ2m5u7rH/11bC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Password",
                value: "$2a$11$E7Ao1JUD/Cnrcp2.gudlxOfKON.cHeiQ8Bl98fR685.zENSGshvyy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("12be4215-669c-4958-86bb-c5056cd1f808"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("392c34cd-4203-43ab-a892-29df2aa970f2"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("54b97796-a7a8-4983-9f88-41041a1031d6"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("72614c05-b966-4160-96e3-d10ab90d6378"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("ec963663-57bc-4923-bc2d-b69334e5c8c1"));

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "Id",
                keyValue: new Guid("edb86825-4fe3-4579-8904-ccdea9c2a93f"));

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Products");

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
                column: "Password",
                value: "$2a$11$h2EUNdIDgEsG9N3nv42TEuFu9Ed/aiOk8d7cKqUK.2fk8pa/aPsUe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                column: "Password",
                value: "$2a$11$LDUQB0rCTzo2M/z/6SKBXORLNXGP3tWd1nzbjBBbMfTloMz/k/J8S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                column: "Password",
                value: "$2a$11$RlmX/nv0rhiddrN2DizMBO4kLFQLpt.DEmwVyIMrAnJQj6X4oQXdO");
        }
    }
}
