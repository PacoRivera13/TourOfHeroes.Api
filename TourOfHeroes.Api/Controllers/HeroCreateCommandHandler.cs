using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TourOfHeroes.Api.Models;

namespace TourOfHeroes.Api.Controllers
{
   public class HeroCreateCommandHandler : AsyncRequestHandler<HeroCommands.HeroCreateCommand>
   {
      private readonly HeroContext heroDbContext;

      public HeroCreateCommandHandler(HeroContext heroDbContext)
      {
         this.heroDbContext = heroDbContext;
      }

      protected override async Task Handle(HeroCommands.HeroCreateCommand request, CancellationToken cancellationToken)
      {
         heroDbContext.Heroes.Add(request.Hero);
         await heroDbContext.SaveChangesAsync();
      }
   }
}
