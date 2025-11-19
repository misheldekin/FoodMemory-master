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
    public class CustomerDB : BaseDB<Customers>
    {
        protected override string GetTableName()
        {
            return "users";
        }

        protected override string GetPrimaryKeyName()
        {
            return "idUsers";
        }

        protected override async Task<Customers> CreateModelAsync(object[] row)
        {
            Customers c = new Customers();
            c.CustomerID = int.Parse(row[0].ToString());
            c.Name = row[1].ToString();
            c.LastName = row[2].ToString();
            c.Email = row[3].ToString();
            c.Password = row[4].ToString();
            c.IsAdmin = int.Parse(row[5].ToString());
            c.ProfileImage = row[6].ToString();
            return c;
        }

        public async Task<List<Customers>> GetAllAsync()
        {
            return ((List<Customers>)await SelectAllAsync());
        }

        public async Task<Customers> InsertGetObjAsync(Customers customer)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>()
            {
                { "firstname", customer.Name },
                { "lastname", customer.LastName },
                { "email", customer.Email },
                { "password", customer.Password },
                { "IsAdmin" , customer.IsAdmin },
                { "profilepic", customer.ProfileImage }
            };
            return (Customers)await base.InsertGetObjAsync(fillValues);
        }
        


        public async Task<int> UpdateAsync(Customers customer)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("firstname", customer.Name);
            fillValues.Add("lastname", customer.LastName);
            fillValues.Add("email", customer.Email);
            fillValues.Add("password", customer.Password);
            fillValues.Add("profilepic", customer.ProfileImage);
            filterValues.Add("idUsers", customer.CustomerID.ToString());
            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<Customers> LoginAsync(string email, string password)
        {
            string sql = @"SELECT * FROM foodmemory.users WHERE email=@email;";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("email", email);
            List<Customers> users = (List<Customers>)await SelectAllAsync(sql, parameters);
            if (users.Count == 1)
            {
                Customers user = users[0];
                if (user.Password == password)
                {
                    return user;
                }
            }
            return null;
        }
        public async Task<Customers> SelectByPkAsync(int id)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("idUsers", id);
            List<Customers> list = (List<Customers>)await SelectAllAsync(p);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

        public async Task<int> UpdateFirstNameAsync(int customerId, string firstName)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("firstname", firstName);
            filterValues.Add("idUsers", customerId.ToString());
            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<int> UpdateLastNameAsync(int customerId, string lastName)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("lastname", lastName);
            filterValues.Add("idUsers", customerId.ToString());
            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<int> UpdateEmailAsync(int customerId, string email)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("email", email);
            filterValues.Add("idUsers", customerId.ToString());
            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<int> UpdatePasswordAsync(int customerId, string password)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("password", password);
            filterValues.Add("idUsers", customerId.ToString());
            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<int> UpdateProfileImageAsync(int customerId, string profileImage)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("profilepic", profileImage);
            filterValues.Add("idUsers", customerId.ToString());
            return await base.UpdateAsync(fillValues, filterValues);
        }

    }
}
