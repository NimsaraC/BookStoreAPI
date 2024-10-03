using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class addbookTableWithSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "ISBN", "Price", "PublicationDate", "Publisher", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "A novel set in the Roaring Twenties, exploring themes of wealth and society.", "978-0743273565", 10.99, new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scribner", 25, "The Great Gatsby" },
                    { 2, "George Orwell", "A dystopian novel set in a totalitarian society under constant surveillance.", "978-0451524935", 8.9900000000000002, new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Signet Classics", 40, "1984" },
                    { 3, "Harper Lee", "A novel about racial injustice in the Deep South, seen through the eyes of a young girl.", "978-0061120084", 7.9900000000000002, new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harper Perennial", 30, "To Kill a Mockingbird" },
                    { 4, "Herman Melville", "The saga of Captain Ahab's obsessive quest to kill the white whale, Moby Dick.", "978-1503280786", 12.5, new DateTime(1851, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreateSpace", 15, "Moby-Dick" },
                    { 5, "Jane Austen", "A romantic novel that explores the issues of marriage, money, and love in 19th century England.", "978-1503290563", 6.9900000000000002, new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CreateSpace", 50, "Pride and Prejudice" },
                    { 6, "J.D. Salinger", "A story of teenage angst and alienation told through the eyes of Holden Caulfield.", "978-0316769488", 9.9900000000000002, new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Little, Brown and Company", 35, "The Catcher in the Rye" },
                    { 7, "J.R.R. Tolkien", "A fantasy novel about the adventures of Bilbo Baggins, a hobbit who embarks on a quest.", "978-0547928227", 10.99, new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mariner Books", 60, "The Hobbit" },
                    { 8, "Leo Tolstoy", "A historical novel about the Napoleonic wars and their impact on Russian society.", "978-1420958612", 14.99, new DateTime(1869, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Digireads.com", 20, "War and Peace" },
                    { 9, "Fyodor Dostoevsky", "A philosophical novel that delves into deep themes of faith, doubt, and morality.", "978-0374528379", 13.99, new DateTime(1880, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Farrar, Straus and Giroux", 25, "The Brothers Karamazov" },
                    { 10, "James Joyce", "A modernist novel that chronicles the events of a single day in Dublin.", "978-0199535675", 15.5, new DateTime(1922, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oxford University Press", 10, "Ulysses" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
