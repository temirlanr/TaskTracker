using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.Extensions
{
    public class TaskUpdateOperation
    {
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string Property { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
