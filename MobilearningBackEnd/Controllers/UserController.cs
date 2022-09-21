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
    public class UserController: ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Create([FromBody]User model , [FromServices]IUserRepository repository)
        {
            if(!ModelState.IsValid)
                return BadRequest(); //status 400

            var status = repository.Create(model);

            if (status ==1)
            return Ok(); //status 200

            return BadRequest("E-mail informado pertence a outro usuário do sistema");
        }
        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]UserLogin model,[FromServices]IUserRepository repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var usuario = repository.Read(model.Email,model.Password);

            if(usuario == null )
                return Unauthorized();

            usuario.Password = "";
            return Ok(new {
                usuario = usuario,
                token = GenerateToken(usuario)
            });
        }

        [HttpGet]
        [Route("listUsers")]
        public IActionResult  listUsers([FromServices]IUserRepository repository)
        {
            var user = repository.listUsers();
            
            //var jobject =('yourVariable');
           string jsonString = JsonSerializer.Serialize(user);
           return Ok(jsonString);
            
            

            // var responseError = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            // return responseError;
        }

        private string GenerateToken(User usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var  keyString = _configuration.GetSection("MySettings").GetSection("Key").Value;

            Console.WriteLine(keyString);

            var key = Encoding.ASCII.GetBytes(keyString);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature
                )
                
            };

            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}