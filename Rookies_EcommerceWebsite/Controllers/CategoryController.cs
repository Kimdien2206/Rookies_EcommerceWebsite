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
        private readonly IService<Category> _service;
        private readonly IMapper _mapper;
        public CategoryController(IService<Category> service, IMapper mapper) 
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

        [HttpPost]
        public async Task<IResult> Create([FromBody] CreateCategoryRequestDto createCategoryRequestDto)
        {
            Category newCategory = _mapper.Map<Category>(createCategoryRequestDto);
            return await _service.Create(newCategory);
        }
        
        [HttpPut]
        [Route("{id}")]
        public async Task<IResult> Update(string id, [FromBody] UpdateCategoryRequestDto updateCategoryRequestDto)
        {
            Category updateCategory = _mapper.Map<Category>(updateCategoryRequestDto);
            return await _service.Update(id, updateCategory);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IResult> Delete(string id)
        {
            return await _service.Delete(id);
        }
    }
}
