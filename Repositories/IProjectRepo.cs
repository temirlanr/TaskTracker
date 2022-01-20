using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Entities;

namespace TaskTracker.Repositories
{
    public interface IProjectRepo
    {
        bool SaveChanges();
        IEnumerable<Project> GetProjects();
        Project GetProjectById(int id);
        void CreateProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(Project project);
    }
}
