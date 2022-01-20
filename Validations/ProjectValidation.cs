using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Entities;

namespace TaskTracker.Validations
{
    public class ProjectValidation : IProjectValidation
    {
        private readonly List<string> ProjectStatus = new() { "NotStarted", "Active", "Completed" };
        private readonly List<string> TaskStatus = new() { "ToDo", "InProgress", "Done" };

        public void ValidateProjectStatus(string projectStatus)
        {
            if (!ProjectStatus.Contains(projectStatus))
            {
                throw new Exception("Invalid project status.");
            }
        }

        public void ValidateTaskStatus(string taskStatus)
        {
            if (!TaskStatus.Contains(taskStatus))
            {
                throw new Exception("Invalid task status.");
            }
        }
    }
}
