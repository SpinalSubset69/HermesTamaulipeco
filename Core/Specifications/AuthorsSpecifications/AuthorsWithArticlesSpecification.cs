using System.Linq;
using Core.Entities;
using Core.Specifications.AuthorsSpecifications;

namespace Core.Specifications
{
    public class AuthorsWithArticlesSpecification : BaseSpecification<Author>
    {
        public AuthorsWithArticlesSpecification(AuthorsSpecificationParams authorParams)  
        :base( x=> 
            (string.IsNullOrEmpty(authorParams.Name) || x.Name.ToLower().Contains(authorParams.Name.ToLower()))
        )     
        {             
             AddOrderBy(x => x.Name);     
             ApplyPaging(authorParams.PageSize * (authorParams.PageIndex - 1), authorParams.PageSize);

             if(!string.IsNullOrEmpty(authorParams.Sort)){
                 switch(authorParams.Sort){
                     case "orderAsc":
                     AddOrderBy(x => x.Name);
                     break;
                     case "orderDesc":
                     AddOrderByDesc(x => x.Name);
                     break;
                     default:
                     AddOrderBy(x => x.Name);
                     break;
                 }
             }
        }
        public AuthorsWithArticlesSpecification(int id)
        :base(x => x.Id == id)
        {
             
        }
        public AuthorsWithArticlesSpecification()
        {
                   
        }
    }
}