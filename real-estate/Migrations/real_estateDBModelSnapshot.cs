﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using real_estate.Models;

#nullable disable

namespace real_estate.Migrations
{
    [DbContext(typeof(real_estateDB))]
    partial class real_estateDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("real_estate.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("real_estate.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NationalId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("real_estate.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<int>("propertyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("clientId");

                    b.HasIndex("employeeId");

                    b.HasIndex("propertyId")
                        .IsUnique();

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("real_estate.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("real_estate.Models.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ContractId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Features")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumBathrooms")
                        .HasColumnType("int");

                    b.Property<int>("NumBedrooms")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("PropertyImg")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PropertySize")
                        .HasColumnType("int");

                    b.Property<int>("PropertyStatusId")
                        .HasColumnType("int");

                    b.Property<int>("PropertyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("cityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PropertyStatusId");

                    b.HasIndex("PropertyTypeId");

                    b.HasIndex("cityId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("real_estate.Models.property_status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("real_estate.Models.property_type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("real_estate.Models.Contract", b =>
                {
                    b.HasOne("real_estate.Models.Client", "client")
                        .WithMany("Contracts")
                        .HasForeignKey("clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("real_estate.Models.Employee", "employee")
                        .WithMany("contracts")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("real_estate.Models.Property", "property")
                        .WithOne("contract")
                        .HasForeignKey("real_estate.Models.Contract", "propertyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("client");

                    b.Navigation("employee");

                    b.Navigation("property");
                });

            modelBuilder.Entity("real_estate.Models.Property", b =>
                {
                    b.HasOne("real_estate.Models.Employee", "employee")
                        .WithMany("properties")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("real_estate.Models.property_status", "propertyStatus")
                        .WithMany("properties")
                        .HasForeignKey("PropertyStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("real_estate.Models.property_type", "propertyType")
                        .WithMany("properties")
                        .HasForeignKey("PropertyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("real_estate.Models.City", "city")
                        .WithMany("properties")
                        .HasForeignKey("cityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");

                    b.Navigation("employee");

                    b.Navigation("propertyStatus");

                    b.Navigation("propertyType");
                });

            modelBuilder.Entity("real_estate.Models.City", b =>
                {
                    b.Navigation("properties");
                });

            modelBuilder.Entity("real_estate.Models.Client", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("real_estate.Models.Employee", b =>
                {
                    b.Navigation("contracts");

                    b.Navigation("properties");
                });

            modelBuilder.Entity("real_estate.Models.Property", b =>
                {
                    b.Navigation("contract")
                        .IsRequired();
                });

            modelBuilder.Entity("real_estate.Models.property_status", b =>
                {
                    b.Navigation("properties");
                });

            modelBuilder.Entity("real_estate.Models.property_type", b =>
                {
                    b.Navigation("properties");
                });
#pragma warning restore 612, 618
        }
    }
}