using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Interfaces;

namespace Rookies_EcommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IService<User> _service;
        private readonly IMapper _mapper;

        public UserController(IService<User> service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public Task<IResult> Get()
        {
            return _service.GetAll(); 
        }
        
        [HttpGet]
        [Route("{id}")]
        public Task<IResult> Get(string id)
        {
            return _service.GetById(id); 
        }
    }
}
