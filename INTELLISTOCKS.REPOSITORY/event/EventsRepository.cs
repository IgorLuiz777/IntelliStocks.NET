using INTELLISTOCKS.MODELS.db;
using INTELLISTOCKS.MODELS.events;
using Microsoft.EntityFrameworkCore;

namespace INTELLISTOCKS.REPOSITORY.events;

public class EventsRepository : IEventRepository
{
    private readonly FIAPDbContext _context;

    public EventsRepository(FIAPDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Events>> GetAllEvents()
    {
        return await _context.Events.ToListAsync();
    }

    public async Task<Events> GetEventById(int id)
    {
        return await _context.Events.FindAsync(id);
    }

    public async Task<Events> CreateEvent(Events events)
    {
        _context.Events.Add(events);
        await _context.SaveChangesAsync();
        return events;
    }

    public async Task<Events> UpdateEvent(Events events)
    {
        _context.Events.Update(events);
        await _context.SaveChangesAsync();
        return events;
    }

    public async Task DeleteEvent(int id)
    {
        var events = _context.Events.Find(id);
        _context.Events.Remove(events);
        await _context.SaveChangesAsync();
    }
}