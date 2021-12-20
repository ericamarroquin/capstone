﻿// <auto-generated />
using Capstone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Capstone.Migrations
{
    [DbContext(typeof(CapstoneContext))]
    partial class CapstoneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Capstone.Models.ActingCredit", b =>
                {
                    b.Property<int>("ActingCreditId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("ShowId")
                        .HasColumnType("int");

                    b.HasKey("ActingCreditId");

                    b.HasIndex("ActorId");

                    b.HasIndex("ShowId");

                    b.ToTable("ActingCredit");
                });

            modelBuilder.Entity("Capstone.Models.Actor", b =>
                {
                    b.Property<int>("ActorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ActorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("Capstone.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Capstone.Models.GenreShow", b =>
                {
                    b.Property<int>("GenreShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("ShowId")
                        .HasColumnType("int");

                    b.HasKey("GenreShowId");

                    b.HasIndex("GenreId");

                    b.HasIndex("ShowId");

                    b.ToTable("GenreShow");
                });

            modelBuilder.Entity("Capstone.Models.Show", b =>
                {
                    b.Property<int>("ShowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ShowId");

                    b.ToTable("Shows");
                });

            modelBuilder.Entity("Capstone.Models.ActingCredit", b =>
                {
                    b.HasOne("Capstone.Models.Actor", "Actor")
                        .WithMany("JoinEntities")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Capstone.Models.Show", "Show")
                        .WithMany()
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Show");
                });

            modelBuilder.Entity("Capstone.Models.GenreShow", b =>
                {
                    b.HasOne("Capstone.Models.Genre", "Genre")
                        .WithMany("JoinEntities")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Capstone.Models.Show", "Show")
                        .WithMany("JoinEntities")
                        .HasForeignKey("ShowId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Show");
                });

            modelBuilder.Entity("Capstone.Models.Actor", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("Capstone.Models.Genre", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("Capstone.Models.Show", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}