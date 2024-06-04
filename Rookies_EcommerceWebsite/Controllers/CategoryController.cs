using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;
using Rookies_EcommerceWebsite.Services;

namespace Rookies_EcommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _service;
        private readonly IMapper _mapper;
        public CategoryController(CategoryService service, IMapper mapper) 
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            return await _service.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> GetById(string id)
        {
            return await _service.GetById(id); 
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IResult> Create([FromBody] CreateCategoryRequestDto createCategoryRequestDto)
        {
            Category newCategory = _mapper.Map<Category>(createCategoryRequestDto);
            if (newCategory == null)
            {
                return Results.BadRequest();
            }
            return await _service.Create(newCategory);
        }

        [Authorize(Roles = "Admin")]
        [HttpPatch]
        [Route("{id}")]
        public async Task<IResult> Update(string id, [FromBody] UpdateCategoryRequestDto updateCategoryRequestDto)
        {
            Category updateCategory = _mapper.Map<Category>(updateCategoryRequestDto);
            if(updateCategory == null)
            {
                return Results.BadRequest();
            }
            return await _service.Update(id, updateCategory);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IResult> Delete(string id)
        {
            return await _service.Delete(id);
        }
    }
}