using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TourOfHeroes.Api.Models;

namespace TourOfHeroes.Api.Controllers
{
   public class HeroUpdateCommandHandler : AsyncRequestHandler<HeroCommands.HeroUpdateCommand>
   {
      private readonly HeroContext heroDbContext;

      public HeroUpdateCommandHandler(HeroContext heroDbContext)
      {
         this.heroDbContext = heroDbContext;
      }

      protected override async Task Handle(HeroCommands.HeroUpdateCommand request, CancellationToken cancellationToken)
      {
         heroDbContext.Entry(request.Hero).State = EntityState.Modified;
         await heroDbContext.SaveChangesAsync();
      }
   }
}
