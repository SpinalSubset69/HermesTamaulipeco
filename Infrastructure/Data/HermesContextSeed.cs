using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Core.Entities;
using System.Collections.Generic;


namespace Infrastructure
{
    public class HermesContextSeed
    {
        public static async Task SeedAsync(HermesContext _context, ILoggerFactory loggerFactory){
            try{
                if(!_context.Categories.Any()){
                    var categoriesData = File.ReadAllText("../Infrastructure/Data/SeedData/Categories.json");
                    var categories = JsonSerializer.Deserialize<List<Category>>(categoriesData);

                    foreach(var category in categories){
                        _context.Categories.Add(category);
                    }
                    await _context.SaveChangesAsync();
                }
                
                if(!_context.Authors.Any()){
                    var authorsData = File.ReadAllText("../Infrastructure/Data/SeedData/Authors.json");
                    var authors = JsonSerializer.Deserialize<List<Author>>(authorsData);

                    foreach(var author in authors){
                        _context.Authors.Add(author);
                    }
                    await _context.SaveChangesAsync();
                }

                if(!_context.Articles.Any()){
                    var articlesData = File.ReadAllText("../Infrastructure/Data/SeedData/Articles.json");
                    var articles = JsonSerializer.Deserialize<List<Article>>(articlesData);

                    foreach(var article in articles){
                        _context.Articles.Add(article);
                    }
                    await _context.SaveChangesAsync();
                }

                /* if(!_context.Notes.Any()){
                    var notesData = File.ReadAllText("../Infrastructure/Data/SeedData/Notes.json");
                    var notes = JsonSerializer.Deserialize<List<Note>>(notesData);

                    foreach(var note in notes){
                        _context.Notes.Add(note);
                    }
                    await _context.SaveChangesAsync();
                } */                
            }catch(Exception ex){
                var logger = loggerFactory.CreateLogger<HermesContext>();
                logger.LogError(ex, "Error Seeding DataBase");
            }
        }
    }
}