using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibManagementApi.Models;
using Org.BouncyCastle.Ocsp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace LibManagementApi.Controllers
{
    [Route("[controller]")]
    public class AuthenticationController : Controller
    {
        private readonly LibDbContext _context;
        public AuthenticationController(LibDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Users inputuser)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(usr => usr.Username == inputuser.Username && usr.Password == inputuser.Password);
                if (user == null)
                    return Unauthorized();
                return new ObjectResult(GenerateToken(user));

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        private dynamic GenerateToken(Users user)
        {
            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Username),
                new Claim(ClaimTypes.NameIdentifier,user.UserID.ToString()),
                new Claim(ClaimTypes.Role,user.Role),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())
            };
            var token = new JwtSecurityToken(
                new JwtHeader(
                    new SigningCredentials(
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes("My Secret 12345678910 is very long")),
                        SecurityAlgorithms.HmacSha256)),
                new JwtPayload(claim)
            );
            var output = new
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserID = user.UserID
            };
            return output;
        }
        [HttpGet]
        public async Task<string> CheckVersion()
        {
            return "Version 1.1";
        }
    }
}