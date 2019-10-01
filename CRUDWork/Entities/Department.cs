using System;
using System.Collections.Generic;

namespace CRUDWork.Entities
{
    public partial class Department
    {
        public Department()
        {
            User = new HashSet<User>();
        }

        public Guid RowId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public int Active { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public ICollection<User> User { get; set; }
    }
}
