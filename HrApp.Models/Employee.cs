using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Models
{
    public class Employee : CommonData
    {
        public Guid Id { get; set; }

        [Required]
        public int EmployeeNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string LastName { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public virtual ICollection<Address> Addresses { get; set; }

        [Required]
        public virtual ICollection<ContactDetail> ContactDetails { get; set; }

    }
}
