using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace TourOfHeroes.Api.Models
{
   public class HeroContext : DbContext
   {
      public HeroContext(DbContextOptions options) 
         : base(options)
      {
      }

      public DbSet<Hero> Heroes { get; set; }
   }
}
