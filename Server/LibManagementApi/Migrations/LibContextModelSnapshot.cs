﻿// <auto-generated />
using System;
using LibManagementApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibManagementApi.Migrations
{
    [DbContext(typeof(LibDbContext))]
    partial class LibContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LibManagementApi.Models.BookBorrowings", b =>
                {
                    b.Property<byte[]>("BookBorrowingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<byte[]>("BookID")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("BorrowDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("UserID")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("BookBorrowingID");

                    b.HasIndex("BookID");

                    b.HasIndex("UserID");

                    b.ToTable("BookBorrowings");
                });

            modelBuilder.Entity("LibManagementApi.Models.BookReturnings", b =>
                {
                    b.Property<byte[]>("BookReturningID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<DateTime>("ActualReturnDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("BookBorrowingID")
                        .IsRequired()
                        .HasColumnType("varbinary(16)");

                    b.HasKey("BookReturningID");

                    b.HasIndex("BookBorrowingID")
                        .IsUnique();

                    b.ToTable("BookReturnings");
                });

            modelBuilder.Entity("LibManagementApi.Models.Books", b =>
                {
                    b.Property<byte[]>("BookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Bookname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("YearofPub")
                        .HasColumnType("text");

                    b.HasKey("BookID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("LibManagementApi.Models.Users", b =>
                {
                    b.Property<byte[]>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LibManagementApi.Models.BookBorrowings", b =>
                {
                    b.HasOne("LibManagementApi.Models.Books", "Book")
                        .WithMany("BookBorrowings")
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LibManagementApi.Models.Users", "User")
                        .WithMany("BookBorrowingForms")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibManagementApi.Models.BookReturnings", b =>
                {
                    b.HasOne("LibManagementApi.Models.BookBorrowings", "BookBorrowing")
                        .WithOne("BookReturning")
                        .HasForeignKey("LibManagementApi.Models.BookReturnings", "BookBorrowingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
