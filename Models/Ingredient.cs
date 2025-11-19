using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ingredient
    {
        public string IngredientID { get; set; }

        public string IngredientName { get; set; }

        public Ingredient() { }

        public Ingredient(string IngredientID, string IngredientName)
        {
            this.IngredientID = IngredientID;
            this.IngredientName = IngredientName;
        }
    }
}
