using MediatR;
using TourOfHeroes.Api.Models;

namespace TourOfHeroes.Api.Controllers
{
    public class HeroCommands
    {
      public class HeroCreateCommand : IRequest
      {
         public Hero Hero { get; set; }
      }

      public class HeroDeleteCommand : IRequest
      {
         public int Id { get; set; }
      }

      public class HeroUpdateCommand : IRequest
      {
         public Hero Hero { get; set; }
      }
   }
}
