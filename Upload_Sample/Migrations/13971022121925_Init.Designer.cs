﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Upload_Sample.Models;

namespace Upload_Sample.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("13971022121925_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("Upload_Sample.Models.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArtistId");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.Property<int>("TrackCount");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("Upload_Sample.Models.Entities.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.Property<DateTime>("TimeCreated");

                    b.HasKey("Id");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Upload_Sample.Models.Entities.Podcast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ArtistName");

                    b.Property<DateTime>("CreateDate");

                    b.Property<string>("Image");

                    b.Property<string>("PodcastName");

                    b.Property<string>("TrackFile");

                    b.HasKey("Id");

                    b.ToTable("Podcasts");
                });

            modelBuilder.Entity("Upload_Sample.Models.Entities.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImagePath");

                    b.Property<string>("Manager");

                    b.Property<DateTime>("ProjectCreated");

                    b.Property<string>("ProjectName");

                    b.HasKey("ProjectId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Upload_Sample.Models.Entities.Album", b =>
                {
                    b.HasOne("Upload_Sample.Models.Entities.Artist", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}