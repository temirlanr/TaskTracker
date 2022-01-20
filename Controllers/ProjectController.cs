using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET: api/projects/{id}
        [HttpGet("{id}")]
        public ActionResult<Project> GetProject(int id)
        {
            try
            {
                var project = _service.GetProjectById(id);
                return Ok(project);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
