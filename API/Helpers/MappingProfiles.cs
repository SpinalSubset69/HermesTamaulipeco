using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Article, ArticlesToReturnDTO>()            
            .ForMember(x => x.Author, o => o.MapFrom(s => s.Author))
            .ForMember(x => x.Category, o => o.MapFrom(s => s.Category.Name))          
            .ForMember(x => x.Image, o => o.MapFrom<ArticleUrlResolver>());
            
            //Author Without credentials
            CreateMap<Author, AuthorsToReturnWithoutCredentials>();            

            //Author Map Profile
            CreateMap<Author, AuthorsToReturnDTO>();      

            CreateMap<Category, CategoriesToReturnDTO>()
            .ForMember(x => x.Name, o => o.MapFrom(s => s.Name.ToString()));              
        }
    }
}