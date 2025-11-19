using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Recipes
    {
        public int RecipeID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public int PrepTime { get; set; }

        public Recipes() { }

        public Recipes(int recipeID, int userID, string name, int prepTime)
        {
            this.RecipeID = recipeID;
            this.UserID = userID;
            this.Name = name;
            this.PrepTime = prepTime;
        }
    }
}
