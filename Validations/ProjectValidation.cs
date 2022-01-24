using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Entities;
using TaskTracker.Exceptions;

namespace TaskTracker.Validations
{
    public class ProjectValidation : IProjectValidation
    {
        private readonly List<string> projectStatus = new() { "NotStarted", "Active", "Completed" };
        private readonly List<string> taskStatus = new() { "ToDo", "InProgress", "Done" };

        public void ValidateProjectStatus(string status)
        {
            if (!projectStatus.Contains(status))
            {
                throw new InvalidStatusException("Invalid project status.");
            }
        }

        public void ValidateTaskStatus(string status)
        {
            if (!taskStatus.Contains(status))
            {
                throw new InvalidStatusException("Invalid task status.");
            }
        }

        public void ValidateTaskId(List<ProjectTask> tasks)
        {
            var temp = new List<int>();
            foreach(var task in tasks)
            {
                if (temp.Contains(task.Id))
                {
                    throw new InvalidTaskIdException("Task ID(-s) not unique.");
                }
                else
                {
                    temp.Add(task.Id);
                }
            }
        }
    }
}
