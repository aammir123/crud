using System;
using System.Collections.Generic;

namespace CRUDWork.Entities
{
    public partial class User
    {
        public Guid RowId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public Guid RDepartment { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public Department RDepartmentNavigation { get; set; }

        public User()
        {
            LastUpdateDateTime = DateTime.Now;
        }
    }
}
