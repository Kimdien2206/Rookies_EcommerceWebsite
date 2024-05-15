using Dtos;
using Rookies_EcommerceWebsite.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Rookies_EcommerceWebsite.Data.Entities;

namespace Rookies_EcommerceWebsite.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration config;

        public AuthRepository(IConfiguration config, SignInManager<User> signInManager, UserManager<User> userManager) 
        {
            this.config = config;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<IResult> Login(string email, string password)
        {
            signInManager.AuthenticationScheme = IdentityConstants.BearerScheme;
            var result = await signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                //var stringToken = await CreateToken(email);
                return Results.Empty;
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

            if (result.Succeeded)
            {
                var stringToken = await CreateToken(user.Email);
                RegisterSuccessResponseDto response = new RegisterSuccessResponseDto() 
                {
                    Email = user.Email,
                    Username = user.UserName,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    Address = user.Address,
                    DateOfBirth = DateTime.Parse(user.DateOfBirth.ToString()),
                    AccessToken = stringToken
                };
                return Results.Ok(response);
            }

            return Results.BadRequest();
        }



        private async Task<string> CreateToken(string email)
        {
            var issuer = config["Jwt:Issuer"];
            var audience = config["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes
            (config["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, email),
                        new Claim(JwtRegisteredClaimNames.Email, email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    }),
                Expires = DateTime.UtcNow.AddDays(14),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };

            var identityUser = await userManager.FindByEmailAsync(email);
            //var roles = await userManager.GetRolesAsync(identityUser);

            //foreach (var role in roles)
            //{
            //    tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
            //}

            // generate token with the above information
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
