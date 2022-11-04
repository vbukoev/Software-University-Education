using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        private List<Pokemon> pokemons;
        public string Name { get; set; }
        public int Badges { get; set; } 
        public Trainer(string name)
        {
            Name = name;
            Badges = 0;
            pokemons = new List<Pokemon>();
        }
        public void AddPokemon(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
        }
        public void Check(string element)
        {
            foreach (var item in pokemons)
            {
                if (item.Element == element)
                {
                    Badges++;
                    break;
                }
                else
                {
                    item.Health = item.Health - 10;
                }
            }
            for (int i = 0; i < pokemons.Count; i++)
            {
                Pokemon pokemon = pokemons[i];
                if (pokemon.Health <= 0)
                {
                    pokemons.Remove(pokemon);
                    i--;
                }
            }
        }
        public override string ToString()
        {
            return $"{Name} {Badges} {pokemons.Count}";
        }
    }
}
