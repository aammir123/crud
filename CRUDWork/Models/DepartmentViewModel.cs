using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDWork.Models
{
    public class DepartmentViewModel
    {
        public Guid? RowId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Active { get; set; }
        public int NoOfUsers { get; set; }
    }
}
