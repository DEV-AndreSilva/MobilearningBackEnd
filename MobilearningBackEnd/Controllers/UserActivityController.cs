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


        [HttpGet("{idUser}")]
        [Route("ListUserActivities")]
        public IActionResult ListUserActivities(string idUser, [FromServices] IUserActivityRepository repository)
        {
            var user = repository.ListUserActivities(Convert.ToInt32(idUser));

            //var jobject =('yourVariable');
            string jsonString = JsonSerializer.Serialize(user);
            return Ok(jsonString);

        }

        [HttpGet("{idActivity}")]
        [Route("ListUsersFromActivity")]
        public IActionResult ListUsersFromActivity(string idActivity, [FromServices] IUserActivityRepository repository)
        {
            var user = repository.ListUsersFromActivity(Convert.ToInt32(idActivity));

            //var jobject =('yourVariable');
            string jsonString = JsonSerializer.Serialize(user);
            return Ok(jsonString);

        }
        


        [HttpPut("{id}")]
        [Route("update")]
        public IActionResult Update(string id, [FromBody] UserActivityView model, [FromServices] IUserActivityRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            repository.Update(Convert.ToInt32(id), model);

            return Ok();
        }

        [Route("delete")]
        public IActionResult Delete(string idUser, string idActivity, [FromServices] IUserActivityRepository repository)
        {
            repository.Delete(Convert.ToInt32(idUser), Convert.ToInt32(idActivity));

            return Ok();
        }
    }
}