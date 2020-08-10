using System;
using System.Collections.Generic;
using System.Text;

namespace lab_32_entity_code_first.Models
{
    class Category
    {
        public Category()
        {
            Users = new HashSet<User>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
