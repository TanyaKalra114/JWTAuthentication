using JWTAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthentication.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly object? tokenString;

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }

            if (user.UserName == "TanyaKalra" && user.Password == "TanyA@114")
            {
               var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Tanyaaakalraa@115"));
               var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7070",
                    audience: "https://localhost:7070",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: signingCredentials



                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new { Token = tokenString });
            }
            return Unauthorized();
        }
    }
}
