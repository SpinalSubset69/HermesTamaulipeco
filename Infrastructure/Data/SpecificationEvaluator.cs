using System.Linq;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Specifications
{
    public class SpecificationEvaluator<T> where T : BaseEntity 
    {
        //Este método evalua la specificacion y aplica las correspondientes a la collecion
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec ){
            var query = inputQuery;
            
            if(spec.Criteria != null){
                //Filtramos la colección con alguna condicion
                //Ejemplo: _context.Products.where(x => x.Id == id)
                query = query.Where(spec.Criteria);
            }            

            if(spec.OrderBy != null){
                query = query.OrderBy(spec.OrderBy);
            }

            if(spec.OrderByDesc != null){
                query = query.OrderByDescending(spec.OrderByDesc);
            }
            
            if(spec.IsPagingEnabled){
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));                 
            
            return query;
        }
    }
}