using System.Collections.Generic;
using Core.Entities;

namespace API.Dtos
{
    public class AuthorsToReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string About { get; set; }        
    }
}