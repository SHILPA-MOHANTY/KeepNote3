using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KeepNote3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // POST: api/user/register
        [HttpPost("register")]
        public IActionResult RegisterUser([FromBody] User user)
        {
            try
            {
                var existingUser = _userRepository.GetUserByUsername(user.Username);
                if (existingUser != null)
                {
                    return BadRequest(new { error = "Username already exists." });
                }

                var createdUser = _userRepository.CreateUser(user);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Failed to register user." });
            }
        }

        // POST: api/user/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var user = _userRepository.GetUserByUsername(loginRequest.Username);
                if (user == null || user.Password != loginRequest.Password)
                {
                    return Unauthorized(new { error = "Invalid username or password." });
                }

                // Generate and return JWT token (similar to previous examples)
                var token = GenerateJwtToken(user);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Failed to login." });
            }
        }

        // GET: api/user/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User user)
        {
            try
            {
                _userRepository.UpdateUser(id, user);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Failed to update user." });
            }
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userRepository.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Failed to delete user." });
            }
        }

        //[HttpPost("login")]
        //public IActionResult Login([FromBody] LoginRequest loginRequest)
        //{
        //    var user = _userRepository.GetUserByUsername(loginRequest.Username);
        //    if (user == null || user.Password != loginRequest.Password)
        //    {
        //        return Unauthorized(new { error = "Invalid username or password." });
        //    }

        //    // Generate JWT token
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.UTF8.GetBytes("abc.com");
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new Claim[]
        //        {
        //    new Claim(ClaimTypes.Name, user.Username),
        //    new Claim(ClaimTypes.Role, "user") // Add roles if needed
        //        }),
        //        Expires = DateTime.UtcNow.AddHours(1), // Set token expiry time
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);

        //    return Ok(new
        //    {
        //        token = tokenHandler.WriteToken(token)
        //    });
       // }
    }
}
