using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrApp.Persistence.EfCore
{
    public class HrAppContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }

        public HrAppContext(DbContextOptions<HrAppContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(e =>
            {
                e.Property(e => e.Id)
                 .HasDefaultValueSql("NEWID()");
                e.HasIndex(e => e.EmployeeNumber)
                 .IsUnique();
            });
            modelBuilder = SetCommonDataDefaults<Employee>(modelBuilder);

            modelBuilder.Entity<Address>(a =>
            {
                a.Property(a => a.Id)
                 .HasDefaultValueSql("NEWID()");

                a.HasCheckConstraint("Complex",
                    "[ComplexNumber] IS NOT NULL AND [ComplexName] IS NOT NULL");

                a.HasCheckConstraint("PostalCode",
                    $"[PostalCode] IS NOT NULL AND ([Type] = '{AddressType.Postal}' OR [IsSameAsResidential] = 1)");

                a.HasCheckConstraint("AddressType",
                    $"[Type] = '{AddressType.Postal}' OR [Type] = '{AddressType.Residential}'");

                a.HasIndex(a => 
                new 
                { 
                    a.StreetName,
                    a.StreetNumber,
                    a.ComplexName,
                    a.ComplexNumber,
                    a.Suburb,
                    a.City,
                    a.EmployeeId
                })
                 .IsUnique();


                a.HasOne(a => a.Employee)
                 .WithMany(e => e.Addresses)
                 .HasForeignKey(a => a.EmployeeId);
            });
            modelBuilder = SetCommonDataDefaults<Address>(modelBuilder);

            modelBuilder.Entity<ContactDetail>(c =>
            {
                c.Property(c => c.Id)
                 .HasDefaultValueSql("NEWID()");

                c.HasIndex(c => new { c.ContactInfo, c.EmployeeId })
                 .IsUnique();

                c.Property(c => c.Type)
                 .HasConversion(
                    t => t.ToString().Replace('_', ' '),
                    t => Enum.Parse<ContactDetailType>(t.Replace(' ', '_'))
                );

                c.HasCheckConstraint("ContactDetailType",
                    $"[Type] = '{ContactDetailType.Email}' OR [Type] = '{ContactDetailType.Cellphone}' OR [Type] = '{ContactDetailType.Social_Media.ToString().Replace('_', ' ')}' OR [Type] = '{ContactDetailType.Landline}'");


                c.HasOne(c => c.Employee)
                 .WithMany(e => e.ContactDetails)
                 .HasForeignKey(c => c.EmployeeId);
            });
            modelBuilder = SetCommonDataDefaults<ContactDetail>(modelBuilder);
        }

        private ModelBuilder SetCommonDataDefaults<T>(ModelBuilder modelBuilder) where T : CommonData
        {
            modelBuilder.Entity<T>()
                .Property(e => e.IsActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<T>()
                .Property(e => e.TimeStampCreated)
                .HasDefaultValueSql("SYSDATETIME()");

            return modelBuilder;
        }
    }
}