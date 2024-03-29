﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeAPI.Models
{
    public class PokeResponse
    {
        public int Count { get; set; }

        public string Next { get; set; }

        public string? Previous { get; set; }

        public List<PokemonItemList> Results { get; set; }
    }
}
