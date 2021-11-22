using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Models
{
    public abstract class CommonData
    {
        public DateTime? TimeStampCreated { get; set; }

        public DateTime? TimeStampModified { get; set; }

        public bool IsActive { get; set; } 
    }
}
