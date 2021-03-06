﻿// <auto-generated />
using System;
using FootiniApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FootiniApp.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181003104935_updatedimage25")]
    partial class updatedimage25
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("FootiniApp.API.Models.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BoardType");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Name");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("FootiniApp.API.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AssociatedText");

                    b.Property<int?>("BoardId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("PublicId");

                    b.Property<string>("Url");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.HasIndex("UserId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("FootiniApp.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("Forename");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FootiniApp.API.Models.Value", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("FootiniApp.API.Models.Board", b =>
                {
                    b.HasOne("FootiniApp.API.Models.User", "User")
                        .WithMany("Boards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FootiniApp.API.Models.Image", b =>
                {
                    b.HasOne("FootiniApp.API.Models.Board")
                        .WithMany("Images")
                        .HasForeignKey("BoardId");

                    b.HasOne("FootiniApp.API.Models.User", "User")
                        .WithMany("Images")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
