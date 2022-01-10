using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moto_shop.DAL;
using Moto_shop.DTO.AuthDTO;
using Moto_shop.Models;
using Moto_shop.Services;

namespace Moto_shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private JWTService _jwtService;

        public UserController(IUserRepository userRepository, JWTService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        [HttpPost("user-login")]
        public IActionResult LoginUser([FromBody] LoginDTO loginDTO)
        {
            try
            {
                var user = _userRepository.CheckPassword(loginDTO.Email, loginDTO.Password);
                if (user != null)
                {
                    var jwt = _jwtService.Generete(user.Id);
                    Response.Cookies.Append("jwt", jwt, new CookieOptions
                    {
                        HttpOnly = true
                    });
                    return Ok("Login success");
                }
                return BadRequest("Your account name or password is incorrect.");
            }
            catch (Exception)
            {

                return BadRequest("User not found");
            }
        }

        [HttpPost("user-register")]
        public IActionResult RegisterUser([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                User user = new User
                {
                    FirstName = registerDTO.FirstName,
                    LastName = registerDTO.LastName,
                    Phone = registerDTO.Phone,
                    Email = registerDTO.Email,
                    Password = registerDTO.Password
                };
                _userRepository.RegisterUser(user);
                return Created("User succesfully created ", user);
            }
            catch (Exception)
            {
                return BadRequest("Email is exist");
            }
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = _jwtService.Verify(jwt);
                int userId = int.Parse(token.Issuer);
                var user = _userRepository.GetUserById(userId);
                return Ok(user);
            }
            catch (Exception)
            {

                return Unauthorized();
            }
        }

        [HttpPost("user-logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok(new
            {
                massage = "Success logout"
            });
        }
    }
}
