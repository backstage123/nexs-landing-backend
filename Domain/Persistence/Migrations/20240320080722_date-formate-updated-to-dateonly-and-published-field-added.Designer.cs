﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240320080722_date-formate-updated-to-dateonly-and-published-field-added")]
    partial class dateformateupdatedtodateonlyandpublishedfieldadded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Notice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("character varying(50)")
                        .HasColumnName("author_name");

                    b.Property<string>("Content")
                        .HasMaxLength(2147483647)
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("Created")
                        .HasColumnType("date")
                        .HasColumnName("created");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("title");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("date")
                        .HasColumnName("updated");

                    b.HasKey("Id");

                    b.HasIndex("AuthorName");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("notice", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ProviderUserAccount", b =>
                {
                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("user_name");

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("full_name");

                    b.Property<bool>("IsAdmin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_admin");

                    b.Property<string>("ProviderName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("provider_name");

                    b.HasKey("UserName");

                    b.ToTable("provider_user_account", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Notice", b =>
                {
                    b.HasOne("Domain.Entities.ProviderUserAccount", null)
                        .WithMany()
                        .HasForeignKey("AuthorName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}