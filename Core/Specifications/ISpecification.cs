using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public interface ISpecification <T> 
    {
         Expression<Func<T, bool>> Criteria {get; set;}
         List<Expression<Func<T, Object>>> Includes {get; set;}

         Expression<Func<T, Object>> OrderBy {get; set;}

         Expression<Func<T, Object>> OrderByDesc {get; set;}

         int Take {get; set;}
         int Skip {get; set;}

         bool IsPagingEnabled {get; set;}
         
    }
}