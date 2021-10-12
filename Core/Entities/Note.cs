namespace Core.Entities
{
    public class Note : BaseEntity
    {
        public Article Article {get; set;}
        public int IdArticle {get; set;}
        public Author Author {get; set;}
        public int IdAuthor {get; set;}
    }
}