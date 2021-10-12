using Core.Entities;

namespace Core.Specifications
{
    public class ArticlesWithAuthorsSpecification : BaseSpecification<Article>
    {

        public ArticlesWithAuthorsSpecification(
           ArticlesSpecificationParams articlesParams)
        : base(x => //Realizamos el query para sortear los articulos en base al id del autor, solo en caso de que se haya enviado
            (!articlesParams.AuthorId.HasValue || x.AuthorId == articlesParams.AuthorId) &&
            (string.IsNullOrEmpty(articlesParams.Name) || x.Header.ToLower().Contains(articlesParams.Name.ToLower())) &&
            (string.IsNullOrEmpty(articlesParams.Category) || x.Category.Name.ToLower().Contains(articlesParams.Category.ToLower()))&&
            (string.IsNullOrEmpty(articlesParams.date) || x.Date.ToLower().Contains(articlesParams.date.ToLower()))              
        )
        {
            AddInclude(x => x.Author);
            AddInclude(x => x.Category);
            AddOrderBy(x => x.Date);
            //TAKE, SKIP
            ApplyPaging(articlesParams.PageSize * (articlesParams.PageIndex - 1), articlesParams.PageSize);
           
            if(!string.IsNullOrEmpty(articlesParams.Sort)){
                switch(articlesParams.Sort){
                    case "orderAsc":
                    AddOrderBy(x => x.Date);
                    break;
                    case "orderDesc":
                    AddOrderByDesc(x => x.Date);
                    break;
                    default:
                    AddOrderBy(x => x.Date);
                    break;
                }
            }
        }

        public ArticlesWithAuthorsSpecification(int id)
        :base(x => x.Id == id)
        {
            
            AddInclude(x => x.Author); 
            AddInclude(x => x.Category);
        }
        public ArticlesWithAuthorsSpecification()
        {
            AddInclude(x => x.Author);
            AddInclude(x => x.Category);
        }
    }
}