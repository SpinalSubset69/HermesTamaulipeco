namespace Core.Specifications.AuthorsSpecifications
{
    public class AuthorsSpecificationParams : PaginationParams
    {
        public string Sort {get; set;}
        public string Name {get; set;}
    }
}