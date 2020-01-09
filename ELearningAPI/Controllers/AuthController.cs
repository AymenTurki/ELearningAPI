using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ELearningAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;

namespace ELearningAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration Configuration { get; }

        public AuthController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost, Route("login")]
        public IActionResult Login([FromBody]LoginModel user)
        {
            if (ModelState.IsValid)
            {
                /*var user = await _userManager.FindByNameAsync(applicationUser.UserName);

                // Get valid claims and pass them into JWT
                var claims = await GetValidClaims(user);*/

                var claims = new List<Claim>();

                //claims.Add(new Claim(ClaimTypes.Role, "Learner"));
                //claims.Add(new Claim(ClaimTypes.Role, "Trainer"));


                /*var userRoles = await _userManager.GetRolesAsync(user);
                claims.AddRange(userClaims);
                foreach (var userRole in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                    var role = await _roleManager.FindByNameAsync(userRole);
                    if (role != null)
                    {
                        var roleClaims = await _roleManager.GetClaimsAsync(role);
                        foreach (Claim roleClaim in roleClaims)
                        {
                            claims.Add(roleClaim);
                        }
                    }
                }*/

                if (user.Email == "johndoe@test.ch" && user.Password == "def@123")
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokenOptions = new JwtSecurityToken(
                        issuer: "http://localhost:50188",
                        audience: "http://localhost:50188",//?tocheck 44309
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return Ok(new { Token = tokenString });
                }
                else
                {
                    return Unauthorized();
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost, Route("register")]
        public IActionResult Register([FromBody]NewUserModel newUser)
        {
            if (ModelState.IsValid)
            {
                return Ok(new { Message = "Successfully registered. Please log in." });
            }

            return BadRequest(ModelState);
        }

        /*[HttpPost, Authorize, Route("test")]
        public IActionResult Test()
        {
            return Ok(new { res = "good" });

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)]
			})
			.ToArray();
        }

        [HttpPost, Authorize(Roles = "Learner"), Route("test2")]
        public IActionResult Test2()
        {
            return Ok(new { res = "good learner" });
        }

        [HttpPost, Authorize(Roles = "Trainer"), Route("test3")]
        public IActionResult Test3()
        {
            return Ok(new { res = "good trainer" });
        }*/
    }
}