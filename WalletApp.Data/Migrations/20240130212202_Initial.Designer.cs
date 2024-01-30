﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WalletApp.Data;

#nullable disable

namespace WalletApp.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240130212202_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WalletApp.Data.Entities.CardBalance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Balance")
                        .HasColumnType("double precision");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CardBalances");
                });

            modelBuilder.Entity("WalletApp.Data.Entities.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int>("AuthorizedUserId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Pending")
                        .HasColumnType("boolean");

                    b.Property<int>("RecipientId")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AuthorizedUserId");

                    b.HasIndex("RecipientId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("WalletApp.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("PointsDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WalletApp.Data.Entities.CardBalance", b =>
                {
                    b.HasOne("WalletApp.Data.Entities.User", "User")
                        .WithMany("Balances")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WalletApp.Data.Entities.Transaction", b =>
                {
                    b.HasOne("WalletApp.Data.Entities.User", "AuthorizedUser")
                        .WithMany()
                        .HasForeignKey("AuthorizedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WalletApp.Data.Entities.User", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuthorizedUser");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("WalletApp.Data.Entities.User", b =>
                {
                    b.Navigation("Balances");
                });
#pragma warning restore 612, 618
        }
    }
}