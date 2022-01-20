using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Data;
using TaskTracker.Entities;

namespace TaskTracker.Repositories
{
    public class ProjectRepo : IProjectRepo
    {
        private readonly TaskTrackerContext _context;
        public ProjectRepo(TaskTrackerContext context)
        {
            _context = context;
        }

        public void CreateProject(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            _context.Projects.Add(project);
        }

        public void DeleteProject(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            _context.Projects.Remove(project);
        }

        public Project GetProjectById(int id)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Project> GetProjects()
        {
            return _context.Projects.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateProject(Project project)
        {
            if (project == null)
            {
                throw new ArgumentNullException(nameof(project));
            }

            _context.Projects.Update(project);
        }
    }
}
