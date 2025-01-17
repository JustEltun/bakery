﻿// <auto-generated />
using System;
using BakeryCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BakeryCore.Migrations
{
    [DbContext(typeof(BakeryContext))]
    partial class BakeryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("BakeryCore.Models.Bun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    b.Property<DateTime>("BakingTime")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "bakingTime");

                    b.Property<DateTime>("ExpiredTime")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "expiredTime");

                    b.Property<double>("Price")
                        .HasColumnType("REAL")
                        .HasAnnotation("Relational:JsonPropertyName", "price");

                    b.Property<int>("SaleTimeInHour")
                        .HasColumnType("INTEGER")
                        .HasAnnotation("Relational:JsonPropertyName", "saleTime");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT")
                        .HasAnnotation("Relational:JsonPropertyName", "type");

                    b.HasKey("Id");

                    b.ToTable("Buns");
                });
#pragma warning restore 612, 618
        }
    }
}
