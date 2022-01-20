using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Dtos;
using TaskTracker.Entities;
using TaskTracker.Services;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;
        private readonly IMapper _mapper;
        public ProjectController(IProjectService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/projects
        [HttpGet]
        public ActionResult<IEnumerable<ProjectReadDto>> GetProjects()
        {
            try
            {
                var projects = _service.GetProjects();
                return Ok(_mapper.Map<IEnumerable<ProjectReadDto>>(projects));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/projects/{projectId}
        [HttpGet("{projectId}")]
        public ActionResult<ProjectReadDto> GetProject(int projectId)
        {
            try
            {
                var project = _service.GetProjectById(projectId);
                return Ok(_mapper.Map<ProjectReadDto>(project));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/projects
        [HttpPost]
        public ActionResult<ProjectCreateDto> CreateProject(ProjectCreateDto projectCreateDto)
        {
            try
            {
                var project = _mapper.Map<Project>(projectCreateDto);
                _service.CreateProject(project);
                var projectReadDto = _mapper.Map<ProjectReadDto>(project);
                return CreatedAtAction(nameof(GetProject), new { id = projectReadDto.Id }, projectReadDto);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/projects/{projectId}
        [HttpPut("{projectId}")]
        public ActionResult UpdateProject(int projectId, ProjectUpdateDto projectUpdateDto)
        {
            try
            {
                var existingProject = _service.GetProjectById(projectId);
                _mapper.Map(projectUpdateDto, existingProject);
                _service.UpdateProject(existingProject);
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/projects/{projectId}
        [HttpDelete("{projectId}")]
        public ActionResult DeleteProject(int projectId)
        {
            try
            {
                _service.DeleteProject(projectId);
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PATCH: api/projects/{projectId}
        [HttpPatch("{projectId}")]
        public ActionResult UpdateProjectPartial(int projectId, JsonPatchDocument<ProjectUpdateDto> patchDoc)
        {
            try
            {
                var existingProject = _service.GetProjectById(projectId);
                var projectToPatch = _mapper.Map<ProjectUpdateDto>(existingProject);

                patchDoc.ApplyTo(projectToPatch, ModelState);

                if (!TryValidateModel(projectToPatch))
                {
                    return BadRequest(ModelState);
                }

                _mapper.Map(projectToPatch, existingProject);
                _service.UpdateProject(existingProject);
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // 
    }
}
