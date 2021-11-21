using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Models
{
    public enum ContactDetailType
    {
        Landline,
        Cellphone,
        Email,
        Social_Media
    }

    public class ContactDetail : CommonData
    { 
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(64)")]
        public string ContactInfo { get; set; }

        [Column(TypeName = "nvarchar(16)")]
        public ContactDetailType Type { get; set; }

        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
