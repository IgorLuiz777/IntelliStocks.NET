using System.Collections.Generic;
using System.Threading.Tasks;
using INTELLISTOCKS.MODELS.task;

namespace INTELLISTOCKS.REPOSITORY.repository
{
    public interface ITaskRepository
    {
        Task<List<Tasks>> GetAllTasksAsync();
        Task<Tasks?> GetTaskByIdAsync(int id);
        Task<Tasks> AddTaskAsync(Tasks task);
        Task<Tasks> UpdateTaskAsync(Tasks task);
        Task DeleteTaskAsync(int id);
    }
}