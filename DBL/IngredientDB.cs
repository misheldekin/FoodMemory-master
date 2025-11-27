using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DBL
{
    public class IngredientDB : BaseDB<Ingredient>
    {
        protected override string GetTableName()
        {
            return "ingredients";
        }

        protected override string GetPrimaryKeyName()
        {
            return "idIngredients";
        }

        protected override async Task<Ingredient> CreateModelAsync(object[] row)
        {
            Ingredient ingredient = new Ingredient();
            ingredient.IngredientID = int.Parse(row[0].ToString());
            ingredient.IngredientName = row[1].ToString();
            return ingredient;
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return ((List<Ingredient>)await SelectAllAsync());
        }

        public async Task<Ingredient> InsertGetObjAsync(Ingredient ingredient)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>()
            {
                { "name", ingredient.IngredientName }
            };
            return (Ingredient)await base.InsertGetObjAsync(fillValues);
        }

        public async Task<List<Ingredient>> SearchIngredientsByNameAsync(string searchTerm)
        {
            string sql = "SELECT * FROM ingredients WHERE name LIKE @searchTerm";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("searchTerm", $"%{searchTerm}%"); 
            return (List<Ingredient>)await SelectAllAsync(sql, parameters);
        }
        public async Task<Ingredient> SelectByPkAsync(int id)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("idIngredients", id);
            List<Ingredient> list = (List<Ingredient>)await SelectAllAsync(p);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

    }
}
