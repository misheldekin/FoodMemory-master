using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using Models;
namespace DBL
{
    public class RecipeIngredientDB : BaseDB<RecipeIngredient>
    {
        protected override string GetTableName()
        {
            return "recipe_ingredients";
        }

        protected override string GetPrimaryKeyName()
        {
            return "recipe_ingredientsID";
        }

        protected override async Task<RecipeIngredient> CreateModelAsync(object[] row)
        {
            RecipeIngredient ri = new RecipeIngredient();
            ri.RecipeID = int.Parse(row[0].ToString());
            ri.IngredientID = int.Parse(row[1].ToString());
            ri.Quantity = double.Parse(row[2].ToString());
            ri.Size = row[3].ToString();
            return ri;
        }

        public async Task<int> InsertAsync(RecipeIngredient c)
        {
            Dictionary<string, object> fill = new Dictionary<string, object>()
      {
        { "recipe_id", c.RecipeID },
        { "ingredient_id", c.IngredientID },
        { "quantity", c.Quantity },
        { "size", c.Size }
      };
            return await base.InsertAsync(fill);
        }


        public async Task<List<RecipeIngredient>> GetByRecipeAsync(int recipeId)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>()
            {
                { "recipe_id", recipeId }
            };
            return (List<RecipeIngredient>)await SelectAllAsync(filter);
        }
        public async Task<int> DeleteByRecipeAsync(int recipeId)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>()
            {
                { "recipe_id", recipeId }
            };
            return await base.DeleteAsync(filter);
        }

    }
}

