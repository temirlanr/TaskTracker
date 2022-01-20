using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Entities;
using TaskTracker.Extensions;
using TaskTracker.Repositories;
using TaskTracker.Validations;

namespace TaskTracker.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo _repo;
        private readonly IProjectValidation _validation;
        public ProjectService(IProjectRepo repo, IProjectValidation validation)
        {
            _repo = repo;
            _validation = validation;
        }
        public void CreateProject(Project project)
        {
            _validation.ValidateProjectStatus(project.Status);
            _repo.CreateProject(project);
            _repo.SaveChanges();
        }

        public void CreateTask(int projectId, ProjectTask task)
        {
            var existingProject = _repo.GetProjectById(projectId);

            if(existingProject == null)
            {
                throw new Exception("Project not found.");
            }

            _validation.ValidateTaskStatus(task.Status);
            existingProject.Tasks.Add(task);
            _repo.UpdateProject(existingProject);
            _repo.SaveChanges();
        }

        public void DeleteProject(int projectId)
        {
            var project = _repo.GetProjectById(projectId);

            if (project == null)
            {
                throw new Exception("Project not found.");
            }

            _repo.DeleteProject(project);
            _repo.SaveChanges();
        }

        public void DeleteTask(int projectId, int taskId)
        {
            var existingProject = _repo.GetProjectById(projectId);
            if (existingProject == null)
            {
                throw new Exception("Project not found.");
            }

            var existingTask = existingProject.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (existingTask == null)
            {
                throw new Exception("Task not found.");
            }

            existingProject.Tasks.Remove(existingTask);
            _repo.UpdateProject(existingProject);
            _repo.SaveChanges();
        }

        public Project GetProjectById(int projectId)
        {
            var existingProject = _repo.GetProjectById(projectId);
            if (existingProject == null)
            {
                throw new Exception("Project not found.");
            }

            return existingProject;
        }

        public IEnumerable<Project> GetProjects()
        {
            return _repo.GetProjects();
        }

        public ProjectTask GetTaskById(int projectId, int taskId)
        {
            var existingProject = _repo.GetProjectById(projectId);
            if (existingProject == null)
            {
                throw new Exception("Project not found.");
            }

            var existingTask = existingProject.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (existingTask == null)
            {
                throw new Exception("Task not found.");
            }

            return existingTask;
        }

        public IEnumerable<ProjectTask> GetTasks(int projectId)
        {
            var existingProject = _repo.GetProjectById(projectId);
            if (existingProject == null)
            {
                throw new Exception("Project not found.");
            }

            return existingProject.Tasks;
        }

        public void UpdateProject(Project project)
        {
            _validation.ValidateProjectStatus(project.Status);
            _repo.UpdateProject(project);
            _repo.SaveChanges();
        }

        public void UpdateTask(int projectId, List<TaskUpdateOperation> taskUpdateOps)
        {
            var existingProject = _repo.GetProjectById(projectId);
            if (existingProject == null)
            {
                throw new Exception("Project not found.");
            }

            foreach(var op in taskUpdateOps)
            {
                var taskToUpdate = existingProject.Tasks.FirstOrDefault(t => t.Id == op.TaskId);
                if (taskToUpdate == null)
                {
                    throw new Exception("Task not found.");
                }

                switch (op.Property)
                {
                    case "Name":
                        taskToUpdate.Name = op.Value;
                        break;
                    case "Status":
                        _validation.ValidateTaskStatus(op.Value);
                        taskToUpdate.Status = op.Value;
                        break;
                    case "Description":
                        taskToUpdate.Description = op.Value;
                        break;
                    case "Priority":
                        taskToUpdate.Priority = Convert.ToInt32(op.Value);
                        break;
                    default:
                        throw new Exception($"Invalid Property name: {op.Property}.");
                }
                _repo.UpdateProject(existingProject);
            }
            _repo.SaveChanges();
        }
    }
}
