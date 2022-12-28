using Curd.Model.Models;
using Curd.ModelDTO.ModelsDTO;
using Curd.Services.Account;
using Curd.Services.Roles;
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
        private readonly IRoleServices _roleServices;

        public TokenServices(IConfiguration configuration, IAccountServices accountService,IRoleServices roleServices)
        {
            _configuration = configuration;
            _accountService = accountService;
            _roleServices = roleServices;
        }

        public async Task<TokenDto> CreateToken(LoginDto loginDTO)
        {
            var user = await _accountService.login(loginDTO.Email, loginDTO.Password);
            var role = await _roleServices.getRoleById(user.RoleId);
            var claims = new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.NameId, loginDTO.Email),
                new Claim("RoleID",Convert.ToString(role.Id), ClaimValueTypes.Integer),
                new Claim(ClaimTypes.Name,user.Name.ToString(),ClaimValueTypes.String)

            };

            var _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:TokenKey"]));
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new JwtSecurityToken
            (
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds);

          
            TokenDto tokenDto = new TokenDto();
            tokenDto.Token = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
            tokenDto.ExpiryTime = tokenDescriptor.ValidTo;
            return tokenDto;

            // return tokenHandler.WriteToken(token);
            // return ;
            //}


        }

    }
}
