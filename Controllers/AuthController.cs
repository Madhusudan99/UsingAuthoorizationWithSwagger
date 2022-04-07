using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UsingAuthoorizationWithSwagger.Models;


namespace UsingAuthoorizationWithSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (model == null)
            {
                return BadRequest("Invalid Client Request");
            }

            if (model.UserName == "string" && model.Password == "string")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@2410"));
                var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokenOptions = new JwtSecurityToken(
                    issuer: "Raytex",
                    audience: "https://localhost:5004",
                    claims: new List<Claim>(),
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signingCredentials);
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return Ok(new Token { tokenString = tokenString });
            }
            else
            {
                return BadRequest("Invalid Credentials");

            }
        }
    }
}
