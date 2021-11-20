using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Models
{
    public class EmployeeAddress : CommonData
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public Guid AddressId { get; set; }
        public Address Address { get; set; }

    }
}
