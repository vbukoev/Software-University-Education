using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public List<Ingredient> ingredients { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public int CurrentAlcoholLevel => ingredients.Select(x => x.Alcohol).Sum();
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.ingredients = new List<Ingredient>();
        }
        public void Add(Ingredient ingredient)
        {
            if (!this.ingredients.Any(x=>x.Name==ingredient.Name) && this.Capacity > this.ingredients.Count && ingredient.Alcohol + CurrentAlcoholLevel<=MaxAlcoholLevel)
            {
                ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            return this.ingredients.Remove(ingredients.Find(x=>x.Name==name));
        }
        public Ingredient FindIngredient(string name)
        {
            return ingredients.Find(x => x.Name == name);
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            return this.ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            sb.AppendLine(string.Join(Environment.NewLine, ingredients));
            return sb.ToString().TrimEnd();
        }
    }
}
