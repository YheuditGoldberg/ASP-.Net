﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using myProjectMVC.Data;

#nullable disable

namespace myProjectMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240112002131_AddCitiesToDatabase")]
    partial class AddCitiesToDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("myProjectMVC.Models.City", b =>
                {
                    b.Property<int>("cityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cityID"), 1L, 1);

                    b.Property<string>("cityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cityID");

                    b.ToTable("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}