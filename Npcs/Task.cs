using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Npcs
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ConclusionDate { get; set; }
        public TaskStatus Status { get; set; }

        // Foreign Key UserId
        public int UserId { get; set; }
        // Propriedade de Navegação
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        // Foreign Key CategoryId
        public int? CategoryId { get; set; }

        // Propriedade de Navegação
        public virtual Category Category { get; set; }
    }
}