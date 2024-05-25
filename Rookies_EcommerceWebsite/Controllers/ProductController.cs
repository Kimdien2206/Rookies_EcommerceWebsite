using AutoMapper;
using Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService<Product> _service;
        private readonly IMapper _mapper;

        public ProductController(IService<Product> service, IMapper mapper)
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
        [Route("{slug}")]
        public async Task<IResult> GetBySlug(string slug)
        {
            return await _service.GetById(slug);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IResult> Create([FromBody] CreateProductRequestDto productDto)
        {
            Product createProduct = _mapper.Map<Product>(productDto);
            return await _service.Create(createProduct);
        }

        [HttpPatch]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<IResult> Update(string id, [FromBody] UpdateProductRequestDto updateProductRequestDto)
        {
            Product updateProduct = _mapper.Map<Product>(updateProductRequestDto);
            return await _service.Update(id, updateProduct);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("{id}")]
        public async Task<IResult> Delete(string id)
        {
            return await _service.Delete(id);
        }
    }
}
