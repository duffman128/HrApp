using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HrApp.Persistence.EfCore.Migrations
{
    public partial class InitHrApp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeStampCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    TimeStampModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    StreetNumber = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    ComplexNumber = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    ComplexName = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSameAsResidential = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStampCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    TimeStampModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.CheckConstraint("CK_Addresses_AddressType", "[Type] = 'Postal' OR [Type] = 'Residential'");
                    table.CheckConstraint("CK_Addresses_Complex", "[ComplexNumber] IS NOT NULL AND [ComplexName] IS NOT NULL");
                    table.CheckConstraint("CK_Addresses_PostalCode", "[PostalCode] IS NOT NULL AND ([Type] = 'Postal' OR [IsSameAsResidential] = 1)");
                    table.ForeignKey(
                        name: "FK_Addresses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    ContactInfo = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(16)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStampCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "SYSDATETIME()"),
                    TimeStampModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.Id);
                    table.CheckConstraint("CK_ContactDetails_ContactDetailType", "[Type] = 'Email' OR [Type] = 'Cellphone' OR [Type] = 'Social Media' OR [Type] = 'Landline'");
                    table.ForeignKey(
                        name: "FK_ContactDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_EmployeeId",
                table: "Addresses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StreetName_StreetNumber_ComplexName_ComplexNumber_Suburb_City_EmployeeId",
                table: "Addresses",
                columns: new[] { "StreetName", "StreetNumber", "ComplexName", "ComplexNumber", "Suburb", "City", "EmployeeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_ContactInfo_EmployeeId",
                table: "ContactDetails",
                columns: new[] { "ContactInfo", "EmployeeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_EmployeeId",
                table: "ContactDetails",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeNumber",
                table: "Employees",
                column: "EmployeeNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
