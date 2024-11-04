using System.Net;
using INTELLISTOCKS.MODELS.note;
using INTELLISTOCKS.MODELS.task;
using INTELLISTOCKS.REPOSITORY;
using Microsoft.AspNetCore.Mvc;

namespace INTELLISTOCKS.API.controller;
[Route("note")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly NoteRepository _noteRepository;

    public NoteController(NoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    [HttpPost]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Note>> CreateNote(Note note)
    {
        try
        {
            var createdNote = await _noteRepository.Create(note);
            var uri = Url.Action("GetNoteById", new { id = createdNote.ID });
            return Created(uri, createdNote);
        }
        catch (Exception error)
        {
            return StatusCode(500, "Internal server error: " + error.Message);
        }
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(List<Tasks>), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllNotes()
    {
        try
        {
            var notes = await _noteRepository.GetAll();
            return Ok(notes);
        }
        catch (Exception error)
        {
            return StatusCode(500, "Internal server error: " + error.Message);
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Note), (int)HttpStatusCode.OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetNoteById(int id)
    {
        try
        {
            var note = await _noteRepository.GetById(id);
            if (note == null) return NotFound("Note not found with id: " + id);
            return Ok(note);
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
    public async Task<IActionResult> UpdateNote(int id, Note note)
    {
        try
        {
            var foundNote = await _noteRepository.GetById(id);
            if (foundNote == null) return NotFound("Note not found with id: " + id);
            foundNote.Title = note.Title;
            foundNote.Content = note.Content;
            
            var updatedNote = await _noteRepository.Update(foundNote);
            return Ok(updatedNote);
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
    public async Task<IActionResult> DeleteNote(int id)
    {
        try
        {
            var note = await _noteRepository.GetById(id);
            if (note == null) return NotFound("Note not found with id: " + id);
            await _noteRepository.Delete(id);
            return NoContent();
        }
        catch (Exception error)
        {
            return StatusCode(500, "Internal server error: " + error.Message);
        }
    }
}