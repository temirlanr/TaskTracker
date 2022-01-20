using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Dtos;
using TaskTracker.Entities;

namespace TaskTracker.Profiles
{
    public class ProjectProfiles : Profile
    {
        public ProjectProfiles()
        {
            CreateMap<ProjectUpdateDto, Project>();
            CreateMap<Project, ProjectUpdateDto>();
            CreateMap<ProjectCreateDto, Project>();
            CreateMap<Project, ProjectReadDto>();
        }
    }
}
