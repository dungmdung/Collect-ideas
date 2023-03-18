﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230317021354_FixTable")]
    partial class FixTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CategoryIdea", b =>
                {
                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.Property<int>("IdeasId")
                        .HasColumnType("int");

                    b.HasKey("CategoriesId", "IdeasId");

                    b.HasIndex("IdeasId");

                    b.ToTable("IdeaCategories", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CommentContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateSubmitted")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdeaId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdeaId");

                    b.HasIndex("UserId");

                    b.ToTable("Comment", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EventDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FirstClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastClosingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Event", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Idea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateSubmitted")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("File")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdeaDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdeaTitle")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Idea", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdeaId")
                        .HasColumnType("int");

                    b.Property<string>("NotificationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdeaId");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("Data.Entities.Thumb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("IdeaId")
                        .HasColumnType("int");

                    b.Property<int>("ThumbType")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdeaId");

                    b.HasIndex("UserId");

                    b.ToTable("Thumb", (string)null);
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("CategoryIdea", b =>
                {
                    b.HasOne("Data.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Entities.Idea", null)
                        .WithMany()
                        .HasForeignKey("IdeasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Entities.Comment", b =>
                {
                    b.HasOne("Data.Entities.Idea", "Ideas")
                        .WithMany("Comments")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "Users")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ideas");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Data.Entities.Idea", b =>
                {
                    b.HasOne("Data.Entities.Event", "Events")
                        .WithMany("Ideas")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "Users")
                        .WithMany("Ideas")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Events");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Data.Entities.Notification", b =>
                {
                    b.HasOne("Data.Entities.Idea", "Ideas")
                        .WithMany("Notifications")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ideas");
                });

            modelBuilder.Entity("Data.Entities.Thumb", b =>
                {
                    b.HasOne("Data.Entities.Idea", "Ideas")
                        .WithMany("Thumbs")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "Users")
                        .WithMany("Thumbs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ideas");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Data.Entities.Event", b =>
                {
                    b.Navigation("Ideas");
                });

            modelBuilder.Entity("Data.Entities.Idea", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Notifications");

                    b.Navigation("Thumbs");
                });

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Ideas");

                    b.Navigation("Thumbs");
                });
#pragma warning restore 612, 618
        }
    }
}
