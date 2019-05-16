using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TourOfHeroes.Api.Models;

namespace TourOfHeroes.Api.Controllers
{
   public class HeroesQueryHandler : IRequestHandler<HeroQueries.HeroesQuery, IEnumerable<Hero>>
   {
      private readonly HeroContext _heroContext;

      public HeroesQueryHandler(HeroContext heroContext)
      {
         this._heroContext = heroContext;
      }

      public async Task<IEnumerable<Hero>> Handle(HeroQueries.HeroesQuery request, CancellationToken cancellationToken)
      {
         if (_heroContext.Heroes.Count() == 0)
         {
            _heroContext.Heroes.AddRange(new Collection<Hero>()
            {
               new Hero{ Id = 11, Name = "Capitan America", Active =  true },
               new Hero{ Id = 12, Name = "Ironman", Active =  true },
               new Hero{ Id = 13, Name = "Black-Widow", Active =  false },
               new Hero{ Id = 14, Name = "Chapulin", Active =  true },
               new Hero{ Id = 15, Name = "Hulk", Active =  true },
               new Hero{ Id = 16, Name = "Ant-man", Active =  true },
               new Hero{ Id = 17, Name = "Spiderman", Active =  true },
               new Hero{ Id = 18, Name = "Thor", Active =  true },
               new Hero{ Id = 19, Name = "Loki", Active =  false },
               new Hero{ Id = 20, Name = "Valkiria", Active =  false },
               new Hero{ Id = 21, Name = "Thanos", Active = false },
            });
            _heroContext.SaveChanges();
         }
         return await _heroContext.Heroes.ToArrayAsync();
      }
   }
}
