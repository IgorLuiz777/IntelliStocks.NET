using INTELLISTOCKS.MODELS.db;
using INTELLISTOCKS.MODELS.task;
using Microsoft.EntityFrameworkCore;

namespace INTELLISTOCKS.REPOSITORY.repository
{
    public class TaskRepository : IRepository<Tasks>
    {
        private readonly FIAPDbContext _context;

        public TaskRepository(FIAPDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tasks>> GetAll()
        {
            return await _context.Tasks.Include(t => t.ResponsiblesUser).ToListAsync();
        }

        public async Task<Tasks?> GetById(int id)
        {
            return await _context.Tasks.Include(t => t.ResponsiblesUser).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tasks> Create(Tasks task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<Tasks> Update(Tasks task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task Delete(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}