using Curd.ModelDTO.ModelsDTO;
using Curd.Services.Account;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Curd.Services.Token
{
    public class TokenServices : ITokenServices
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountServices _accountService;

        public TokenServices(IConfiguration configuration, IAccountServices accountService)
        {
            _configuration = configuration;
            _accountService = accountService;
        }

        public async Task<string> CreateToken(LoginDto loginDTO)
        {
            var user = await _accountService.login(loginDTO.Email, loginDTO.Password);
            var claims = new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.NameId, loginDTO.Email),
                new Claim("RoleID",loginDTO.RoleId.ToString(), ClaimValueTypes.Integer),
                new Claim(ClaimTypes.Role,loginDTO.RoleName.ToString(),ClaimValueTypes.String)

            };

            var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:TokenKey"]));
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            // return ok
            return tokenHandler.WriteToken(token);
            //}


        }

    }
}
