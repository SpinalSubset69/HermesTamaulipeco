using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class HermesContext : DbContext
    {
        public HermesContext(DbContextOptions options)
        : base(options)
        {
            
        }

        public DbSet<Article> Articles {get; set;}
        public DbSet<Author> Authors {get; set;}
        public DbSet<Category> Categories {get; set;}
        //public DbSet<Note> Notes {get; set;}        
    }
}