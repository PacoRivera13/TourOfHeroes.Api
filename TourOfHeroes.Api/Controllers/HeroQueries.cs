using System.Collections.Generic;
using MediatR;
using TourOfHeroes.Api.Models;

namespace TourOfHeroes.Api.Controllers
{
   public class HeroQueries
   {
      public class HeroesQuery : IRequest<IEnumerable<Hero>>
      {
      }

      public class HeroQuery : IRequest<Hero>
      {
         public int Id { get; set; }
      }

      public class HeroesByNameQuery : IRequest<IEnumerable<Hero>>
      {
         public string Name { get; set; }
      }
   }
}
