﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MobilerningBackEnd.Repositories;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MobilearningBackEnd.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221111001803_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MobilerningBackEnd.Models.Activity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("conclusion")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("evaluation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("idTeacher")
                        .HasColumnType("integer");

                    b.Property<string>("imageURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("information")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("introduction")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("process")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<List<string>>("references")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.Property<string>("subtitle")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("task")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("userid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("MobilerningBackEnd.Models.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int>("IdUser")
                        .HasColumnType("integer");

                    b.Property<string>("nivel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("userid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("MobilerningBackEnd.Models.Teacher", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("graduation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("idUser")
                        .HasColumnType("integer");

                    b.Property<int?>("userid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("userid");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("MobilerningBackEnd.Models.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MobilerningBackEnd.Models.UserActivity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<int?>("activityid")
                        .HasColumnType("integer");

                    b.Property<string>("currentStage")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("endDate")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("idActivity")
                        .HasColumnType("integer");

                    b.Property<int>("idUser")
                        .HasColumnType("integer");

                    b.Property<double?>("progress")
                        .IsRequired()
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("startDate")
                        .IsRequired()
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("userid")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("activityid");

                    b.HasIndex("userid");

                    b.ToTable("UserActivities");
                });

            modelBuilder.Entity("MobilerningBackEnd.Models.Word", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("englishDefinition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("englishWord")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("portugueseDefinition")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("portugueseWord")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("userId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("MobilerningBackEnd.Models.Activity", b =>
                {
                    b.HasOne("MobilerningBackEnd.Models.Teacher", "user")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("MobilerningBackEnd.Models.Student", b =>
                {
                    b.HasOne("MobilerningBackEnd.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("MobilerningBackEnd.Models.Teacher", b =>
                {
                    b.HasOne("MobilerningBackEnd.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("user");
                });

            modelBuilder.Entity("MobilerningBackEnd.Models.UserActivity", b =>
                {
                    b.HasOne("MobilerningBackEnd.Models.Activity", "activity")
                        .WithMany()
                        .HasForeignKey("activityid");

                    b.HasOne("MobilerningBackEnd.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userid");

                    b.Navigation("activity");

                    b.Navigation("user");
                });
#pragma warning restore 612, 618
        }
    }
}