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
    [Migration("20230407173359_AddDefaultValue")]
    partial class AddDefaultValue
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

                    b.HasData(
                        new
                        {
                            CategoriesId = 2,
                            IdeasId = 1
                        },
                        new
                        {
                            CategoriesId = 3,
                            IdeasId = 1
                        },
                        new
                        {
                            CategoriesId = 4,
                            IdeasId = 1
                        },
                        new
                        {
                            CategoriesId = 1,
                            IdeasId = 2
                        },
                        new
                        {
                            CategoriesId = 3,
                            IdeasId = 2
                        },
                        new
                        {
                            CategoriesId = 4,
                            IdeasId = 2
                        });
                });

            modelBuilder.Entity("Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryDescription = "Back-end",
                            CategoryName = "Python"
                        },
                        new
                        {
                            Id = 2,
                            CategoryDescription = "Back-end",
                            CategoryName = "ASP .Net Core"
                        },
                        new
                        {
                            Id = 3,
                            CategoryDescription = "Front-end",
                            CategoryName = "Angular"
                        },
                        new
                        {
                            Id = 4,
                            CategoryDescription = "Front-end",
                            CategoryName = "ReactJS"
                        });
                });

            modelBuilder.Entity("Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CommentContent")
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CommentContent = "string",
                            DateSubmitted = new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(5145),
                            IdeaId = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            CommentContent = "string",
                            DateSubmitted = new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(5149),
                            IdeaId = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            CommentContent = "string",
                            DateSubmitted = new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(5150),
                            IdeaId = 1,
                            UserId = 5
                        },
                        new
                        {
                            Id = 4,
                            CommentContent = "string",
                            DateSubmitted = new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(5150),
                            IdeaId = 2,
                            UserId = 3
                        },
                        new
                        {
                            Id = 5,
                            CommentContent = "string",
                            DateSubmitted = new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(5151),
                            IdeaId = 2,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Data.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EventDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EventName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FirstClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastClosingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Event", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventDescription = "Software engineer",
                            EventName = "IT talk show",
                            FirstClosingDate = new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(4840),
                            LastClosingDate = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            UserId = 4
                        },
                        new
                        {
                            Id = 2,
                            EventDescription = "Block Chain",
                            EventName = "Business talk show",
                            FirstClosingDate = new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(4848),
                            LastClosingDate = new DateTime(9999, 12, 31, 23, 59, 59, 999, DateTimeKind.Unspecified).AddTicks(9999),
                            UserId = 5
                        });
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashTag")
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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateSubmitted = new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(4858),
                            EventId = 1,
                            File = "Demo.docx",
                            HashTag = "#IT",
                            IdeaDescription = "What do you need to be a software engineer?",
                            IdeaTitle = "Question",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            DateSubmitted = new DateTime(2023, 4, 8, 0, 33, 58, 880, DateTimeKind.Local).AddTicks(4859),
                            EventId = 2,
                            File = "Demo.docx",
                            HashTag = "#Business",
                            IdeaDescription = "What do you need to be a software engineer?",
                            IdeaTitle = "Question",
                            UserId = 6
                        });
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
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdeaId");

                    b.ToTable("Notification", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdeaId = 1,
                            NotificationName = "string 123"
                        },
                        new
                        {
                            Id = 2,
                            IdeaId = 2,
                            NotificationName = "string 1234"
                        });
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

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<DateTime>("DoB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("nvarchar(225)");

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

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = 1,
                            DoB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tonydo0307@gmail.com",
                            FullName = "Staff",
                            Password = "123456",
                            PhoneNumber = 11112222,
                            Role = 0,
                            UserName = "Staff"
                        },
                        new
                        {
                            Id = 2,
                            Department = 0,
                            DoB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tonydo0307@gmail.com",
                            FullName = "Admin",
                            Password = "123456",
                            PhoneNumber = 11112222,
                            Role = 1,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Department = 0,
                            DoB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tonydo0307@gmail.com",
                            FullName = "QAManager",
                            Password = "123456",
                            PhoneNumber = 11112222,
                            Role = 2,
                            UserName = "QAManager"
                        },
                        new
                        {
                            Id = 4,
                            Department = 1,
                            DoB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tonydo0307@gmail.com",
                            FullName = "QACoordinator",
                            Password = "123456",
                            PhoneNumber = 11112222,
                            Role = 3,
                            UserName = "QACoordinator"
                        },
                        new
                        {
                            Id = 5,
                            Department = 2,
                            DoB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tonydo0307@gmail.com",
                            FullName = "QACoordinator1",
                            Password = "123456",
                            PhoneNumber = 11112222,
                            Role = 3,
                            UserName = "QACoordinator1"
                        },
                        new
                        {
                            Id = 6,
                            Department = 2,
                            DoB = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "tonydo0307@gmail.com",
                            FullName = "Staff1",
                            Password = "123456",
                            PhoneNumber = 11112222,
                            Role = 0,
                            UserName = "Staff1"
                        });
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
                    b.HasOne("Data.Entities.Idea", "Idea")
                        .WithMany("Comments")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Idea");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Event", b =>
                {
                    b.HasOne("Data.Entities.User", "User")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Idea", b =>
                {
                    b.HasOne("Data.Entities.Event", "Event")
                        .WithMany("Ideas")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany("Ideas")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Data.Entities.Notification", b =>
                {
                    b.HasOne("Data.Entities.Idea", "Idea")
                        .WithMany("Notifications")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Idea");
                });

            modelBuilder.Entity("Data.Entities.Thumb", b =>
                {
                    b.HasOne("Data.Entities.Idea", "Idea")
                        .WithMany("Thumbs")
                        .HasForeignKey("IdeaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Data.Entities.User", "User")
                        .WithMany("Thumbs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Idea");

                    b.Navigation("User");
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

                    b.Navigation("Events");

                    b.Navigation("Ideas");

                    b.Navigation("Thumbs");
                });
#pragma warning restore 612, 618
        }
    }
}
