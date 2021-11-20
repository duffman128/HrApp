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
                e.Property(e => e.DateOfBirth)
                 .HasConversion(
                    d => d.ToDateTime(new TimeOnly(0, 0)),
                    dt => new DateOnly(dt.Year, dt.Month, dt.Day));
            });
            modelBuilder = SetCommonDataDefaults<Employee>(modelBuilder);

            modelBuilder.Entity<Address>(a =>
            {
                a.Property(a => a.Id)
                 .HasDefaultValueSql("NEWID()");

                a.HasCheckConstraint("CHK_Address_Complex",
                    "ComplexNumber IS NOT NULL AND ComplexName IS NOT NULL");

                a.HasCheckConstraint("CHK_Address_PostalCode",
                    "PostalCode IS NOT NULL AND (Type = 'Residential' OR IsSameAsResidential = 1)");
            });
            modelBuilder = SetCommonDataDefaults<Address>(modelBuilder);

            modelBuilder.Entity<EmployeeAddress>(ea =>
            {
                ea.HasKey(ea => new { ea.EmployeeId, ea.AddressId });
                ea.HasOne(ea => ea.Employee).WithMany(e => e.EmployeeAddresses).HasForeignKey(ea => ea.EmployeeId);
                ea.HasOne(ea => ea.Address).WithMany(a => a.EmployeeAddresses).HasForeignKey(ea => ea.AddressId);
            });
            modelBuilder = SetCommonDataDefaults<EmployeeAddress>(modelBuilder);

            modelBuilder.Entity<ContactDetail>(c =>
            {
                c.Property(c => c.Id)
                 .HasDefaultValueSql("NEWID()");

                c.Property(c => c.Type)
                 .HasConversion(
                    t => t.ToString().Replace('_', ' '),
                    t => Enum.Parse<ContactDetailType>(t.Replace(' ', '_'))
                );

                c.HasOne(c => c.Employee)
                 .WithMany(e => e.ContactDetails);
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