using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Entities;
using TaskTracker.Extensions;
using TaskTracker.Exceptions;

namespace TaskTracker.Services
{
    public interface IProjectService
    {
        /// <summary>
        /// Gets the List of <see cref="Project"/>s
        /// </summary>
        /// <returns><see cref="Project"/> List</returns>
        IEnumerable<Project> GetProjects();
        /// <summary>
        /// Returns <see cref="Project"/> data given it Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns><see cref="Project"/></returns>
        /// <exception cref="ProjectNotFoundException"></exception>
        Project GetProjectById(int projectId);
        /// <summary>
        /// Creates an instance of <see cref="Project"/> in database
        /// </summary>
        /// <param name="project"></param>
        /// <exception cref="InvalidStatusException"></exception>
        /// <exception cref="InvalidTaskIdException"></exception>
        void CreateProject(Project project);
        /// <summary>
        /// Updates <see cref="Project"/>
        /// </summary>
        /// <param name="project"></param>
        /// <exception cref="InvalidStatusException"></exception>
        void UpdateProject(Project project);
        /// <summary>
        /// Deletes <see cref="Project"/>
        /// </summary>
        /// <param name="projectId"></param>
        /// <exception cref="ProjectNotFoundException"></exception>
        void DeleteProject(int projectId);
        /// <summary>
        /// Returns the List of <see cref="ProjectTask"/>s given the Id of the <see cref="Project"/>
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>List of <see cref="ProjectTask"/>s</returns>
        /// <exception cref="ProjectNotFoundException"></exception>
        IEnumerable<ProjectTask> GetTasks(int projectId);
        /// <summary>
        /// Returns the <see cref="ProjectTask"/> given Id in <see cref="Project"/>
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="taskId"></param>
        /// <returns><see cref="ProjectTask"/></returns>
        /// <exception cref="ProjectNotFoundException"></exception>
        /// <exception cref="TaskNotFoundException"></exception>
        ProjectTask GetTaskById(int projectId, int taskId);
        /// <summary>
        /// Adds a <see cref="ProjectTask"/> to <see cref="Project"/>
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="task"></param>
        /// <exception cref="ProjectNotFoundException"></exception>
        /// <exception cref="InvalidStatusException"></exception>
        /// <exception cref="InvalidTaskIdException"></exception>
        void CreateTask(int projectId, ProjectTask task);
        /// <summary>
        /// Updates <see cref="ProjectTask"/>s given Id of the <see cref="Project"/>
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="taskUpdateOps"></param>
        /// <exception cref="ProjectNotFoundException"></exception>
        /// <exception cref="TaskNotFoundException"></exception>
        /// <exception cref="InvalidStatusException"></exception>
        void UpdateTask(int projectId, List<TaskUpdateOperation> taskUpdateOps);
        /// <summary>
        /// Deletes a <see cref="ProjectTask"/> from <see cref="Project"/>
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="taskId"></param>
        /// <exception cref="ProjectNotFoundException"></exception>
        /// <exception cref="TaskNotFoundException"></exception>
        void DeleteTask(int projectId, int taskId);

    }
}
