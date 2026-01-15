using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBL
{
    public class MealRecipeDB : BaseDB<MealRecipe>
    {
        protected override string GetTableName()
        {
            return "meal_recipe";
        }

        protected override string GetPrimaryKeyName()
        {
            return "";
        }

        protected override async Task<MealRecipe> CreateModelAsync(object[] row)
        {
            MealRecipe MR = new MealRecipe();
            MR.MealID = int.Parse(row[0].ToString());
            MR.RecipeID = int.Parse(row[1].ToString());
            return MR;
        }

        public async Task<int> InsertAsync(MealRecipe c)
        {
            Dictionary<string, object> fill = new Dictionary<string, object>()
      {
        { "MealID", c.MealID },
        { "RecipeID", c.RecipeID },
      };
            return await base.InsertAsync(fill);
        }


        public async Task<List<MealRecipe>> GetByMealAsync(int MealId)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>()
            {
                { "MealID", MealId }
            };
            return (List<MealRecipe>)await SelectAllAsync(filter);
        }

        public async Task<int> DeleteByMealAsync(int MealId)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>()
            {
                { "MealID", MealId }
            };
            return await base.DeleteAsync(filter);
        }

        public async Task<int> DeleteRecipeFromMealAsync(int mealID, int recipeID)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>()
    {
        { "MealID", mealID },
        { "RecipeID", recipeID }
    };
            return await base.DeleteAsync(filter);
        }


    }
}
