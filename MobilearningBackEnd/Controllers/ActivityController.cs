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

    [Route("activity")] //http://localhost:5000
    public class ActivityController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ActivityController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        public IActionResult Create([FromBody] Activity model, [FromServices] IActivityRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest(); //status 400

            var status = repository.Create(model);

            if (status == 1)
                return Ok(); //status 200

            return BadRequest("Uma outra atividade com o mesmo titulo ja foi cadastrada");
        }

        [HttpGet("{id}")]
        [Route("GetActivity")]
        public IActionResult Read(string id, [FromServices] IActivityRepository repository)
        {

            if (!ModelState.IsValid)
                return BadRequest(); //status 400

            else
            {
                var activity = repository.Read(Convert.ToInt32(id));
                string jsonString = JsonSerializer.Serialize(activity);
                return Ok(jsonString);
            }
        }


        [HttpGet("{idTeacher}")]
        [Route("listActivities")]
        public IActionResult listActivities(string idTeacher,[FromServices] IActivityRepository repository)
        {
            var user = repository.ListActivities(Convert.ToInt32(idTeacher));

            //var jobject =('yourVariable');
            string jsonString = JsonSerializer.Serialize(user);
            return Ok(jsonString);

        }

        [HttpPut]
        [Route("update")]
        public IActionResult Update(string id, [FromBody] Activity model, [FromServices] IActivityRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            repository.Update(Convert.ToInt32(id), model);

            return Ok();
        }

        [HttpDelete("{id}/{idTeacher}")]
        [Route("delete")]
        public IActionResult Delete(string id,string idTeacher, [FromServices] IActivityRepository repository)
        {
            repository.Delete(Convert.ToInt32((id)),Convert.ToInt32((idTeacher)));

            return Ok();
        }
    }
}