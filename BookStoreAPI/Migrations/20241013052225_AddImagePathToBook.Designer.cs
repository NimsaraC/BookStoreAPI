﻿// <auto-generated />
using System;
using BookStoreAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookStoreAPI.Migrations
{
    [DbContext(typeof(BookStoreDbContext))]
    [Migration("20241013052225_AddImagePathToBook")]
    partial class AddImagePathToBook
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookStoreAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "F. Scott Fitzgerald",
                            Description = "A novel set in the Roaring Twenties, exploring themes of wealth and society.",
                            ISBN = "978-0743273565",
                            Price = 10.99,
                            PublicationDate = new DateTime(1925, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Publisher = "Scribner",
                            Stock = 25,
                            Title = "The Great Gatsby"
                        },
                        new
                        {
                            Id = 2,
                            Author = "George Orwell",
                            Description = "A dystopian novel set in a totalitarian society under constant surveillance.",
                            ISBN = "978-0451524935",
                            Price = 8.9900000000000002,
                            PublicationDate = new DateTime(1949, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Publisher = "Signet Classics",
                            Stock = 40,
                            Title = "1984"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Harper Lee",
                            Description = "A novel about racial injustice in the Deep South, seen through the eyes of a young girl.",
                            ISBN = "978-0061120084",
                            Price = 7.9900000000000002,
                            PublicationDate = new DateTime(1960, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Publisher = "Harper Perennial",
                            Stock = 30,
                            Title = "To Kill a Mockingbird"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Herman Melville",
                            Description = "The saga of Captain Ahab's obsessive quest to kill the white whale, Moby Dick.",
                            ISBN = "978-1503280786",
                            Price = 12.5,
                            PublicationDate = new DateTime(1851, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Publisher = "CreateSpace",
                            Stock = 15,
                            Title = "Moby-Dick"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Jane Austen",
                            Description = "A romantic novel that explores the issues of marriage, money, and love in 19th century England.",
                            ISBN = "978-1503290563",
                            Price = 6.9900000000000002,
                            PublicationDate = new DateTime(1813, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Publisher = "CreateSpace",
                            Stock = 50,
                            Title = "Pride and Prejudice"
                        },
                        new
                        {
                            Id = 6,
                            Author = "J.D. Salinger",
                            Description = "A story of teenage angst and alienation told through the eyes of Holden Caulfield.",
                            ISBN = "978-0316769488",
                            Price = 9.9900000000000002,
                            PublicationDate = new DateTime(1951, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Publisher = "Little, Brown and Company",
                            Stock = 35,
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            Id = 7,
                            Author = "J.R.R. Tolkien",
                            Description = "A fantasy novel about the adventures of Bilbo Baggins, a hobbit who embarks on a quest.",
                            ISBN = "978-0547928227",
                            Price = 10.99,
                            PublicationDate = new DateTime(1937, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Publisher = "Mariner Books",
                            Stock = 60,
                            Title = "The Hobbit"
                        },
                        new
                        {
                            Id = 8,
                            Author = "Leo Tolstoy",
                            Description = "A historical novel about the Napoleonic wars and their impact on Russian society.",
                            ISBN = "978-1420958612",
                            Price = 14.99,
                            PublicationDate = new DateTime(1869, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Publisher = "Digireads.com",
                            Stock = 20,
                            Title = "War and Peace"
                        },
                        new
                        {
                            Id = 9,
                            Author = "Fyodor Dostoevsky",
                            Description = "A philosophical novel that delves into deep themes of faith, doubt, and morality.",
                            ISBN = "978-0374528379",
                            Price = 13.99,
                            PublicationDate = new DateTime(1880, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Publisher = "Farrar, Straus and Giroux",
                            Stock = 25,
                            Title = "The Brothers Karamazov"
                        },
                        new
                        {
                            Id = 10,
                            Author = "James Joyce",
                            Description = "A modernist novel that chronicles the events of a single day in Dublin.",
                            ISBN = "978-0199535675",
                            Price = 15.5,
                            PublicationDate = new DateTime(1922, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Publisher = "Oxford University Press",
                            Stock = 10,
                            Title = "Ulysses"
                        });
                });

            modelBuilder.Entity("BookStoreAPI.Models.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("BookStoreAPI.Models.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Region")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BookStoreAPI.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("BookStoreAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookStoreAPI.Models.CartItem", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Cart", null)
                        .WithMany("Items")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookStoreAPI.Models.OrderItem", b =>
                {
                    b.HasOne("BookStoreAPI.Models.Order", null)
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookStoreAPI.Models.Cart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("BookStoreAPI.Models.Order", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}