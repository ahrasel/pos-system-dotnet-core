using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PosSustemUIU.Data.Migrations
{
    public partial class add_purchase_sale_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Suppliers",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Products",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "ProductCategories",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Customers",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Brands",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Areas",
                newName: "CreatedBy");

            migrationBuilder.CreateTable(
                name: "TransectionType",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    GroupName = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Meta = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransectionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductPurchases",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ReferenceInternal = table.Column<string>(nullable: true),
                    ReferenceExternal = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    TotalVat = table.Column<double>(nullable: false),
                    TotalQuantity = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    IsVatPaid = table.Column<bool>(nullable: false),
                    ReceivingCost = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Meta = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Created = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    SupplierId = table.Column<string>(nullable: false),
                    TransectionTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPurchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPurchases_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPurchases_TransectionType_TransectionTypeId",
                        column: x => x.TransectionTypeId,
                        principalTable: "TransectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSales",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ReferenceInternal = table.Column<string>(nullable: true),
                    ReferenceExternal = table.Column<string>(nullable: true),
                    SaleDate = table.Column<DateTime>(nullable: false),
                    PostingDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    TotalVat = table.Column<double>(nullable: false),
                    TotalDiscount = table.Column<double>(nullable: false),
                    TotalQuantity = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    PaymentNote = table.Column<string>(nullable: true),
                    IsVatPaid = table.Column<bool>(nullable: false),
                    ReceivingCost = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    Meta = table.Column<string>(nullable: true),
                    CustomerMeta = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    CustomerId = table.Column<string>(nullable: false),
                    TransectionTypeId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSales_TransectionType_TransectionTypeId",
                        column: x => x.TransectionTypeId,
                        principalTable: "TransectionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchases_SupplierId",
                table: "ProductPurchases",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPurchases_TransectionTypeId",
                table: "ProductPurchases",
                column: "TransectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_CustomerId",
                table: "ProductSales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSales_TransectionTypeId",
                table: "ProductSales",
                column: "TransectionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductPurchases");

            migrationBuilder.DropTable(
                name: "ProductSales");

            migrationBuilder.DropTable(
                name: "TransectionType");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Suppliers",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Products",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ProductCategories",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Customers",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Brands",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Areas",
                newName: "Created");
        }
    }
}
