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

        public void ValidateProjectStatus(Project project)
        {
            if (!ProjectStatus.Contains(project.Status))
            {
                throw new Exception("Invalid project status.");
            }
        }

        public void ValidateTaskStatus(ProjectTask task)
        {
            if (!TaskStatus.Contains(task.Status))
            {
                throw new Exception("Invalid task status.");
            }
        }
    }
}
