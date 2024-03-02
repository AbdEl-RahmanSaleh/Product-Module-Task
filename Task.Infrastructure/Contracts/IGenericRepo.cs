using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.Entities;

namespace Task.Infrastructure.Contracts
{
    public interface IGenericRepo<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int? id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        void Delete(T entity);
    }
}
