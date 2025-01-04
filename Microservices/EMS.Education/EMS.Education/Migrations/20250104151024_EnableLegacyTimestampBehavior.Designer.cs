﻿// <auto-generated />
using System;
using EMS.Education.PersistenceLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EMS.Education.Migrations
{
    [DbContext(typeof(EducationDbContext))]
    [Migration("20250104151024_EnableLegacyTimestampBehavior")]
    partial class EnableLegacyTimestampBehavior
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EMS.Education.Domain.Education", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Degree")
                        .HasColumnType("text");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<string>("Occupation")
                        .HasColumnType("text");

                    b.Property<string>("SchoolName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Education");
                });

            modelBuilder.Entity("EMS.Education.Domain.Education", b =>
                {
                    b.OwnsOne("EMS.Shared.Models.TerminalDatePeriod", "Period", b1 =>
                        {
                            b1.Property<Guid>("EducationId")
                                .HasColumnType("uuid");

                            b1.Property<DateTime>("End")
                                .HasColumnType("timestamp without time zone");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("timestamp without time zone");

                            b1.HasKey("EducationId");

                            b1.ToTable("Education");

                            b1.WithOwner()
                                .HasForeignKey("EducationId");
                        });

                    b.Navigation("Period")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
