using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Entities
{
    public class Project : BaseEntity
    {

        private DateTimeOffset startDate;
        [Required]
        public DateTimeOffset StartDate { get { return startDate; } set { startDate = value; } }
        private DateTimeOffset completeDate;
        [Required]
        public DateTimeOffset CompleteDate { get { return completeDate; } set { completeDate = value; } }
        private List<ProjectTask> tasks;
        [Column(TypeName = "jsonb")]
        public List<ProjectTask> Tasks { get { return tasks; } set { tasks = value; } }
    }
}
