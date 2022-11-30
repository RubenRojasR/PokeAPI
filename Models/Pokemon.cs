using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPI.Models
{
    public class Pokemon
    {
        public int Base_experience { get; set; }
        
        public int Height { get; set; }
        
        public string Name { get; set; }

        public List<PokeType> Types { get; set; }

        public Sprites Sprites { get; set; }

        public Stats[] Stats { get; set; }

        public int Weight { get; set; }


    }
}
