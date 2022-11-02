
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
    [Route("teacher")] //http://localhost:5000
    public class TeacherController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TeacherController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody] Teacher model, [FromServices] ITeacherRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest(); //status 400

            var status = repository.Create(model);

            if (status == 1)
                return Ok(); //status 200

            return BadRequest("E-mail informado pertence a outro usuário do sistema");
        }

        [HttpGet]
        [Route("ListTeachers")]
        public IActionResult ListTeachers([FromServices] ITeacherRepository repository)
        {
            var user = repository.ListTeachers();

            string jsonString = JsonSerializer.Serialize(user);
            return Ok(jsonString);

        }
    }
}