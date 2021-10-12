using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;            
        }

        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get ; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderBy { get; set; }
        public Expression<Func<T, object>> OrderByDesc { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPagingEnabled { get; set; }

        protected void ApplyPaging(int skip, int take){
            Skip = skip;
            Take = take;            
            IsPagingEnabled = true;
        }

        //MEthod that allow us to add include stattements in our Includes List
        protected void AddInclude(Expression<Func<T, Object>> includeExpression){
            //Incluimos las relaciones que tiene nuestrea tabla con otra
            //Ex. _context.Articles.includes(x => x.Author);
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, Object>> orderByExpression){
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDesc(Expression<Func<T, Object>> orderByDescExpression){
            OrderByDesc = orderByDescExpression;
        }
    }
}