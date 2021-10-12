using Core.Entities;

namespace Core.Specifications
{
    public class ArticlesWithFiltersForCountSpecification : BaseSpecification<Article>
    {
        //Class for only filter articles and get the total items
        public ArticlesWithFiltersForCountSpecification(
          ArticlesSpecificationParams articlesParams)
        : base(x => //Realizamos el query para sortear los articulos en base al id del autor, solo en caso de que se haya enviado
            (!articlesParams.AuthorId.HasValue || x.AuthorId == articlesParams.AuthorId) &&
            (string.IsNullOrEmpty(articlesParams.Name) || x.Header.ToLower().Contains(articlesParams.Name.ToLower())) &&
            (string.IsNullOrEmpty(articlesParams.Category) || x.Category.Name.ToLower().Contains(articlesParams.Category.ToLower()))
            )                  
        {              
        }
    }
}