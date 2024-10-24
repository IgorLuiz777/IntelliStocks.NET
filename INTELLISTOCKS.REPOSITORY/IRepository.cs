using INTELLISTOCKS.MODELS.note;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTELLISTOCKS.REPOSITORY
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
    }
}
