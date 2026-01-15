using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DBL
{
    public class MealsDB : BaseDB<Meals>
    {
        protected override string GetTableName()
        {
            return "meals";
        }

        protected override string GetPrimaryKeyName()
        {
            return "idMeals";
        }
        protected override async Task<Meals> CreateModelAsync(object[] row)
        {
            Meals meal = new Meals();
            meal.mealID = int.Parse(row[0].ToString());
            meal.userID = int.Parse(row[1].ToString());
            meal.name = row[2].ToString();
            return meal;
        }

        public async Task<List<Meals>> GetAllAsync()
        {
            return ((List<Meals>)await SelectAllAsync());
        }
        public async Task<Meals> InsertGetObjAsync(Meals meal)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>()
         {
        { "user_id", meal.userID },
        { "name", meal.name }
         };
            return (Meals)await base.InsertGetObjAsync(fillValues);
        }

        public async Task<int> UpdateAsync(Meals meal)
        {
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            Dictionary<string, object> fillValues = new Dictionary<string, object>()
    {
        { "user_id", meal.userID }, 
        { "name", meal.name }
    };
            return await base.UpdateAsync(fillValues, filterValues);

        }

        public async Task<Meals> SelectByPkAsync(int MealID)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("idMeals", MealID);
            List<Meals> list = (List<Meals>)await SelectAllAsync(p);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

        public async Task<List<Meals>> GetRecipesByUserAsync(int userId)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("user_id", userId);
            return (List<Meals>)await SelectAllAsync(p);
        }

        public async Task<int> UpdateNameAsync(int MealId, string name)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("name", name);
            filterValues.Add("idMeals", MealId);
            return await base.UpdateAsync(fillValues, filterValues);
        }
    }
}
