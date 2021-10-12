using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly HermesContext _context;

        public GenericRepository(HermesContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }       
        public async Task<IReadOnlyList<T>> GetOnlyReadListAsync()
        {
            //_context.Authors.Include(x => x.Articles).ThenInclude(x => x.Author);
            return await _context.Set<T>().ToListAsync();
        }

        //Two methods to work
         public async Task<T> GetOneAsync(ISpecification<T> spec)
        {
          return await ApplySpecification(spec).FirstAsync<T>();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync<T>();
        }

        public async Task<int> Countasync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec){
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }
        
    }
}