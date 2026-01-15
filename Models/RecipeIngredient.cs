using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RecipeIngredient
    {
        public int RecipeID { get; set; }
        public int IngredientID { get; set; }
        public double Quantity { get; set; }
        public string Size { get; set; }

        public RecipeIngredient() { }

        public RecipeIngredient(int recipeID, int ingredientID, double quantity, string size)
        {
            RecipeID = recipeID;
            IngredientID = ingredientID;
            Quantity = quantity;
            Size = size;
        }
    }
}
