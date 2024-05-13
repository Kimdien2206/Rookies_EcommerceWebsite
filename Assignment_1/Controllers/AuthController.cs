using Assignment_1.Dtos;
using Assignment_1.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
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
            return await _authRepository.Login(loginRequestModel.Email, loginRequestModel.Password);
            
        }

        [HttpPost]
        [Route("Register")]

        public async Task<IResult> Register([FromBody] RegisterRequestDto registerRequestModel)
        {
            return await _authRepository.Register(registerRequestModel.Username, registerRequestModel.Email, registerRequestModel.Password);
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
