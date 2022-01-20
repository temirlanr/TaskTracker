using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Dtos;
using TaskTracker.Entities;

namespace TaskTracker.Profiles
{
    public class TaskProfiles : Profile
    {
        public TaskProfiles()
        {
            CreateMap<TaskUpdateDto, ProjectTask>();
            CreateMap<ProjectTask, TaskUpdateDto>();
            CreateMap<TaskCreateDto, ProjectTask>();
            CreateMap<ProjectTask, TaskReadDto>();
        }
    }
}
