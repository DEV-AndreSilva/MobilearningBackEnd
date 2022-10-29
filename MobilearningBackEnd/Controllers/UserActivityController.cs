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

    [Route("userActivity")] //http://localhost:5000
    public class UserActivityController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserActivityController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        [HttpPost]
        public IActionResult Create([FromBody] UserActivityView model, [FromServices] IUserActivityRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest(); //status 400

            var status = repository.Create(model);

            if (status == 1)
                return Ok(); //status 200

            return BadRequest("Essa atividade ja foi vinculada a esse aluno");
        }

        [HttpGet("{id}")]
        [Route("GetUserActivity")]
        public IActionResult Read(string id, [FromServices] IUserActivityRepository repository)
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


        [HttpGet]
        [Route("ListUsersActivities")]
        public IActionResult ListUsersActivities([FromServices] IUserActivityRepository repository)
        {
            var user = repository.ListUsersActivities();

            //var jobject =('yourVariable');
            string jsonString = JsonSerializer.Serialize(user);
            return Ok(jsonString);

        }


        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] UserActivityView model, [FromServices] IUserActivityRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            repository.Update(Convert.ToInt32(id), model);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Route("delete")]
        public IActionResult Delete(string id, [FromServices] IUserActivityRepository repository)
        {
            repository.Delete(Convert.ToInt32((id)));

            return Ok();
        }
    }
}