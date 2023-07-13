﻿// <auto-generated />
using BookCollection.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable enable

namespace BookCollection.Migrations
{
    [DbContext(typeof(BookCollectionDbContext))]
    partial class BookCollectionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.9");

            modelBuilder.Entity("BookCollection.Db.Entities.BookDbEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string?>("Publisher")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Title", "Author", "Year")
                        .IsUnique()
                        .HasDatabaseName("IX_TitleAuthorYear");

                    b.ToTable("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
