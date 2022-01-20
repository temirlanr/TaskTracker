using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Entities
{
    public class BaseEntity
    {
        private int id;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get { return id; } set { id = value; } }
        private string name;
        [Required]
        public string Name { get { return name; } set { name = value; } }
        private string status;
        [Required]
        public string Status { get { return status; } set { status = value; } }
        private string description;
        [Required]
        public string Description { get { return description; } set { description = value; } }
        private int priority;
        [Required]
        public int Priority { get { return priority; } set { priority = value; } }
    }
}
