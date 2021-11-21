using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Models
{
    public enum AddressType
    {
        Residential,
        Postal
    }

    public class Address : CommonData
    {
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(16)")]
        public string StreetNumber { get; set; } //not sure if there are street numbers with letters. e.g 52A

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string StreetName { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public string ComplexNumber { get; set; }

        [Column(TypeName = "nvarchar(64)")]
        public string ComplexName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string Suburb { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string City { get; set; }

        public string PostalCode { get; set; }

        public bool IsSameAsResidential { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public AddressType Type { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
