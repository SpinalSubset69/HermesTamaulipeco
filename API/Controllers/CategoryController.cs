using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/{controller}")]
    public class CategoryController : ControllerBase
    {
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IMapper _mapper;
        public CategoryController(IGenericRepository<Category> categoryRepo,        
                                  IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;

        }
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Category>>> GetCategories()
    {
        var spec = new CategoriesSpecifications();
        var categories = await _categoryRepo.ListAsync(spec);
        return Ok(_mapper.Map<IReadOnlyList<Category>, IReadOnlyList<CategoriesToReturnDTO>>(categories));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        var spec = new CategoriesSpecifications(id);
        var category = await _categoryRepo.GetOneAsync(spec);        
        return Ok(_mapper.Map<Category, CategoriesToReturnDTO>(category));
    }
}
}