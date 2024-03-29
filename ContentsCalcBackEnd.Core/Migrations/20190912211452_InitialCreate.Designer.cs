﻿// <auto-generated />
using System;
using ContentsCalcBackEnd.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ContentsCalcBackEnd.Core.Migrations
{
    [DbContext(typeof(CalculatorDbContext))]
    [Migration("20190912211452_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ContentsCalcBackEnd.Core.Models.ContentsCalculatorItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContentsCategoryTypeId");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<double>("Value");

                    b.HasKey("Id");

                    b.HasIndex("ContentsCategoryTypeId");

                    b.ToTable("ContentsCalculatorItems");
                });

            modelBuilder.Entity("ContentsCalcBackEnd.Core.Models.ContentsCategoryType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("ContentsCategoryTypes");
                });

            modelBuilder.Entity("ContentsCalcBackEnd.Core.Models.ContentsCalculatorItem", b =>
                {
                    b.HasOne("ContentsCalcBackEnd.Core.Models.ContentsCategoryType", "ContentsCategoryType")
                        .WithMany()
                        .HasForeignKey("ContentsCategoryTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
