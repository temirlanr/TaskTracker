using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Dtos
{
    public class ProjectCreateDto
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset CompleteDate { get; set; }
    }
}
