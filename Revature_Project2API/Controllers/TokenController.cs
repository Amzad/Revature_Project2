namespace Revature_Project2API.Controllers
{
    using System;
    using System.Collections.Generic;
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
        public async Task<IActionResult> Authenticate([FromBody]Customer user)
        {
            System.Diagnostics.Debug.WriteLine("TokenController TokenMethod");
            Console.WriteLine("TokenController TokenMethod");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userIdentified = _context.Customers.FirstOrDefault(u => u.CustomerEmail == user.CustomerEmail);
            if (userIdentified == null)
            {
                return Unauthorized();
            }
            System.Diagnostics.Debug.WriteLine("TokenController TokenMethod1");
            user = userIdentified;

            //Add Claims
            var claims = new List<Claim>
            {
            new Claim(JwtRegisteredClaimNames.UniqueName, "data"),
            new Claim(JwtRegisteredClaimNames.Sub, "data"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            //new Claim(JwtRegisteredClaimNames.Email, user.CustomerEmail ),
            //new Claim(JwtRegisteredClaimNames.GivenName, userIdentified.CustomerFirstName),
            //new Claim(JwtRegisteredClaimNames.FamilyName, userIdentified.CustomerLastName)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890abcdef")); //Secret
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
                token_type = "bearer",
                firstName = userIdentified.CustomerFirstName,
                lastName = userIdentified.CustomerLastName,
                customerID = userIdentified.CustomerID,
                email = userIdentified.CustomerEmail

            }); ;
        }

        [AllowAnonymous]
        [Route("api/create")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody]Customer user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // Check if username exsits
            var userIdentified = _context.Customers.FirstOrDefault(u => u.Username == user.Username);
            if (userIdentified != null)
            {
                return Unauthorized("Username already exists");
            }
            var emailIdentified = _context.Customers.FirstOrDefault(u => u.CustomerEmail == user.CustomerEmail);
            if (emailIdentified != null)
            {
                return Unauthorized("Email already exists");
            }

            Customer cust = new Customer()
            {
                Username = user.Username,
                Password = user.Password,
                CustomerFirstName = user.CustomerFirstName,
                CustomerLastName = user.CustomerLastName,
                CustomerEmail = user.CustomerEmail,
                CustomerAddress = user.CustomerAddress,
                CustomerPhoneNumber = user.CustomerPhoneNumber,
                CustomerID = 0
            };
            _context.Customers.Add(cust);
            _context.SaveChanges();


            //Add Claims
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.UniqueName, "data"),
            new Claim(JwtRegisteredClaimNames.Sub, "data"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890abcdef")); //Secret
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

