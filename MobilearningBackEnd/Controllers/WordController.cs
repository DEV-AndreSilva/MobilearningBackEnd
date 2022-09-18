using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobilerningBackEnd.Models;
using MobilerningBackEnd.Repositories;

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
                    var id =  new Guid(User.Identity.Name);
                    var tarefas = repository.Read(id);
                    return Ok(tarefas);
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
                    model.UserId = new Guid(User.Identity.Name);

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
            
            repository.Update(new Guid(id), model);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id, [FromServices]IWordRepository repository)
        {
            repository.Delete(new Guid(id));

            return Ok();
        }

    }
}