using Core.Entities;
using API.Dtos;

namespace API.Dtos
{
    public class ArticlesToReturnDTO
    {
        public int Id {get; set;}
        public string Header{get; set;}
        public string Summary {get; set;}
        public string Content {get; set;}
        public string Image  {get; set;}
        public string Date {get; set;}    
        public AuthorsToReturnWithoutCredentials Author {get; set;}
        public string Category {get; set;}
    }
}