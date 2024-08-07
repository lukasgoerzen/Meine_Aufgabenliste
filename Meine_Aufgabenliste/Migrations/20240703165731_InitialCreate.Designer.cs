﻿// <auto-generated />
using Meine_Aufgabenliste.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Meine_Aufgabenliste.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240703165731_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Meine_Aufgabenliste.Models.Kategorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Kategorie");
                });

            modelBuilder.Entity("Meine_Aufgabenliste.Models.Schluesselwort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("KategorieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("KategorieId");

                    b.ToTable("Schluesselwort");
                });

            modelBuilder.Entity("Meine_Aufgabenliste.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Meine_Aufgabenliste.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aufgabe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("KategorieId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Loesung")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SchluesselwortId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StatusId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VerantwortlicherId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("KategorieId");

                    b.HasIndex("SchluesselwortId");

                    b.HasIndex("StatusId");

                    b.HasIndex("VerantwortlicherId");

                    b.ToTable("ToDos");
                });

            modelBuilder.Entity("Meine_Aufgabenliste.Models.Verantwortlicher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Verantwortlicher");
                });

            modelBuilder.Entity("Meine_Aufgabenliste.Models.Schluesselwort", b =>
                {
                    b.HasOne("Meine_Aufgabenliste.Models.Kategorie", "Kategorie")
                        .WithMany()
                        .HasForeignKey("KategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategorie");
                });

            modelBuilder.Entity("Meine_Aufgabenliste.Models.ToDo", b =>
                {
                    b.HasOne("Meine_Aufgabenliste.Models.Kategorie", "Kategorie")
                        .WithMany()
                        .HasForeignKey("KategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Meine_Aufgabenliste.Models.Schluesselwort", "Schluesselwort")
                        .WithMany()
                        .HasForeignKey("SchluesselwortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Meine_Aufgabenliste.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Meine_Aufgabenliste.Models.Verantwortlicher", "Verantwortlicher")
                        .WithMany()
                        .HasForeignKey("VerantwortlicherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategorie");

                    b.Navigation("Schluesselwort");

                    b.Navigation("Status");

                    b.Navigation("Verantwortlicher");
                });
#pragma warning restore 612, 618
        }
    }
}
