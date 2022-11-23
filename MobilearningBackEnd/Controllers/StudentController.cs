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
    [Route("student")] //http://localhost:5000
    public class StudentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Student model, [FromServices] IStudentRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest(); //status 400

            var idUserCreate = repository.Create(model);

            if (idUserCreate > 0)
            {
                Dictionary<String, int> usuario = new Dictionary<string, int> ();
                usuario.Add("idUser", idUserCreate);
                string idUserRetorno = JsonSerializer.Serialize(usuario);
                
                return Ok(idUserRetorno); //status 200
            }
            else if (idUserCreate == -1)
            {
                return BadRequest("E-mail informado pertence a outro usuário do sistema");
            }
            else
             return BadRequest("Erro interno, procure o administrador");
            
            
        }

        [HttpGet]
        [Route("ListStudents")]
        public IActionResult ListStudents([FromServices] IStudentRepository repository)
        {
            var user = repository.ListStudents();

            string jsonString = JsonSerializer.Serialize(user);
            return Ok(jsonString);

        }
    }
}