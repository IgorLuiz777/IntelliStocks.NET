using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using INTELLISTOCKS.MODELS.task;
using INTELLISTOCKS.REPOSITORY.repository;
using INTELLISTOCKS.REPOSITORY.user;
using INTELLISTOCKS.SERVICES;

namespace INTELLISTOCKS.API.controller
{
    [Route("task")]
    [ApiController]
    [Tags("Task")]
    public class TasksController : ControllerBase
    {
        private readonly TaskRepository _taskRepository;
        private readonly UserRepository _userRepository;
        private readonly EmailService _emailService;

        public TasksController(TaskRepository taskRepository, UserRepository userRepository, EmailService emailService)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
            _emailService = emailService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostTask([FromBody] Tasks task)
        {
            try
            {
                var user = await _userRepository.GetById(task.ResponsiblesUserId);
                if (user == null)
                {
                    return BadRequest("User not found.");
                }

                task.ResponsiblesUser = user;
                var createdTask = await _taskRepository.Create(task);

                await _emailService.SendEmailAsync(user.Email, "Uma nova tarefa foi atribuida a você!",
                    $"Você recebeu uma nova tarefa: {task.Title}");

                var uri = Url.Action("GetTaskById", new { id = createdTask.Id });
                return Created(uri, createdTask);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal error: {error.Message}");
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Tasks>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                var tasks = await _taskRepository.GetAll();
                return Ok(tasks);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal error: {error.Message}");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Tasks), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTaskById(int id)
        {
            try
            {
                var task = await _taskRepository.GetById(id);
                if (task == null)
                {
                    return NotFound($"Task with ID {id} not found.");
                }

                return Ok(task);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal error: {error.Message}");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] Tasks task)
        {
            try
            {
                var existingTask = await _taskRepository.GetById(id);
                if (existingTask == null)
                {
                    return NotFound($"Task with ID {id} not found.");
                }

                var user = await _userRepository.GetById(task.ResponsiblesUserId);
                if (user == null)
                {
                    return BadRequest("User not found.");
                }

                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.DueTo = task.DueTo;
                existingTask.Priority = task.Priority;
                existingTask.Status = task.Status;
                existingTask.ResponsiblesUser = user;

                await _emailService.SendEmailAsync(user.Email, "Você tem uma tarefa nova ou uma tarefa foi " +
                                                               "modificada", "Tarefa: " + task.Title);

                var updatedTask = await _taskRepository.Update(existingTask);
                return Ok(updatedTask);
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal error: {error.Message}");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                var task = await _taskRepository.GetById(id);
                if (task == null)
                {
                    return NotFound($"Task with ID {id} not found.");
                }

                await _taskRepository.Delete(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal error: {error.Message}");
            }
        }
    }
}
