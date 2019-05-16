using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TourOfHeroes.Api.Models;

namespace TourOfHeroes.Api.Controllers
{
   public class HeroDeleteCommandHandler : AsyncRequestHandler<HeroCommands.HeroDeleteCommand>
   {
      private readonly HeroContext heroDbContext;

      public HeroDeleteCommandHandler(HeroContext heroDbContext)
      {
         this.heroDbContext = heroDbContext;
      }

      protected override async Task Handle(HeroCommands.HeroDeleteCommand request, CancellationToken cancellationToken)
      {
         var hero = await heroDbContext.Heroes.FindAsync(request.Id);
         heroDbContext.Heroes.Remove(hero);
         await heroDbContext.SaveChangesAsync();

      }
   }
}
