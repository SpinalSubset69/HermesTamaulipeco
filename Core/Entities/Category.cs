using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Category : BaseEntity
    {
        public string Name {get; set;}                        
    }
}