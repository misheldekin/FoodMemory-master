using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DBL
{
    public class RecipeDB : BaseDB<Recipes>
    {
        protected override string GetTableName()
        {
            return "recipes";
        }

        protected override string GetPrimaryKeyName()
        {
            return "idRecipes";
        }

        protected override async Task<Recipes> CreateModelAsync(object[] row)
        {
            Recipes recipe = new Recipes();
            recipe.RecipeID = int.Parse(row[0].ToString());
            recipe.UserID = int.Parse(row[1].ToString());
            recipe.Name = row[2].ToString();
            recipe.RecipeInstructions = row[3].ToString();
            recipe.Story = row[4].ToString();
            recipe.ImageURL = row[5].ToString();
            return recipe;
        }

        public async Task<List<Recipes>> GetAllAsync()
        {
            return ((List<Recipes>)await SelectAllAsync());
        }

        public async Task<Recipes> InsertGetObjAsync(Recipes recipe)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>()
            {
                { "user_ID", recipe.UserID },  
                { "name", recipe.Name },
                { "preparation_steps", recipe.RecipeInstructions },
                { "story", recipe.Story },
                { "image_url", recipe.ImageURL }
            };
            return (Recipes)await base.InsertGetObjAsync(fillValues);
        }

        public async Task<int> UpdateAsync(Recipes recipe)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("user_ID", recipe.UserID);  
            fillValues.Add("name", recipe.Name);
            fillValues.Add("preparation_steps", recipe.RecipeInstructions);
            fillValues.Add("story", recipe.Story);
            fillValues.Add("image_url", recipe.ImageURL);
            filterValues.Add("idRecipes", recipe.RecipeID);
            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<Recipes> SelectByPkAsync(int recipeId)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("idRecipes", recipeId);
            List<Recipes> list = (List<Recipes>)await SelectAllAsync(p);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

        public async Task<List<Recipes>> GetRecipesByUserAsync(int userId)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("user_ID", userId);  
            return (List<Recipes>)await SelectAllAsync(p);
        }

        public async Task<List<Recipes>> SearchRecipesByNameAsync(string searchTerm)
        {
            string sql = "SELECT * FROM recipes WHERE name LIKE @searchTerm";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("searchTerm", $"%{searchTerm}%");
            return (List<Recipes>)await SelectAllAsync(sql, parameters);
        }

        public async Task<int> UpdateNameAsync(int recipeId, string name)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("name", name);
            filterValues.Add("idRecipes", recipeId);
            return await base.UpdateAsync(fillValues, filterValues);
        }
    }
}
