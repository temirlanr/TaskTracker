using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Dtos;
using TaskTracker.Entities;
using TaskTracker.Exceptions;
using TaskTracker.Extensions;
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
        /// <summary>
        /// Returns information about all Projects
        /// </summary>
        /// <returns>A list of Projects</returns>
        /// <response code="200">Request processed</response>
        /// <response code="400">Error occured while processing, check the Exception info please</response> 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ProjectReadDto>> GetProjects()
        {
            try
            {
                var projects = _service.GetProjects();
                return Ok(_mapper.Map<IEnumerable<ProjectReadDto>>(projects));
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET: api/projects/{projectId}
        /// <summary>
        /// Returns information about Project given its ID
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>Project info</returns>
        /// <response code="200">Request processed</response>
        /// <response code="400">Error occured while processing, check the Exception info please</response>
        [HttpGet("{projectId}", Name = "GetProject")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProjectReadDto> GetProject(int projectId)
        {
            try
            {
                var project = _service.GetProjectById(projectId);
                return Ok(_mapper.Map<ProjectReadDto>(project));
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST: api/projects
        /// <summary>
        /// Creates a Project
        /// </summary>
        /// <remarks>
        /// Project status fields accepts only: "NotStarted", "Active", "Completed". 
        /// Task status field accepts only: "ToDo", "InProgress", "Done".
        /// </remarks>
        /// <param name="projectCreateDto"></param>
        /// <returns>A newly created Project</returns>
        /// <response code="201">Returns the newly created Project</response>
        /// <response code="400">Error occured while processing, check the Exception info please</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProjectCreateDto> CreateProject(ProjectCreateDto projectCreateDto)
        {
            try
            {
                var project = _mapper.Map<Project>(projectCreateDto);
                _service.CreateProject(project);
                var projectReadDto = _mapper.Map<ProjectReadDto>(project);
                return CreatedAtAction(nameof(GetProject), new { projectId = projectReadDto.Id }, projectReadDto);
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT: api/projects/{projectId}
        /// <summary>
        /// Updates Project info
        /// </summary>
        /// <remarks>
        /// Project status fields accepts only: "NotStarted", "Active", "Completed".
        /// </remarks>
        /// <param name="projectId"></param>
        /// <param name="projectUpdateDto"></param>
        /// <returns>No content</returns>
        /// <response code="204">Request successfully processed</response>
        /// <response code="400">Error occured while processing, check the Exception info please</response>
        [HttpPut("{projectId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
                return BadRequest(e);
            }
        }

        // DELETE: api/projects/{projectId}
        /// <summary>
        /// Deletes an instance of Project
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>No content</returns>
        /// <response code="204">Request successfully processed</response>
        /// <response code="400">Error occured while processing, check the Exception info please</response>
        [HttpDelete("{projectId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteProject(int projectId)
        {
            try
            {
                _service.DeleteProject(projectId);
                return NoContent();
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        // PATCH: api/projects/{projectId}
        /// <summary>
        /// Updates Project info 
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///     
        ///     PATCH api/projects/{projectId}
        ///     [
        ///         {
        ///             "op": "replace",
        ///             "path": "name",
        ///             "value": "SomeName"
        ///         }
        ///     ]
        ///     
        /// There can be made several operations (body is a list of operations). 
        /// Project status fields accepts only: "NotStarted", "Active", "Completed".
        /// More info here: https://docs.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-6.0
        /// </remarks>
        /// <param name="projectId"></param>
        /// <param name="patchDoc"></param>
        /// <returns>No content</returns>
        /// <response code="204">Request successfully processed</response>
        /// <response code="400">Error occured while processing, check the Exception info please</response>
        [HttpPatch("{projectId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
                return BadRequest(e);
            }
        }

        // GET: api/projects/{projectId}/tasks/{taskId}
        /// <summary>
        /// Returns Task info given Project and Task IDs
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="taskId"></param>
        /// <returns>Task object</returns>
        /// <response code="200">Request processed</response>
        /// <response code="400">Error occured while processing, check the Exception info please</response>
        [HttpGet]
        [Route("{projectId}/tasks/{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TaskReadDto> GetTask(int projectId, int taskId)
        {
            try
            {
                var task = _service.GetTaskById(projectId, taskId);
                return Ok(_mapper.Map<TaskReadDto>(task));
            }
            catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        // GET: api/projects/{projectId}/tasks
        /// <summary>
        /// Returns the list of all Tasks given a Project ID
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns>List of Tasks</returns>
        /// <response code="200">Request processed</response>
        /// <response code="400">Error occured while processing, check the Exception info please</response>
        [HttpGet]
        [Route("{projectId}/tasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<TaskReadDto>> GetTasks(int projectId)
        {
            try
            {
                var tasks = _service.GetTasks(projectId);
                return Ok(_mapper.Map<IEnumerable<TaskReadDto>>(tasks));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // POST: api/projects/{projectId}/tasks
        /// <summary>
        /// Adds a Task to the Project
        /// </summary>
        /// <remarks>
        /// Task status field accepts only: "ToDo", "InProgress", "Done".
        /// </remarks>
        /// <param name="projectId"></param>
        /// <param name="taskCreateDto"></param>
        /// <returns>Created Task</returns>
        /// <response code="201">Returns the newly created Task</response>
        /// <response code="400">Error occured while processing, check the Exception info please</response> 
        [HttpPost]
        [Route("{projectId}/tasks")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<TaskCreateDto> CreateTask(int projectId, TaskCreateDto taskCreateDto)
        {
            try
            {
                var task = _mapper.Map<ProjectTask>(taskCreateDto);
                _service.CreateTask(projectId, task);
                var taskReadDto = _mapper.Map<TaskReadDto>(task);
                return CreatedAtAction(nameof(GetTask), new { projectId, taskId = taskReadDto.Id }, taskReadDto);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // DELETE: api/projects/{projectId}/tasks/{taskId}
        /// <summary>
        /// Deletes a Task given Project and Task IDs
        /// </summary>
        /// <param name="projectId"></param>
        /// <param name="taskId"></param>
        /// <returns>No content</returns>
        /// <response code="204">Request successfully processed</response>
        /// <response code="400">Error occured while processing, check the Exception info please</response>
        [HttpDelete]
        [Route("{projectId}/tasks/{taskId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteTask(int projectId, int taskId)
        {
            try
            {
                _service.DeleteTask(projectId, taskId);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // PUT: api/projects/{projectId}/tasks
        /// <summary>
        /// Updates Task info
        /// </summary>
        /// <remarks>
        /// In a similar way as in Patch Project method, there can be made several operations (body is a list of operations).
        /// There are 4 properties that can be changed: "Name", "Description", "Status", "Priority". 
        /// Task status field accepts only: "ToDo", "InProgress", "Done".
        /// </remarks>
        /// <param name="projectId"></param>
        /// <param name="taskUpdateOps"></param>
        /// <returns>No content</returns>
        /// <response code="204">Request successfully processed</response>
        /// <response code="400">Error occured while processing, check the Exception info please</response>
        [HttpPatch("{projectId}/tasks")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateTask(int projectId, List<TaskUpdateOperation> taskUpdateOps)
        {
            try
            {
                _service.UpdateTask(projectId, taskUpdateOps);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
