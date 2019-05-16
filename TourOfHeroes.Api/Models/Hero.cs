using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourOfHeroes.Api.Models
{
   public class Hero
   {
      public int Id { get; set; }

      public string Name { get; set; }

      public bool Active { get; set; }
   }
}
