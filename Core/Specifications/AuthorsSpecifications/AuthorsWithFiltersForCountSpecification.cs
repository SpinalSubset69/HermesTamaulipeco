using Core.Entities;
using Core.Specifications.AuthorsSpecifications;

namespace Core.Specifications
{
    public class AuthorsWithFiltersForCountSpecification : BaseSpecification<Author>
    {
        public AuthorsWithFiltersForCountSpecification(AuthorsSpecificationParams authorParams)
        :base( x=> 
            (string.IsNullOrEmpty(authorParams.Name) || x.Name.ToLower().Contains(authorParams.Name.ToLower()))
        ) 
        {
            
        }
    }
}