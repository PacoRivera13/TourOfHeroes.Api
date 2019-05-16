using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TourOfHeroes.Api.Models;

namespace TourOfHeroes.Api.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class HeroesController : Controller
   {
      private readonly IMediator _mediator;

      public HeroesController(IMediator mediator)
      {
         _mediator = mediator;
      }

      [HttpGet]
      public async Task<IActionResult> GetHeroes()
      {
         return Ok(await _mediator.Send(new HeroQueries.HeroesQuery()));
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> Get(int id)
      {
         var result = await _mediator.Send(new HeroQueries.HeroQuery() { Id = id });
         if (result == null)
         {
            return NotFound();
         }
         return Ok(result);
      }

      [HttpPost]
      public async Task<IActionResult> PostHero(Hero hero)
      {
         await _mediator.Send(new HeroCommands.HeroCreateCommand { Hero = hero });
         return CreatedAtAction(nameof(Get), new { id = hero.Id }, hero);
      }

      [HttpPut]
      public async Task<IActionResult> PutHero(int id, Hero hero)
      {
         if (id != hero.Id)
         {
            return BadRequest();
         }
         await _mediator.Send(new HeroCommands.HeroUpdateCommand { Hero = hero });
         return NoContent();
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteHero(int id)
      {
         await _mediator.Send(new HeroCommands.HeroDeleteCommand { Id = id });
         return NoContent();
      }
   }
}