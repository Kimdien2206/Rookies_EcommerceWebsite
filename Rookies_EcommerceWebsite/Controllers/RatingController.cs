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
    public class RatingController : ControllerBase
    {
        private readonly RatingService _service;
        private readonly IMapper _mapper;

        public RatingController(RatingService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
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
        public async Task<IResult> Create([FromBody] CreateRatingRequestDto ratingDto)
        {
            Rating createRating = _mapper.Map<Rating>(ratingDto);
            if(createRating == null)
            {
                return Results.BadRequest();
            }
            return await _service.Create(createRating);
        }

        [HttpPatch]
        [Authorize]
        [Route("{id}")]
        public async Task<IResult> Update(string id, [FromBody] UpdateRatingRequestDto updateRatingRequestDto)
        {
            Rating updateRating = _mapper.Map<Rating>(updateRatingRequestDto);
            if(updateRating == null)
            {
                return Results.BadRequest();
            }
            return await _service.Update(id, updateRating);
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
