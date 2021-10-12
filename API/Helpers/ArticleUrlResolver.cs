using API.Dtos;
using AutoMapper;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ArticleUrlResolver : IValueResolver<Article, ArticlesToReturnDTO, string>
    {
        private readonly IConfiguration _config;
        public ArticleUrlResolver(IConfiguration config)
        {
            _config = config;

        }
        public string Resolve(Article source, ArticlesToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Image))
            {
                return _config["ApiUrl"] + source.Image;
            }

            return null;
        }
    }
}