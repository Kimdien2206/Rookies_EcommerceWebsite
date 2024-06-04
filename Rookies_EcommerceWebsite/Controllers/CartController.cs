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
    public class CartController : ControllerBase
    {
        private readonly CartService _service;
        private readonly IMapper _mapper;

        public CartController(CartService service, IMapper mapper)
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
            Cart creatingCart = _mapper.Map<Cart>(cartDto);
            if(creatingCart == null)
            {
                return Results.BadRequest();
            }
            return await _service.Create(creatingCart);
        }
                
        [HttpPatch]
        [Route("{id}")]
        public async Task<IResult> Update(string id, [FromBody] UpdateCartRequestDto updateCartRequestDto)
        {
            Cart updateCart = _mapper.Map<Cart>(updateCartRequestDto);
            if (updateCart == null)
            {
                return Results.BadRequest();
            }
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
