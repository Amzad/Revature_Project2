namespace Revature_Project2API.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using Revature_Project2API.Data;
    using Revature_Project2API.Models;

    public class TokenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TokenController(ApplicationDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [Route("api/token")]
        [HttpPost]
        public async Task<IActionResult> Token([FromBody]Customer user)
        {
            System.Diagnostics.Debug.WriteLine("TokenController TokenMethod");
            Console.WriteLine("TokenController TokenMethod");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userIdentified = _context.Customers.FirstOrDefault(u => u.Username == user.Username);
            if (userIdentified == null)
            {
                return Unauthorized();
            }
            System.Diagnostics.Debug.WriteLine("TokenController TokenMethod1");
            user = userIdentified;

            //Add Claims
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.UniqueName, "data"),
            new Claim(JwtRegisteredClaimNames.Sub, "data"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("rlyaKithdrYVl6Z80ODU350md")); //Secret
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken("me",
                "you",
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);
            System.Diagnostics.Debug.WriteLine("TokenController TokenMethod3");
            return Ok(new
            {
                access_token = new JwtSecurityTokenHandler().WriteToken(token),
                expires_in = DateTime.Now.AddMinutes(30),
                token_type = "bearer"
            });
        }

    }
}

