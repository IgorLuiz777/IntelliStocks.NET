using INTELLISTOCKS.MODELS.note;

namespace INTELLISTOCKS.REPOSITORY;

public interface INoteRepository
{
    Task<List<Note>> GetAllNotes();
    Task<Note?> GetNoteById(int id);
    Task<Note> CreateNote(Note note);
    Task<Note> UpdateNote(Note note);
    Task DeleteNote(int id);
}
