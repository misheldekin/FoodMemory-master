using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DBL
{
    public class ChefDB : BaseDB<Chef>
    {
        protected override string GetTableName()
        {
            return "chefs";
        }

        protected override string GetPrimaryKeyName()
        {
            return "chef_id";
        }

        protected override async Task<Chef> CreateModelAsync(object[] row)
        {
            Chef chef = new Chef();
            chef.ChefID = int.Parse(row[0].ToString());
            chef.FirstName = row[1].ToString();
            chef.LastName = row[2].ToString();
            chef.Email = row[3].ToString();
            chef.Password = row[4].ToString();
            chef.PhoneNumber = row[5].ToString();
            chef.YearsOfExperience = int.Parse(row[6].ToString());
            chef.Bio = row[7].ToString();
            chef.Rating = double.Parse(row[8].ToString());
            chef.ProfileImage = row[9].ToString();
            return chef;
        }

        public async Task<List<Chef>> GetAllAsync()
        {
            return (List<Chef>)await SelectAllAsync();
        }

        public async Task<Chef> InsertGetObjAsync(Chef chef)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>()
            {
                { "fullName", chef.FirstName },
                { "lastName", chef.LastName },
                { "email", chef.Email },
                { "password", chef.Password },
                { "phoneNumber", chef.PhoneNumber },
                { "experienceYears", chef.YearsOfExperience },
                { "bio", chef.Bio },
                { "rating", chef.Rating },
                { "ProfilePic", chef.ProfileImage }
            };
            return (Chef)await base.InsertGetObjAsync(fillValues);
        }

        public async Task<int> UpdateAsync(Chef chef)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("fullName", chef.FirstName);
            fillValues.Add("lastName", chef.LastName);
            fillValues.Add("email", chef.Email);
            fillValues.Add("password", chef.Password);
            fillValues.Add("phoneNumber", chef.PhoneNumber);
            fillValues.Add("experienceYears", chef.YearsOfExperience);
            fillValues.Add("bio", chef.Bio);
            fillValues.Add("ProfilePic", chef.ProfileImage);
            filterValues.Add("chef_id", chef.ChefID);
            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<Chef> LoginAsync(string email, string password)
        {
            string sql = @"SELECT * FROM foodmemory.chefs WHERE email=@email;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("email", email);
            List<Chef> chefs = (List<Chef>)await SelectAllAsync(sql, parameters);
            if (chefs.Count == 1)
            {
                Chef chef = chefs[0];
                if (chef.Password == password)
                {
                    return chef;
                }
            }
            return null;
        }

        public async Task<Chef> SelectByPkAsync(int id)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("chef_id", id);
            List<Chef> list = (List<Chef>)await SelectAllAsync(p);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }
    }
}