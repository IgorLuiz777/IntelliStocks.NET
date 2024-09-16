using System.Net;
using INTELLISTOCKS.MODELS.events;
using INTELLISTOCKS.REPOSITORY.events;
using Microsoft.AspNetCore.Mvc;

namespace INTELLISTOCKS.API.controller;

[Route("event")]
[ApiController]
[Tags("Event")]
public class EventsController : ControllerBase
{
    private readonly IEventRepository _eventRepository;

    public EventsController(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    
    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Events>> CreateEvent(Events events)
    {
        try
        {
            var createdEvent = await _eventRepository.CreateEvent(events);
            var uri = Url.Action("GetEventById", new { id = createdEvent.Id });
            return Created(uri, createdEvent);
        }
        catch (Exception error)
        {
            return StatusCode(500, "Internal server error: " + error.Message);
        }
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<Events>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllEvents()
    {
        try
        {
            var events = await _eventRepository.GetAllEvents();
            return Ok(events);
        }
        catch (Exception error)
        {
            return StatusCode(500, "Internal server error: " + error.Message);
        }
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Events), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEventById(int id)
    {
        try
        {
            var events = await _eventRepository.GetEventById(id);
            if (events == null) return NotFound("Event not found with id: " + id);
            return Ok(events);
        }
        catch (Exception error)
        {
            return StatusCode(500, "Internal server error: " + error.Message);
        }
    }
    
    [HttpPut("{id}")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateEvent(int id, Events events)
    {
        try
        {
            var foundEvent = await _eventRepository.GetEventById(id);
            if (foundEvent == null) return NotFound("Event not found with id: " + id);
            foundEvent.Title = events.Title;
            foundEvent.Description = events.Description;
            foundEvent.Location = events.Location;
            foundEvent.StartDate = events.StartDate;
            foundEvent.EndDate = events.EndDate;
            
            var updatedEvent = await _eventRepository.UpdateEvent(foundEvent);
            return Ok(updatedEvent);
        }
        catch (Exception error)
        {
            return StatusCode(500, "Internal server error: " + error.Message);
        }
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteEvent(int id)
    {
        try
        {
            var events = await _eventRepository.GetEventById(id);
            if (events == null) return NotFound("Event not found with id: " + id);
            await _eventRepository.DeleteEvent(id);
            return NoContent();
        }
        catch (Exception error)
        {
            return StatusCode(500, "Internal server error: " + error.Message);
        }
    }
}