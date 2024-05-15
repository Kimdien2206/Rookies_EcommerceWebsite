using Dtos;
using Rookies_EcommerceWebsite.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Rookies_EcommerceWebsite.Data.Entities;

namespace Rookies_EcommerceWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            this._authRepository = authRepository;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IResult> Login([FromBody] LoginRequestDto loginRequestModel)
        {
            return await _authRepository.Login(loginRequestModel.UserName, loginRequestModel.Password);
        }
        
        [HttpPost]
        [Route("Logout")]
        public async Task<IResult> Logout([FromBody] LoginRequestDto loginRequestModel)
        {
            return await _authRepository.Login(loginRequestModel.UserName, loginRequestModel.Password);
        }

        [HttpPost]
        [Route("Register")]

        public async Task<IResult> Register([FromBody] RegisterRequestDto registerRequestModel)
        {
            User registerUser = new User()
            {
                Email = registerRequestModel.Email,
                UserName = registerRequestModel.Username,
                Address = registerRequestModel.Address,
                DateOfBirth = DateOnly.FromDateTime(registerRequestModel.DateOfBirth),
                FirstName = registerRequestModel.FirstName,
                LastName = registerRequestModel.LastName,
            };

            return await _authRepository.Register(registerUser, registerRequestModel.Password);
        }

        [HttpGet]
        [Route("ConfirmEmail")]

        public IActionResult ConfirmEmail()
        {
            return Ok();

        }
        
        [HttpPost]
        [Route("ResendEmail")]

        public IActionResult ResendEmail()
        {
            return Ok();

        }

        [HttpPost]
        [Route("ForgotPassword")]

        public IActionResult ForgotPassword()
        {
            return Ok();

        }

        [HttpPost]
        [Route("RefreshToken")]

        public IActionResult RefreshToken()
        {
            return Ok();
        }
    }
}
