﻿// <auto-generated />
using System.Collections.Generic;
using LicenseData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LicenseData.Migrations
{
    [DbContext(typeof(LicenseContext))]
    [Migration("20200721104215_CreateTable")]
    partial class CreateTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("LicenseData.License", b =>
                {
                    b.Property<string>("ID")
                        .HasColumnType("text");

                    b.Property<List<string>>("Conditions")
                        .HasColumnType("text[]");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("LicenseText")
                        .HasColumnType("text");

                    b.Property<List<string>>("Limitations")
                        .HasColumnType("text[]");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<List<string>>("Permissions")
                        .HasColumnType("text[]");

                    b.Property<string>("URL")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("licenses");
                });
#pragma warning restore 612, 618
        }
    }
}
