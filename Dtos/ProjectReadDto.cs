using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Entities;

namespace TaskTracker.Dtos
{
    public class ProjectReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset CompleteDate { get; set; }
        public List<TaskReadDto> Tasks { get; set; }
    }
}
