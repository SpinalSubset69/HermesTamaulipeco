using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetOnlyReadListAsync();
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);   

        Task<T> GetOneAsync(ISpecification<T> spec);

        Task<int> Countasync(ISpecification<T> spec);
    }
}