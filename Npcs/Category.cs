using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Npcs
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        // Navegação
        public virtual ICollection<Task> Tasks { get; set; }

    }
}