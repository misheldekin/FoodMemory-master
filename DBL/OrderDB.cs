using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DBL
{
    public class OrderDB : BaseDB<Order>
    {
        protected override string GetTableName()
        {
            return "orders";
        }

        protected override string GetPrimaryKeyName()
        {
            return "idOrders";
        }

        protected override async Task<Order> CreateModelAsync(object[] row)
        {
            Order order = new Order();
            order.OrderID = int.Parse(row[0].ToString());
            order.CustomerID = int.Parse(row[1].ToString());
            order.ChefID = int.Parse(row[2].ToString());
            order.MealID = int.Parse(row[3].ToString());
            order.OrderDate = DateTime.Parse(row[4].ToString());
            order.DeliveryDate = DateTime.Parse(row[5].ToString());
            order.Status = row[6].ToString();
            order.DeliveryAddress = row[7].ToString();
            return order;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return (List<Order>)await SelectAllAsync();
        }

        public async Task<Order> InsertGetObjAsync(Order order)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>()
            {
                { "customer_id", order.CustomerID },
                { "chef_id", order.ChefID },
                { "meal_id", order.MealID },
                { "order_date", order.OrderDate },
                { "delivery_date", order.DeliveryDate },
                { "status", order.Status },
                { "address", order.DeliveryAddress },
            };
            return (Order)await base.InsertGetObjAsync(fillValues);
        }

        public async Task<int> UpdateAsync(Order order)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("customer_id", order.CustomerID);
            fillValues.Add("chef_id", order.ChefID);
            fillValues.Add("meal_id", order.MealID);
            fillValues.Add("order_date", order.OrderDate);
            fillValues.Add("delivery_date", order.DeliveryDate);
            fillValues.Add("status", order.Status);
            fillValues.Add("address", order.DeliveryAddress);
            filterValues.Add("idOrders", order.OrderID);
            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<List<Order>> GetOrdersByChefAsync(int chefId)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>()
            {
                { "chef_id", chefId }
            };
            return (List<Order>)await SelectAllAsync(filter);
        }

        public async Task<List<Order>> GetOrdersByCustomerAsync(int customerId)
        {
            Dictionary<string, object> filter = new Dictionary<string, object>()
    {
        { "customer_id", customerId }
    };
            return (List<Order>)await SelectAllAsync(filter);
        }


        public async Task<Order> SelectByPkAsync(int orderId)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            p.Add("idOrders", orderId);
            List<Order> list = (List<Order>)await SelectAllAsync(p);
            if (list.Count == 1)
                return list[0];
            else
                return null;
        }

        public async Task<int> UpdateStatusAsync(int orderId, string status)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            fillValues.Add("status", status);
            filterValues.Add("idOrders", orderId);
            return await base.UpdateAsync(fillValues, filterValues);
        }

        public async Task<int> DeleteAsync(int orderId)
        {
            Dictionary<string, object> filterValues = new Dictionary<string, object>();
            filterValues.Add("idOrders", orderId);
            return await base.DeleteAsync(filterValues);
        }

        public async Task<int> MarkAsRatedAsync(int orderId)
        {
            Dictionary<string, object> fillValues = new Dictionary<string, object>();
            Dictionary<string, object> filterValues = new Dictionary<string, object>();

            fillValues.Add("isRated", 1);
            filterValues.Add("order_id", orderId);

            return await base.UpdateAsync(fillValues, filterValues);
        }
    }
}
