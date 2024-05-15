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
    public class VariantController : ControllerBase
    {
        private readonly IService<Variant> _service;
        private readonly IMapper _mapper;

        public VariantController(IService<Variant> service, IMapper mapper)
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
        public async Task<IResult> Create([FromBody] CreateVariantRequestDto productDto)
        {
            Variant createVariant = _mapper.Map<Variant>(productDto);
            return await _service.Create(createVariant);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IResult> Update(string id, [FromBody] UpdateVariantRequestDto updateVariantRequestDto)
        {
            Variant updateVariant = _mapper.Map<Variant>(updateVariantRequestDto);
            return await _service.Update(id, updateVariant);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IResult> Delete(string id)
        {
            return await _service.Delete(id);
        }
    }
}
