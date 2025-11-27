using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ingredient
    {
        public int IngredientID { get; set; }

        public string IngredientName { get; set; }

        public Ingredient() { }

        public Ingredient(int IngredientID, string IngredientName)
        {
            this.IngredientID = IngredientID;
            this.IngredientName = IngredientName;
        }
    }
}
