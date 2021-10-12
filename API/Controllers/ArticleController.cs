using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class ArticleController : ControllerBase
    {
        private readonly IGenericRepository<Article> _articlesRepo;        
        private readonly IMapper _mapper;

        public ArticleController(IGenericRepository<Article> articlesRepo,
                                IMapper mapper)
        {
            _mapper = mapper;
            _articlesRepo = articlesRepo;            
        }           

        [HttpGet]
        public async Task<ActionResult<List<Article>>> GetArticles(
            [FromQuery]ArticlesSpecificationParams articleParams)
        {
            var spec = new ArticlesWithAuthorsSpecification(articleParams);
            var countSpec = new ArticlesWithFiltersForCountSpecification(articleParams);
            int totalItems = await _articlesRepo.Countasync(countSpec);
            var articles = await _articlesRepo.ListAsync(spec);  
            var data = _mapper.Map<IReadOnlyList<Article>, IReadOnlyList<ArticlesToReturnDTO>>(articles);
            return Ok(new Pagination<ArticlesToReturnDTO>(articleParams.PageSize, articleParams.PageIndex, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id){
            var spec = new ArticlesWithAuthorsSpecification(id);
            var article = await _articlesRepo.GetOneAsync(spec);
            return Ok(_mapper.Map<Article, ArticlesToReturnDTO>(article));
        }

    }
}