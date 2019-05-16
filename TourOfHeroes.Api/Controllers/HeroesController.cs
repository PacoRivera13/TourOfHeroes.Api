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
      private readonly IMediator mediator;

      public HeroesController(IMediator mediator)
      {
         this.mediator = mediator;
      }

      [HttpGet]
      public async Task<IActionResult> GetHeroes()
      {
         return Ok(await mediator.Send(new HeroQueries.HeroesQuery()));
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> Get(int id)
      {
         var result = await mediator.Send(new HeroQueries.HeroQuery() { Id = id });
         if (result == null)
         {
            return NotFound();
         }
         return Ok(result);
      }

      [HttpGet()]
      [Route(nameof(HeroesController.Search))]
      public async Task<IActionResult> Search(string name)
      {
         var result = await mediator.Send(new HeroQueries.HeroesByNameQuery() { Name = name });
         if (result == null)
         {
            return NotFound();
         }
         return Ok(result);
      }

      [HttpPost]
      public async Task<IActionResult> PostHero(Hero hero)
      {
         await mediator.Send(new HeroCommands.HeroCreateCommand { Hero = hero });
         return CreatedAtAction(nameof(Get), new { id = hero.Id }, hero);
      }

      [HttpPut]
      public async Task<IActionResult> PutHero(Hero hero)
      {
         await mediator.Send(new HeroCommands.HeroUpdateCommand { Hero = hero });
         return NoContent();
      }

      [HttpDelete("{id}")]
      public async Task<IActionResult> DeleteHero(int id)
      {
         await mediator.Send(new HeroCommands.HeroDeleteCommand { Id = id });
         return NoContent();
      }
   }
}