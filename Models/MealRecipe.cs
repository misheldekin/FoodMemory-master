using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MealRecipe
    {
        public MealRecipe(int mealID, int recipeID)
        {
            MealID = mealID;
            RecipeID = recipeID;
        }
        public int MealID { get; set; }
        public int RecipeID { get; set; }

        public MealRecipe() { }
    }
}
