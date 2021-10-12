using Core.Entities;

namespace Core.Specifications
{
    public class CategoriesSpecifications : BaseSpecification<Category>
    {        
        public CategoriesSpecifications(int id)
        : base(x => x.Id == id)
        {

        }
        public CategoriesSpecifications(){

        }
    }
}