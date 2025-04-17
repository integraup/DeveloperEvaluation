using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class InitialWithNewSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Has10PercentDiscount = table.Column<bool>(type: "boolean", nullable: false),
                    Has20PercentDiscount = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SubTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountPercent = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    UserId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CartId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountPercent = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "Has10PercentDiscount", "Has20PercentDiscount", "Name", "Price", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), new DateTime(2025, 4, 16, 12, 30, 0, 0, DateTimeKind.Unspecified), "Cerveja clara tradicional", true, false, "Cerveja Lager 600ml", 9.99m, 0, null },
                    { new Guid("10000000-0000-0000-0000-000000000002"), new DateTime(2025, 4, 16, 12, 40, 0, 0, DateTimeKind.Unspecified), "Refrigerante brasileiro", false, true, "Guaraná Antarctica 2L", 6.49m, 0, null },
                    { new Guid("10000000-0000-0000-0000-000000000003"), new DateTime(2025, 4, 16, 12, 50, 0, 0, DateTimeKind.Unspecified), "Sem gás", false, false, "Água Mineral 500ml", 2.50m, 0, null },
                    { new Guid("10000000-0000-0000-0000-000000000004"), new DateTime(2025, 4, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), "Repositor energético", true, true, "Isotônico PowerUp 700ml", 7.89m, 0, null },
                    { new Guid("10000000-0000-0000-0000-000000000005"), new DateTime(2025, 4, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), "Sem conservantes", false, false, "Suco Natural Laranja 1L", 8.75m, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Password", "Phone", "Role", "Status", "UpdatedAt", "Username" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 4, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), "admin@ambev.com", "Admin@123", "+55 11 99999-0001", "Admin", "Active", null, "admin.user" },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2025, 4, 16, 12, 10, 0, 0, DateTimeKind.Unspecified), "joao@cliente.com", "Joao@123", "+55 11 99999-0002", "None", "Active", null, "joao.cliente" },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2025, 4, 16, 12, 20, 0, 0, DateTimeKind.Unspecified), "maria@vendas.com", "Maria@123", "+55 11 99999-0003", "Customer", "Active", null, "vendedor.maria" }
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "CreatedAt", "Date", "DiscountPercent", "Status", "SubTotal", "Total", "UserId", "UserId1" },
                values: new object[,]
                {
                    { new Guid("20000000-0000-0000-0000-000000000001"), new DateTime(2025, 4, 16, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 0m, 0m, new Guid("00000000-0000-0000-0000-000000000002"), null },
                    { new Guid("20000000-0000-0000-0000-000000000002"), new DateTime(2025, 4, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, 0m, 0m, new Guid("00000000-0000-0000-0000-000000000002"), null },
                    { new Guid("20000000-0000-0000-0000-000000000003"), new DateTime(2025, 4, 16, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 16, 12, 0, 0, 0, DateTimeKind.Unspecified), 20, 2, 0m, 0m, new Guid("00000000-0000-0000-0000-000000000003"), null }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId1",
                table: "Carts",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
