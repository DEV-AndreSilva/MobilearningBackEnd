using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobilerningBackEnd.Models;
using MobilerningBackEnd.Repositories;
using System.Text.Json;

namespace MobilerningBackEnd.Controllers
{

    [ApiController]
    [Route("word")]
    public class WordController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult Read([FromServices]IWordRepository repository)
        {
            if(User.Identity != null)
            {
                if(User.Identity.Name != null)
                {
                    var id =  Convert.ToInt32(User.Identity.Name);
                    var words = repository.Read(id);
                    string jsonString = JsonSerializer.Serialize(words);
                    return Ok(jsonString);
                
                }
            }

            return Unauthorized();
        }

        [HttpPost]
        public IActionResult Create([FromBody]Word model, [FromServices]IWordRepository repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            if(User.Identity != null)
            {
                if(User.Identity.Name != null)
                {
                    //obtendo o id pelo token da requisição
                    model.userId = Convert.ToInt32(User.Identity.Name);

                    repository.Create(model);

                    return Ok();
                }   
            }
           
           return Unauthorized();
            
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody]Word model, [FromServices]IWordRepository repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            
            repository.Update(Convert.ToInt32(id), model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromServices]IWordRepository repository)
        {
            repository.Delete(Convert.ToInt32((id)));

            return Ok();
        }

    }
}
