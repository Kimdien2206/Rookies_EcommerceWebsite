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
    public class CartController : ControllerBase
    {
        private readonly IService<Cart> _service;
        private readonly IMapper _mapper;

        public CartController(IService<Cart> service, IMapper mapper)
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
        public async Task<IResult> Create([FromBody] CreateCartRequestDto cartDto)
        {
            Cart createdCart = _mapper.Map<Cart>(cartDto);
            return await _service.Create(createdCart);
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<IResult> Update(string id, [FromBody] UpdateCartRequestDto updateCartRequestDto)
        {
            Cart updateCart = _mapper.Map<Cart>(updateCartRequestDto);
            return await _service.Update(id, updateCart);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IResult> Delete(string id)
        {
            return await _service.Delete(id);
        }
    }
}
