using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TourOfHeroes.Api.Models;

namespace TourOfHeroes.Api.Controllers
{
   public class HeroesByNameQueryHandler : IRequestHandler<HeroQueries.HeroesByNameQuery, IEnumerable<Hero>>
   {
      private readonly HeroContext heroDbContext;

      public HeroesByNameQueryHandler(HeroContext heroDbContext)
      {
         this.heroDbContext = heroDbContext;
      }

      public async Task<IEnumerable<Hero>> Handle(HeroQueries.HeroesByNameQuery request, CancellationToken cancellationToken)
      {
         return await heroDbContext.Heroes.Where(h => h.Name.Contains(request.Name,System.StringComparison.OrdinalIgnoreCase)).ToListAsync();
      }
   }
}
