
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDo.Models;
using ToDo.Services.Abstract;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config, IUserService service)
        {
            _config = config;
            _service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] UserLogin userLogin)
        {
            var user = await Authenticate(userLogin);
            if (user != null)
            {
                var token = GenerateToken(user);
                return Ok(token);
            }

            return NotFound("user not found");
        }

        // To generate token
        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.Username),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        //To authenticate user
        private async Task<User> Authenticate(UserLogin userLogin)
        {
            //var currentUser = UserConstants.Users.FirstOrDefault(x => x.Username.ToLower() ==
            //    userLogin.Username.ToLower() && x.Password == userLogin.Password);
            var currentUser = await _service.Get(userLogin.Username);
            if (currentUser != null && currentUser.Password == userLogin.Password)
            {
                return currentUser;
            }
            return null;
        }
    }
}