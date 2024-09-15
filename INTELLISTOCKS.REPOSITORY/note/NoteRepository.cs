using INTELLISTOCKS.MODELS.db;
using INTELLISTOCKS.MODELS.note;
using Microsoft.EntityFrameworkCore;

namespace INTELLISTOCKS.REPOSITORY;

public class NoteRepository : INoteRepository
{
    private readonly FIAPDbContext _context;

    public NoteRepository(FIAPDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Note>> GetAllNotes()
    {
        return await _context.Note.ToListAsync();
    }

    public async Task<Note?> GetNoteById(int id)
    {
        return await _context.Note.FindAsync(id);
    }

    public async Task<Note> CreateNote(Note note)
    {
        _context.Note.Add(note);
        await _context.SaveChangesAsync();
        return note;
    }

    public async Task<Note> UpdateNote(Note note)
    {
        _context.Note.Update(note);
        await _context.SaveChangesAsync();
        return note;
    }

    public async Task DeleteNote(int id)
    {
        var note = _context.Note.Find(id);
        _context.Note.Remove(note);
        await _context.SaveChangesAsync();
    }
}