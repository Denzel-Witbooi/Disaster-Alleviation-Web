﻿// <auto-generated />
using System;
using Disaster_Alleviation_Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Disaster_Alleviation_Web.Migrations
{
    [DbContext(typeof(DisasterReliefContext))]
    [Migration("20230727193605_CreateDRData")]
    partial class CreateDRData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.19")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Disaster_Alleviation_Web.Models.AidType", b =>
                {
                    b.Property<int>("AidTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AidTypeID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AidTypeID");

                    b.ToTable("AidType", (string)null);
                });

            modelBuilder.Entity("Disaster_Alleviation_Web.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Disaster_Alleviation_Web.Models.Disaster", b =>
                {
                    b.Property<int>("DisasterID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisasterID"), 1L, 1);

                    b.Property<int>("AidTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DisasterID");

                    b.HasIndex("AidTypeID");

                    b.ToTable("Disaster", (string)null);
                });

            modelBuilder.Entity("Disaster_Alleviation_Web.Models.Donation.Good", b =>
                {
                    b.Property<int>("GoodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GoodID"), 1L, 1);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisasterID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfItems")
                        .HasColumnType("int");

                    b.HasKey("GoodID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("DisasterID");

                    b.ToTable("Good", (string)null);
                });

            modelBuilder.Entity("Disaster_Alleviation_Web.Models.Donation.Monetary", b =>
                {
                    b.Property<int>("MonetaryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MonetaryID"), 1L, 1);

                    b.Property<decimal>("DonationAmount")
                        .HasColumnType("money");

                    b.Property<DateTime>("DonationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DonorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MonetaryID");

                    b.ToTable("Monetary", (string)null);
                });

            modelBuilder.Entity("Disaster_Alleviation_Web.Models.GoodsPurchase", b =>
                {
                    b.Property<int>("GoodsPurchaseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GoodsPurchaseId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisasterId")
                        .HasColumnType("int");

                    b.Property<int>("MonetaryId")
                        .HasColumnType("int");

                    b.Property<decimal>("purchaseAmount")
                        .HasColumnType("money");

                    b.HasKey("GoodsPurchaseId");

                    b.HasIndex("DisasterId");

                    b.HasIndex("MonetaryId");

                    b.ToTable("GoodsPurchase", (string)null);
                });

            modelBuilder.Entity("Disaster_Alleviation_Web.Models.Disaster", b =>
                {
                    b.HasOne("Disaster_Alleviation_Web.Models.AidType", "AidType")
                        .WithMany("Disasters")
                        .HasForeignKey("AidTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AidType");
                });

            modelBuilder.Entity("Disaster_Alleviation_Web.Models.Donation.Good", b =>
                {
                    b.HasOne("Disaster_Alleviation_Web.Models.Category", "Category")
                        .WithMany("Goods")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Disaster_Alleviation_Web.Models.Disaster", "Disaster")
                        .WithMany("Goods")
                        .HasForeignKey("DisasterID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Disaster");
                });

            modelBuilder.Entity("Disaster_Alleviation_Web.Models.GoodsPurchase", b =>
                {
                    b.HasOne("Disaster_Alleviation_Web.Models.Disaster", "Disaster")
                        .WithMany()
                        .HasForeignKey("DisasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Disaster_Alleviation_Web.Models.Donation.Monetary", "Monetary")
                        .WithMany()
                        .HasForeignKey("MonetaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disaster");

                    b.Navigation("Monetary");
                });

            modelBuilder.Entity("Disaster_Alleviation_Web.Models.AidType", b =>
                {
                    b.Navigation("Disasters");
                });

            modelBuilder.Entity("Disaster_Alleviation_Web.Models.Category", b =>
                {
                    b.Navigation("Goods");
                });

            modelBuilder.Entity("Disaster_Alleviation_Web.Models.Disaster", b =>
                {
                    b.Navigation("Goods");
                });
#pragma warning restore 612, 618
        }
    }
}