using Dtos;
using Rookies_EcommerceWebsite.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Rookies_EcommerceWebsite.Data.Entities;
using Rookies_EcommerceWebsite.Utils;
using Rookies_EcommerceWebsite.Data;
using AutoMapper;

namespace Rookies_EcommerceWebsite.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration config;
        private readonly JwtSettings jwtSettings;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(IConfiguration config, SignInManager<User> signInManager, UserManager<User> userManager, JwtSettings jwtSettings, ApplicationDbContext context, IMapper mapper) 
        {
            this.config = config;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.jwtSettings = jwtSettings;
            this._context = context;    
            this._mapper = mapper;
        }

        public async Task<IResult> Login(string userName, string password)
        {
            //signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;
            var result = await signInManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                //var stringToken = await CreateToken(email);
                User userInfo = await userManager.FindByNameAsync(userName);
                
                LoggedInResponse response = _mapper.Map<LoggedInResponse>(userInfo);
                Console.Write(response.ToString());

                return Results.Ok(response);
            }

            return Results.Unauthorized();
        }

        public async Task<IResult> Logout(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> Register(User user, string password)
        {
            var result = await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, "Member");

            if (result.Succeeded)
            {
                RegisterSuccessResponseDto response = new RegisterSuccessResponseDto() 
                {
                    Email = user.Email,
                    Username = user.UserName,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    Address = user.Address,
                    DateOfBirth = DateTime.Parse(user.DateOfBirth.ToString()),
                };
                return Results.Ok(response);
            }

            return Results.BadRequest();
        }

        public async Task<IResult> GetToken(LoginRequestDto userLogins)
        {
            try
            {
                var Token = new UserTokens();
                var user = await userManager.FindByNameAsync(userLogins.UserName);
                var role = await userManager.GetRolesAsync(user);
                if (user == null)
                {
                    return Results.BadRequest("User name is not valid");
                }
                var Valid = await userManager.CheckPasswordAsync(user, userLogins.Password);
                if (Valid != null)
                {
                    var strToken = Guid.NewGuid().ToString();
                    var validity = DateTime.UtcNow.AddDays(7);
                    Token = JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        Email = user.Email,
                        GuidId = Guid.NewGuid(),
                        UserName = user.UserName,
                        Id = user.Id,
                        ExpiredTime = validity,
                        Role = role.FirstOrDefault()
                    }, jwtSettings);
                    var tokenupdate = _context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
                    tokenupdate.RefreshToken = strToken;
                    tokenupdate.RefreshTokenValidity = validity;
                    _context.Update(tokenupdate);
                    _context.SaveChanges();
                    Token.RefreshToken = strToken;
                }
                else
                {
                    return Results.BadRequest($"wrong password");
                }
                return Results.Ok(Token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public async Task<IResult> RefreshToken(RefreshTokenDto userLogins)
        {
            try
            {
                var Token = new UserTokens();
                var user = await userManager.FindByNameAsync(userLogins.UserName);
                if (user == null)
                {
                    return Results.BadRequest("User name is not valid");
                }
                var Valid = _context.Users.Where(x => x.UserName == userLogins.UserName
                && x.RefreshToken == userLogins.RefreshToken
                && x.RefreshTokenValidity > DateTime.UtcNow).Count() > 0;
                if (Valid)
                {
                    var strToken = Guid.NewGuid().ToString();
                    var validity = DateTime.UtcNow.AddDays(7);
                    Token = JwtHelpers.GenTokenkey(new UserTokens()
                    {
                        Email = user.Email,
                        GuidId = Guid.NewGuid(),
                        UserName = user.UserName,
                        Id = user.Id,
                        ExpiredTime = validity,
                    }, jwtSettings);
                    var tokenupdate = _context.Users.Where(x => x.Id == user.Id).FirstOrDefault();
                    tokenupdate.RefreshToken = strToken;
                    tokenupdate.RefreshTokenValidity = validity;
                    _context.Update(tokenupdate);
                    _context.SaveChanges();
                    Token.RefreshToken = strToken;
                }
                else
                {
                    return Results.BadRequest($"wrong password");
                }
                return Results.Ok(Token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
