using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnEntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitalCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    address = table.Column<string>(type: "varchar(250)", nullable: false),
                    mobile_phone = table.Column<string>(type: "varchar(14)", nullable: false),
                    email = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_customer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "m_product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_name = table.Column<string>(type: "Varchar(50)", nullable: false),
                    product_price = table.Column<long>(type: "bigint", nullable: false),
                    stock = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "t_purchase",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    trans_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_purchase", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_purchase_m_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "m_customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_purchase_detail",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    purchase_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    qty = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_purchase_detail", x => x.id);
                    table.ForeignKey(
                        name: "FK_t_purchase_detail_m_product_product_id",
                        column: x => x.product_id,
                        principalTable: "m_product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_purchase_detail_t_purchase_purchase_id",
                        column: x => x.purchase_id,
                        principalTable: "t_purchase",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_purchase_customer_id",
                table: "t_purchase",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_purchase_detail_product_id",
                table: "t_purchase_detail",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_t_purchase_detail_purchase_id",
                table: "t_purchase_detail",
                column: "purchase_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_purchase_detail");

            migrationBuilder.DropTable(
                name: "m_product");

            migrationBuilder.DropTable(
                name: "t_purchase");

            migrationBuilder.DropTable(
                name: "m_customer");
        }
    }
}
