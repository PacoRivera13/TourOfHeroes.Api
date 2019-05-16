using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TourOfHeroes.Api.Models;

namespace TourOfHeroes.Api.Controllers
{
   public class HeroQueryHandler : IRequestHandler<HeroQueries.HeroQuery, Hero>
   {
      private readonly HeroContext heroDbContext;

      public HeroQueryHandler(HeroContext heroDbContext)
      {
         this.heroDbContext = heroDbContext;
      }

      public async Task<Hero> Handle(HeroQueries.HeroQuery request, CancellationToken cancellationToken)
      {
         return await heroDbContext.Heroes.FindAsync(request.Id);
      }
   }
}
