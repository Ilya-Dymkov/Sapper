﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sapper.DataContext;

#nullable disable

namespace Sapper.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240904210931_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Sapper.Models.GameInfoResponse", b =>
                {
                    b.Property<Guid>("Game_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Completed")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("CountSafeCells")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<uint>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<uint>("Mines_count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TrueField")
                        .HasColumnType("TEXT");

                    b.Property<uint>("Width")
                        .HasColumnType("INTEGER");

                    b.HasKey("Game_id");

                    b.ToTable("GameInfoResponses");
                });
#pragma warning restore 612, 618
        }
    }
}
