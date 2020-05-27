using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Commodities",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Commodities", x => x.Id); });

            migrationBuilder.CreateTable(
                "Shops",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Shops", x => x.Id); });

            migrationBuilder.CreateTable(
                "Warehouses",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Warehouses", x => x.Id); });

            migrationBuilder.CreateTable(
                "CommoditiesInShop",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(nullable: false),
                    CommodityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommoditiesInShop", x => x.Id);
                    table.ForeignKey(
                        "FK_CommoditiesInShop_Commodities_CommodityId",
                        x => x.CommodityId,
                        "Commodities",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CommoditiesInShop_Shops_ShopId",
                        x => x.ShopId,
                        "Shops",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "CommoditiesInWarehouse",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(nullable: false),
                    CommodityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommoditiesInWarehouse", x => x.Id);
                    table.ForeignKey(
                        "FK_CommoditiesInWarehouse_Commodities_CommodityId",
                        x => x.CommodityId,
                        "Commodities",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_CommoditiesInWarehouse_Warehouses_WarehouseId",
                        x => x.WarehouseId,
                        "Warehouses",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "PurchaseOrders",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ShopId = table.Column<int>(nullable: true),
                    WarehouseId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        "FK_PurchaseOrders_Shops_ShopId",
                        x => x.ShopId,
                        "Shops",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_PurchaseOrders_Warehouses_WarehouseId",
                        x => x.WarehouseId,
                        "Warehouses",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                "PurchaseElements",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommodityId = table.Column<int>(nullable: false),
                    PurchaseOrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseElements", x => x.Id);
                    table.ForeignKey(
                        "FK_PurchaseElements_Commodities_CommodityId",
                        x => x.CommodityId,
                        "Commodities",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_PurchaseElements_PurchaseOrders_PurchaseOrderId",
                        x => x.PurchaseOrderId,
                        "PurchaseOrders",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                "Commodities",
                new[] {"Id", "Name", "Price"},
                new object[,]
                {
                    {1, "Bread", 20},
                    {2, "Wine", 150}
                });

            migrationBuilder.InsertData(
                "PurchaseOrders",
                new[] {"Id", "Date", "Name", "Number", "ShopId", "WarehouseId"},
                new object[,]
                {
                    {
                        1, new DateTime(2020, 4, 14, 23, 11, 23, 451, DateTimeKind.Local).AddTicks(3540),
                        "Sample order", 1001, null, null
                    },
                    {
                        2, new DateTime(2020, 4, 14, 23, 11, 23, 454, DateTimeKind.Local).AddTicks(7434),
                        "Second sample order", 10011001, null, null
                    }
                });

            migrationBuilder.InsertData(
                "Shops",
                new[] {"Id", "Name"},
                new object[,]
                {
                    {1, "ATB"},
                    {2, "Rozetka"}
                });

            migrationBuilder.InsertData(
                "Warehouses",
                new[] {"Id", "Name"},
                new object[,]
                {
                    {1, "First warehouse"},
                    {2, "Second warehouse"}
                });

            migrationBuilder.InsertData(
                "CommoditiesInShop",
                new[] {"Id", "CommodityId", "ShopId"},
                new object[,]
                {
                    {1, 1, 1},
                    {2, 2, 2}
                });

            migrationBuilder.InsertData(
                "CommoditiesInWarehouse",
                new[] {"Id", "CommodityId", "WarehouseId"},
                new object[,]
                {
                    {1, 2, 1},
                    {2, 1, 2}
                });

            migrationBuilder.InsertData(
                "PurchaseElements",
                new[] {"Id", "CommodityId", "PurchaseOrderId"},
                new object[,]
                {
                    {1, 1, 1},
                    {2, 2, 1},
                    {3, 1, 2},
                    {4, 2, 2}
                });

            migrationBuilder.CreateIndex(
                "IX_CommoditiesInShop_CommodityId",
                "CommoditiesInShop",
                "CommodityId");

            migrationBuilder.CreateIndex(
                "IX_CommoditiesInShop_ShopId",
                "CommoditiesInShop",
                "ShopId");

            migrationBuilder.CreateIndex(
                "IX_CommoditiesInWarehouse_CommodityId",
                "CommoditiesInWarehouse",
                "CommodityId");

            migrationBuilder.CreateIndex(
                "IX_CommoditiesInWarehouse_WarehouseId",
                "CommoditiesInWarehouse",
                "WarehouseId");

            migrationBuilder.CreateIndex(
                "IX_PurchaseElements_CommodityId",
                "PurchaseElements",
                "CommodityId");

            migrationBuilder.CreateIndex(
                "IX_PurchaseElements_PurchaseOrderId",
                "PurchaseElements",
                "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                "IX_PurchaseOrders_ShopId",
                "PurchaseOrders",
                "ShopId");

            migrationBuilder.CreateIndex(
                "IX_PurchaseOrders_WarehouseId",
                "PurchaseOrders",
                "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "CommoditiesInShop");

            migrationBuilder.DropTable(
                "CommoditiesInWarehouse");

            migrationBuilder.DropTable(
                "PurchaseElements");

            migrationBuilder.DropTable(
                "Commodities");

            migrationBuilder.DropTable(
                "PurchaseOrders");

            migrationBuilder.DropTable(
                "Shops");

            migrationBuilder.DropTable(
                "Warehouses");
        }
    }
}