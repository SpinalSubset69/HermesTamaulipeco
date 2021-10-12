using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Core.Specifications.AuthorsSpecifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/{controller}")]
    public class AuthorController : ControllerBase
    {
        private readonly IGenericRepository<Author> _authorsRepo;
        private readonly IMapper _mapper;
        public AuthorController(IGenericRepository<Author> authorsRepo,        
                                IMapper mapper)
        {
            _mapper = mapper;
            _authorsRepo = authorsRepo;

        }

    [HttpGet("{id}")]
    public async Task<ActionResult<IReadOnlyList<Author>>> GetAuthor(int id)
    {
        var spec = new AuthorsWithArticlesSpecification(id);
        var author = await _authorsRepo.GetOneAsync(spec);

        return Ok(_mapper.Map<Author, AuthorsToReturnDTO>(author));
    }

     [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Author>>> GetAuthors(
            [FromQuery]AuthorsSpecificationParams authorParams)
        {
            var spec = new AuthorsWithArticlesSpecification(authorParams);
            var specCount = new AuthorsWithFiltersForCountSpecification(authorParams);
            var totalItem = await _authorsRepo.Countasync(specCount);
            var authors = await _authorsRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Author>, IReadOnlyList<AuthorsToReturnDTO>>(authors);
            return Ok(new Pagination<AuthorsToReturnDTO>(authorParams.PageSize, authorParams.PageSize, totalItem, data));
        }
}
}