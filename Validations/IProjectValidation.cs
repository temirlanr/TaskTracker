using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Entities;

namespace TaskTracker.Validations
{
    public interface IProjectValidation
    {
        void ValidateProjectStatus(string projectStatus);
        void ValidateTaskStatus(string taskStatus);
        void ValidateTaskId(List<ProjectTask> tasks);
    }
}
