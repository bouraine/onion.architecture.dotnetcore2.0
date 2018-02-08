using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Onion.Web.API.Controllers
{
    [Route("api/[controller]")]
    public class IdentityController : Controller
    {
        private IConfiguration _Configuration { get; }

        public IdentityController(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Post([FromBody]LoginViewModel loginViewModel)
        {
            string Issuer = _Configuration.GetSection("AuthCredentials").GetSection("Issuer").Value;
            string Audience = _Configuration.GetSection("AuthCredentials").GetSection("Audience").Value;
            string SigningKey = _Configuration.GetSection("AuthCredentials").GetSection("SigningKey").Value;

            if (ModelState.IsValid)
            {
                //call identity service
                //This method returns user id from username and password.
                var userId = 1;//for tests
                if (userId == -1)
                {
                    return Unauthorized();
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.UniqueName, loginViewModel.Login),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                
                var token = new JwtSecurityToken
                (
                    issuer: Issuer,
                    audience: Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(60),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SigningKey)),
                            SecurityAlgorithms.HmacSha256)
                    
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest();
        }
    }

    public class LoginViewModel
    {
        public string ClientID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}