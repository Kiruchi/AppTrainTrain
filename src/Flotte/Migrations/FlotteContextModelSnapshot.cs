﻿// <auto-generated />
using System;
using Flotte.Web.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flotte.Web.Migrations
{
    [DbContext(typeof(FlotteContext))]
    partial class FlotteContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Flotte.Web.Locomotives.Locomotive", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TractionMax")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Locomotives");
                });

            modelBuilder.Entity("Flotte.Web.Wagons.Wagon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacite")
                        .HasColumnType("int");

                    b.Property<string>("Marque")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modele")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Poids")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Wagons");
                });
#pragma warning restore 612, 618
        }
    }
}
