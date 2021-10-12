using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Article : BaseEntity
    {
        public string Header{get; set;}
        public string Summary {get; set;}
        public string Content {get; set;}
        public string Image  {get; set;}
        public string Date {get; set;}    
        public int AuthorId {get; set;}   
        public int CategoryId {get; set;}     

        [ForeignKey("AuthorId")]   
        public virtual Author Author {get; set;}        

        [ForeignKey("CategoryId")]
        public virtual Category Category {get; set;}
    }
}