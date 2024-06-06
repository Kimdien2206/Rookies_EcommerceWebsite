using Dtos;
using Rookies_EcommerceWebsite.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Utils;

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
                PhoneNumber = registerRequestModel.PhoneNumber,
            };

            return await _authRepository.Register(registerUser, registerRequestModel.Password);
        }

        [HttpPost]
        [Route("RefreshToken")]
        public async Task<IResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
        {
            return await _authRepository.RefreshToken(refreshTokenDto);
        }
        
        [HttpPost]
        [Route("GetToken")]
        public async Task<IResult> GetToken([FromBody] LoginRequestDto userLogins)
        {
            return await _authRepository.GetToken(userLogins);
        }
    }
}
