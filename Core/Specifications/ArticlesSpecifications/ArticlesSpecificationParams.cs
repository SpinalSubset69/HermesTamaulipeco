namespace Core.Specifications
{
    public class ArticlesSpecificationParams : PaginationParams
    {
        public string Sort { get; set; }

        public int? AuthorId { get; set; }

        public string Category { get; set; }
        public string Name { get; set; }

        public string date {get; set;}

    }
}