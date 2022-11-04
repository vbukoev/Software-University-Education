using System;
namespace _04PizzaCalories
{
    public class Dough
    {
        //White - 1.5
        //Wholegrain - 1.0
        //Crispy - 0.9
        //Chewy - 1.1
        //Homemade - 1.0
        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy=1.1;
        private const double Homemade = 1;
        private string flourType;
        private string backingTechnique;
        private double grams;
        private string FlourType
        {
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain") throw new ArgumentException("Invalid type of dough.");
                flourType = value;
            }
        }
        private string BackingTechnique
        {
            set 
            { 
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade") 
                throw new ArgumentException("Invalid type of dough.");
                backingTechnique = value;
            }
        }
        private double Grams
        {
            set
            {
                if (value < 1|| value >200)
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                grams = value;
            }
        }
        private double CaloriesPerGram
        {
            get
            {
                double getColories = 2;
                if (this.flourType.ToLower() == "white") getColories *= White;
                else if (this.flourType.ToLower() == "wholegrain") getColories *= Wholegrain;
                if (backingTechnique.ToLower() == "crispy") getColories *= Crispy;  
                else if (backingTechnique.ToLower() == "chewy") getColories *= Chewy;  
                else if (backingTechnique.ToLower() == "homemade") getColories *= Homemade;  
                return getColories;
            }
        }
        public Dough(string flourType, string backingTechnique, double grams)
        {
            FlourType = flourType;
            BackingTechnique = backingTechnique;
            this.Grams = grams; 
        }
        public double GetCalories()
        {
            return grams * CaloriesPerGram;
        }
    }
}
