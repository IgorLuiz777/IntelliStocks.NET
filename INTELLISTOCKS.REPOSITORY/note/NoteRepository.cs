using INTELLISTOCKS.MODELS.db;
using INTELLISTOCKS.MODELS.note;
using Microsoft.EntityFrameworkCore;

namespace INTELLISTOCKS.REPOSITORY;

public class NoteRepository : IRepository<Note>
{
    private readonly FIAPDbContext _context;

    public NoteRepository(FIAPDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Note>> GetAll()
    {
        return await _context.Note.ToListAsync();
    }

    public async Task<Note?> GetById(int id)
    {
        return await _context.Note.FindAsync(id);
    }

    public async Task<Note> Create(Note note)
    {
        _context.Note.Add(note);
        await _context.SaveChangesAsync();
        return note;
    }

    public async Task<Note> Update(Note note)
    {
        _context.Note.Update(note);
        await _context.SaveChangesAsync();
        return note;
    }

    public async Task Delete(int id)
    {
        var note = _context.Note.Find(id);
        _context.Note.Remove(note);
        await _context.SaveChangesAsync();
    }
}