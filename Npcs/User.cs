using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Npcs
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAdress { get; set; }


        // Propriedade de Navegação
        public virtual ICollection<Task> Tasks { get; set; }
    }
}