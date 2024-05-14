using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;
        public CategoryController(IRepository<Category> repository, IMapper mapper) 
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            List<Category> categories = await _repository.GetAll();

            if(categories == null || categories.Count == 0) 
            {
                return Results.NoContent();
            }

            return Results.Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetById(string id)
        {
            Category category = await _repository.GetById(id);

            if(category == null)
            {
                return Results.NotFound();
            }

            return Results.Ok(category);    
        }

        [HttpPost]
        public async Task<IResult> Create([FromBody] CreateCategoryRequestDto createCategoryRequestDto)
        {
            Category newCategory = new Category() 
            {
                Name = createCategoryRequestDto.Name,
                Description = createCategoryRequestDto.Description,
            };
            await _repository.Create(newCategory);

            return Results.Ok(newCategory);
        }
        
        [HttpPut]
        [Route("{id}")]
        public async Task<IResult> Update(string id, [FromBody] UpdateCategoryRequestDto updateCategoryRequestDto)
        {
            Category updateCategory = _mapper.Map<Category>(updateCategoryRequestDto);
            Category updatedCategory = await _repository.Update(id, updateCategory);

            if (updatedCategory == null)
            {
                return Results.UnprocessableEntity(updateCategory);
            }

            return Results.Ok(updatedCategory);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IResult> Delete(string id)
        {
            try
            {
                await _repository.Delete(id);

                return Results.Ok();
            }
            catch (KeyNotFoundException ex) 
            {
                return Results.NotFound(ex.Message);
            }
        }
    }
}
