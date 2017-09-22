﻿// <auto-generated />
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace DataAccess.Migrations
{
    [DbContext(typeof(PuffContext))]
    [Migration("20170920123959_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("DataAccess.Entity.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<int>("Number");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("DataAccess.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DataAccess.Entity.Cinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdressId");

                    b.Property<string>("Company");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.ToTable("Cinemas");
                });

            modelBuilder.Entity("DataAccess.Entity.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdressId");

                    b.Property<int?>("CreatorId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("IdCreator");

                    b.Property<bool>("IsPublished");

                    b.Property<string>("Name");

                    b.Property<int>("NbMaxOfParticipant");

                    b.Property<string>("RendezVousPoint");

                    b.Property<string>("Resume");

                    b.HasKey("Id");

                    b.HasIndex("AdressId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("DataAccess.Entity.EventHosts", b =>
                {
                    b.Property<int>("EventId");

                    b.Property<int>("UserId");

                    b.HasKey("EventId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("EventHosts");
                });

            modelBuilder.Entity("DataAccess.Entity.EventParticipants", b =>
                {
                    b.Property<int>("EventId");

                    b.Property<int>("UserId");

                    b.HasKey("EventId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("EventParticipants");
                });

            modelBuilder.Entity("DataAccess.Entity.InfoUser", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("Description");

                    b.HasKey("UserId");

                    b.ToTable("InfoUsers");
                });

            modelBuilder.Entity("DataAccess.Entity.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Actors");

                    b.Property<string>("Name");

                    b.Property<int>("PG");

                    b.Property<string>("Real");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Synopsis");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("DataAccess.Entity.MovieCategory", b =>
                {
                    b.Property<int>("CategoryId");

                    b.Property<int>("MovieId");

                    b.HasKey("CategoryId", "MovieId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieCategory");
                });

            modelBuilder.Entity("DataAccess.Entity.Seance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CinemaId");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("MovieId");

                    b.Property<decimal?>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.HasIndex("MovieId");

                    b.ToTable("Seances");
                });

            modelBuilder.Entity("DataAccess.Entity.SeanceEvent", b =>
                {
                    b.Property<int>("EventId");

                    b.Property<int>("SeanceId");

                    b.HasKey("EventId", "SeanceId");

                    b.HasIndex("SeanceId");

                    b.ToTable("SeanceEvent");
                });

            modelBuilder.Entity("DataAccess.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.Property<string>("Password");

                    b.Property<string>("Pseudo");

                    b.Property<string>("Roles");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataAccess.Entity.Vote", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventId1");

                    b.Property<int>("SeanceId");

                    b.Property<int>("UserId");

                    b.HasKey("EventId");

                    b.HasIndex("EventId1");

                    b.HasIndex("SeanceId");

                    b.HasIndex("UserId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("DataAccess.Entity.Cinema", b =>
                {
                    b.HasOne("DataAccess.Entity.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId");
                });

            modelBuilder.Entity("DataAccess.Entity.Event", b =>
                {
                    b.HasOne("DataAccess.Entity.Adress", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId");

                    b.HasOne("DataAccess.Entity.User", "Creator")
                        .WithMany("CreatedEvents")
                        .HasForeignKey("CreatorId");
                });

            modelBuilder.Entity("DataAccess.Entity.EventHosts", b =>
                {
                    b.HasOne("DataAccess.Entity.Event", "Event")
                        .WithMany("Hosts")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Entity.User", "User")
                        .WithMany("HostEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Entity.EventParticipants", b =>
                {
                    b.HasOne("DataAccess.Entity.Event", "Event")
                        .WithMany("Participants")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Entity.User", "User")
                        .WithMany("ParticpationEvents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Entity.InfoUser", b =>
                {
                    b.HasOne("DataAccess.Entity.User", "User")
                        .WithOne("InfoUser")
                        .HasForeignKey("DataAccess.Entity.InfoUser", "UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Entity.MovieCategory", b =>
                {
                    b.HasOne("DataAccess.Entity.Category", "Category")
                        .WithMany("Movies")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Entity.Movie", "Movie")
                        .WithMany("Categories")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Entity.Seance", b =>
                {
                    b.HasOne("DataAccess.Entity.Cinema", "Cinema")
                        .WithMany("Seances")
                        .HasForeignKey("CinemaId");

                    b.HasOne("DataAccess.Entity.Movie", "Movie")
                        .WithMany("Seances")
                        .HasForeignKey("MovieId");
                });

            modelBuilder.Entity("DataAccess.Entity.SeanceEvent", b =>
                {
                    b.HasOne("DataAccess.Entity.Event", "Event")
                        .WithMany("Seances")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Entity.Seance", "Seance")
                        .WithMany("Events")
                        .HasForeignKey("SeanceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DataAccess.Entity.Vote", b =>
                {
                    b.HasOne("DataAccess.Entity.Event", "Event")
                        .WithMany("Votes")
                        .HasForeignKey("EventId1");

                    b.HasOne("DataAccess.Entity.Seance", "Seance")
                        .WithMany("Votes")
                        .HasForeignKey("SeanceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataAccess.Entity.User", "User")
                        .WithMany("Votes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
