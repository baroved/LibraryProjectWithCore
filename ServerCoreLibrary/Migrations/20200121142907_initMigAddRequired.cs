using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ServerCoreLibrary.Migrations
{
    public partial class initMigAddRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Edition",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenresDiscount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GenreId = table.Column<int>(nullable: false),
                    Percent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenresDiscount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenresDiscount_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublishersDiscount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublisherId = table.Column<int>(nullable: false),
                    Percent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishersDiscount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublishersDiscount_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbstractItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    PrintDate = table.Column<DateTime>(nullable: false),
                    CopiesInStock = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    PublisherId = table.Column<int>(nullable: false),
                    Isbn = table.Column<string>(nullable: true),
                    WriterId = table.Column<int>(nullable: true),
                    EditionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbstractItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbstractItem_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbstractItem_Writers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Writers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbstractItem_Edition_EditionId",
                        column: x => x.EditionId,
                        principalTable: "Edition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WritersDiscount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    WriterId = table.Column<int>(nullable: false),
                    Percent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WritersDiscount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WritersDiscount_Writers_WriterId",
                        column: x => x.WriterId,
                        principalTable: "Writers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookGenres_AbstractItem_BookId",
                        column: x => x.BookId,
                        principalTable: "AbstractItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenres_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ItemId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FinalPrice = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_AbstractItem_ItemId",
                        column: x => x.ItemId,
                        principalTable: "AbstractItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PublisherDiscountId = table.Column<int>(nullable: true),
                    WriterDiscountId = table.Column<int>(nullable: true),
                    GenreDiscountId = table.Column<int>(nullable: true),
                    DateStart = table.Column<DateTime>(nullable: false),
                    DateEnd = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Promotions_GenresDiscount_GenreDiscountId",
                        column: x => x.GenreDiscountId,
                        principalTable: "GenresDiscount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Promotions_PublishersDiscount_PublisherDiscountId",
                        column: x => x.PublisherDiscountId,
                        principalTable: "PublishersDiscount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Promotions_WritersDiscount_WriterDiscountId",
                        column: x => x.WriterDiscountId,
                        principalTable: "WritersDiscount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mr.Oved" },
                    { 2, "Mr.Hadar" },
                    { 3, "Mr.Itay" },
                    { 4, "Mr.Mosha" },
                    { 5, "Ms.Daniel" }
                });

            migrationBuilder.InsertData(
                table: "Edition",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Daily" },
                    { 2, "Weekly" },
                    { 3, "Holiday" },
                    { 4, "Yearly" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 4, "Comedy" },
                    { 3, "Children" },
                    { 2, "Horror" },
                    { 1, "Drama" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Keshet" },
                    { 2, "Maariv" },
                    { 3, "Hebrew" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAdmin", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "baroved6@gmail.com", true, "12345", "baroved" },
                    { 2, "baroved6@walla.com", false, "12345", "bar" }
                });

            migrationBuilder.InsertData(
                table: "Writers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Joseph Elijah" },
                    { 2, "Jacob Eliav" },
                    { 3, "Dan Almagor" }
                });

            migrationBuilder.InsertData(
                table: "AbstractItem",
                columns: new[] { "Id", "CopiesInStock", "Description", "ImgUrl", "Name", "Price", "PrintDate", "PublisherId", "Type", "EditionId" },
                values: new object[] { 2, 10, "dfgdfgdfgdfgdg", "https://www.jpostlite.co.il/wp-content/uploads/2013/07/1-2.jpg", "Zone", 30.899999999999999, new DateTime(2020, 1, 21, 16, 29, 7, 365, DateTimeKind.Local).AddTicks(2053), 2, "Journal", 1 });

            migrationBuilder.InsertData(
                table: "AbstractItem",
                columns: new[] { "Id", "CopiesInStock", "Description", "ImgUrl", "Name", "Price", "PrintDate", "PublisherId", "Type", "Isbn", "WriterId" },
                values: new object[] { 1, 10, "dfgdfgdfgdfgdg", "https://upload.wikimedia.org/wikipedia/he/9/97/Harry_Potter_and_the_Deathly_Hallows_1_%28Heb%29.jpg", "Harry Potter", 49.899999999999999, new DateTime(2020, 1, 21, 16, 29, 7, 364, DateTimeKind.Local).AddTicks(7705), 1, "Book", "4a0fbf6f-0bf6-4f9d-9478-629941033254", 1 });

            migrationBuilder.InsertData(
                table: "GenresDiscount",
                columns: new[] { "Id", "GenreId", "Percent" },
                values: new object[] { 1, 1, 40 });

            migrationBuilder.InsertData(
                table: "PublishersDiscount",
                columns: new[] { "Id", "Percent", "PublisherId" },
                values: new object[] { 1, 20, 1 });

            migrationBuilder.InsertData(
                table: "WritersDiscount",
                columns: new[] { "Id", "Percent", "WriterId" },
                values: new object[] { 1, 30, 1 });

            migrationBuilder.InsertData(
                table: "BookGenres",
                columns: new[] { "Id", "BookId", "GenreId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "DateEnd", "DateStart", "GenreDiscountId", "PublisherDiscountId", "Type", "WriterDiscountId" },
                values: new object[,]
                {
                    { 3, new DateTime(2020, 2, 21, 16, 29, 7, 364, DateTimeKind.Local).AddTicks(662), new DateTime(2020, 1, 21, 16, 29, 7, 364, DateTimeKind.Local).AddTicks(654), 1, null, "Genre", null },
                    { 1, new DateTime(2020, 2, 21, 16, 29, 7, 363, DateTimeKind.Local).AddTicks(8667), new DateTime(2020, 1, 21, 16, 29, 7, 363, DateTimeKind.Local).AddTicks(8208), null, 1, "Publisher", null },
                    { 2, new DateTime(2020, 2, 21, 16, 29, 7, 363, DateTimeKind.Local).AddTicks(9884), new DateTime(2020, 1, 21, 16, 29, 7, 363, DateTimeKind.Local).AddTicks(9872), null, null, "Writer", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbstractItem_PublisherId",
                table: "AbstractItem",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_AbstractItem_WriterId",
                table: "AbstractItem",
                column: "WriterId");

            migrationBuilder.CreateIndex(
                name: "IX_AbstractItem_EditionId",
                table: "AbstractItem",
                column: "EditionId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_BookId",
                table: "BookGenres",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenres_GenreId",
                table: "BookGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_GenresDiscount_GenreId",
                table: "GenresDiscount",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_GenreDiscountId",
                table: "Promotions",
                column: "GenreDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_PublisherDiscountId",
                table: "Promotions",
                column: "PublisherDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_WriterDiscountId",
                table: "Promotions",
                column: "WriterDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_PublishersDiscount_PublisherId",
                table: "PublishersDiscount",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_CustomerId",
                table: "Sales",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_ItemId",
                table: "Sales",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_UserId",
                table: "Sales",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WritersDiscount_WriterId",
                table: "WritersDiscount",
                column: "WriterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGenres");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "GenresDiscount");

            migrationBuilder.DropTable(
                name: "PublishersDiscount");

            migrationBuilder.DropTable(
                name: "WritersDiscount");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "AbstractItem");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Writers");

            migrationBuilder.DropTable(
                name: "Edition");
        }
    }
}
