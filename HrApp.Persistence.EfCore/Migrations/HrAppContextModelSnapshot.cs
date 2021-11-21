﻿// <auto-generated />
using System;
using HrApp.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HrApp.Persistence.EfCore.Migrations
{
    [DbContext(typeof(HrAppContext))]
    partial class HrAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AddressEmployee", b =>
                {
                    b.Property<Guid>("AddressesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AddressesId", "EmployeesId");

                    b.HasIndex("EmployeesId");

                    b.ToTable("EmployeeAddresses", (string)null);
                });

            modelBuilder.Entity("HrApp.Models.Address", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("ComplexName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("ComplexNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<bool>("IsSameAsResidential")
                        .HasColumnType("bit");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Suburb")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime>("TimeStampCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<DateTime?>("TimeStampModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasCheckConstraint("AddressType", "Type = Postal OR Type = Residential");

                    b.HasCheckConstraint("Complex", "ComplexNumber IS NOT NULL AND ComplexName IS NOT NULL");

                    b.HasCheckConstraint("PostalCode", "PostalCode IS NOT NULL AND (Type = 'Postal' OR IsSameAsResidential = 1)");
                });

            modelBuilder.Entity("HrApp.Models.ContactDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("ContactInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("TimeStampCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<DateTime?>("TimeStampModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.HasIndex("ContactInfo")
                        .IsUnique();

                    b.HasIndex("EmployeeId");

                    b.ToTable("ContactDetails");

                    b.HasCheckConstraint("ContactDetailType", "Type = Email OR Type = Cellphone OR Type = Social Media OR Type = Landline");
                });

            modelBuilder.Entity("HrApp.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeNumber")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime>("TimeStampCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("SYSDATETIME()");

                    b.Property<DateTime?>("TimeStampModified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeNumber")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AddressEmployee", b =>
                {
                    b.HasOne("HrApp.Models.Address", null)
                        .WithMany()
                        .HasForeignKey("AddressesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HrApp.Models.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HrApp.Models.ContactDetail", b =>
                {
                    b.HasOne("HrApp.Models.Employee", "Employee")
                        .WithMany("ContactDetails")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HrApp.Models.Employee", b =>
                {
                    b.Navigation("ContactDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
