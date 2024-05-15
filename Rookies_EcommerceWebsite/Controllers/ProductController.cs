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
        [Route("{id}")]
        public async Task<IResult> GetById(string id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task<IResult> Create([FromBody] CreateProductRequestDto productDto)
        {
            Product createProduct = _mapper.Map<Product>(productDto);
            return await _service.Create(createProduct);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IResult> Update(string id, [FromBody] UpdateProductRequestDto updateProductRequestDto)
        {
            Product updateProduct = _mapper.Map<Product>(updateProductRequestDto);
            return await _service.Update(id, updateProduct);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IResult> Delete(string id)
        {
            return await _service.Delete(id);
        }
    }
}
