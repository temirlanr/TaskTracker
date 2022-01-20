using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Entities;

namespace TaskTracker.Services
{
    public interface IProjectService
    {
        IEnumerable<Project> GetProjects();
        Project GetProjectById(int projectId);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int projectId);
        IEnumerable<ProjectTask> GetTasks(int projectId);
        ProjectTask GetTaskById(int projectId, int taskId);
        void CreateTask(int projectId, ProjectTask task);
        void UpdateTask(int projectId, ProjectTask task);
        void DeleteTask(int projectId, int taskId);

    }
}
