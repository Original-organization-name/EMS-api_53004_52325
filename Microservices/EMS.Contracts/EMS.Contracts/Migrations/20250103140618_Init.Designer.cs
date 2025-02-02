﻿// <auto-generated />
using System;
using EMS.Contracts.PersistenceLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EMS.Contracts.Migrations
{
    [DbContext(typeof(ContractsDbContext))]
    [Migration("20250103140618_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EMS.Contracts.Domain.Dictionaries.PositionItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PositionDict");
                });

            modelBuilder.Entity("EMS.Contracts.Domain.Dictionaries.WorkplaceItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("WorkplaceDict");
                });

            modelBuilder.Entity("EMS.Contracts.Domain.Entities.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("ConclusionDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ContractType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EmploymentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FteDenominator")
                        .HasColumnType("integer");

                    b.Property<int>("FteNumerator")
                        .HasColumnType("integer");

                    b.Property<string>("OccupationCodeItemId")
                        .HasColumnType("text");

                    b.Property<Guid?>("PositionItemId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("Salary")
                        .HasColumnType("numeric");

                    b.Property<int>("SalaryType")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("TerminationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid?>("WorkplaceItemId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OccupationCodeItemId");

                    b.HasIndex("PositionItemId");

                    b.HasIndex("WorkplaceItemId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("EMS.Contracts.Domain.Entities.OccupationCodeItem", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.ToTable("OccupationCodeDict");
                });

            modelBuilder.Entity("EMS.Contracts.Domain.Entities.Contract", b =>
                {
                    b.HasOne("EMS.Contracts.Domain.Entities.OccupationCodeItem", "OccupationCodeItem")
                        .WithMany()
                        .HasForeignKey("OccupationCodeItemId");

                    b.HasOne("EMS.Contracts.Domain.Dictionaries.PositionItem", "PositionItem")
                        .WithMany()
                        .HasForeignKey("PositionItemId");

                    b.HasOne("EMS.Contracts.Domain.Dictionaries.WorkplaceItem", "WorkplaceItem")
                        .WithMany()
                        .HasForeignKey("WorkplaceItemId");

                    b.Navigation("OccupationCodeItem");

                    b.Navigation("PositionItem");

                    b.Navigation("WorkplaceItem");
                });
#pragma warning restore 612, 618
        }
    }
}
