using INTELLISTOCKS.MODELS.events;

namespace INTELLISTOCKS.REPOSITORY.events;

public interface IEventRepository
{
    Task<List<Events>> GetAllEvents();
    Task<Events> GetEventById(int id);
    Task<Events> CreateEvent(Events events);
    Task<Events> UpdateEvent(Events events);
    Task DeleteEvent(int id);
}