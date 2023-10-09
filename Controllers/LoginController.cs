using BharatMedics.Repository.AdminRepo;
using BharatMedics.Repository.Doctor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BharatMedics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IAdminLogin adminLogin;
        private readonly IDoctorLogin doctorLogin;
        public LoginController(IConfiguration configuration, IAdminLogin adminLogin, IDoctorLogin doctorLogin)
        {
            _configuration = configuration;
            this.adminLogin = adminLogin;
            this.doctorLogin = doctorLogin;
           
        }
        
        [HttpPost("Admin Login")]
        public IActionResult AdminLogin(long phn, string password)
        {
            var existingUser = adminLogin.Login(phn, password);
            if (existingUser == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString()),
                new Claim(ClaimTypes.Role,"Admin")
            };

            var token = GenerateJwtToken(claims);
            return Ok(new { token });
        }
        [HttpPost("Doctor Login")]
        public IActionResult DoctorLogin(string email, string password)
        {
            var existingUser = doctorLogin.Login(email, password);
            if (existingUser == null)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString()),
                new Claim(ClaimTypes.Role,"Doctor")
            };

            var token = GenerateJwtToken(claims);
            return Ok(new { token });
        }


        private string GenerateJwtToken(Claim[] claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

