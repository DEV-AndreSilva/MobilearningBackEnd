using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MobilerningBackEnd.Models;
using MobilerningBackEnd.Models.ViewModels;
using MobilerningBackEnd.Repositories;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MobilerningBackEnd.Controllers
{
    [ApiController]
    [Route("user")] //http://localhost:5000
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] UserLogin model, [FromServices] IUserRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var usuario = repository.Read(model.email!, model.password!);

            if (usuario == null)
                return Unauthorized();

            usuario.password = "";
            string token = GenerateToken(usuario);

            List<Object> teste = new List<Object>();
            teste.Add(usuario);
            teste.Add(token);

            string jsonString = JsonSerializer.Serialize(teste);


            return Ok(jsonString);
        }

        [HttpGet]
        [Route("ListUsers")]
        public IActionResult ListUsers([FromServices] IUserRepository repository)
        {
            var user = repository.ListUsers();

            //var jobject =('yourVariable');
            string jsonString = JsonSerializer.Serialize(user);
            return Ok(jsonString);
        }

        private string GenerateToken(User usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var keyString = _configuration.GetSection("MySettings").GetSection("Key").Value;

            Console.WriteLine(keyString);

            var key = Encoding.ASCII.GetBytes(keyString);

            var type = usuario.type == null ? "undefined" : usuario.type.ToString();

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, usuario.id.ToString()),
                    new Claim(ClaimTypes.Role, type)
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature
                )

            };

            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }

        [Route("UpdateUser")]
        public IActionResult UpdateUser([FromBody] User model, [FromServices] IUserRepository repository)
        {

            User? user = repository.Update(model);
            if (user != null)
            {
                string jsonString = JsonSerializer.Serialize(user);
                return Ok(jsonString);
            }
            else
            {
                return BadRequest();
            }
        }


    }
}