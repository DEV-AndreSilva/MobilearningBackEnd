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
        public IActionResult Get([FromServices]IWordRepository repository)
        {
            var tarefas = repository.Read();
            return Ok(tarefas);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Word model, [FromServices]IWordRepository repository)
        {
            if(!ModelState.IsValid)
                return BadRequest();
            
            repository.Create(model);

            return Ok();
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