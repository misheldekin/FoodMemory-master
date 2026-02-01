using System;

namespace Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ChefID { get; set; }
        public int MealID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveryAddress { get; set; }
        public string Status { get; set; } // "Pending", "Approved", "Rejected", "Completed"
        public string CustomerName { get; set; }
        public string MealName { get; set; }

        public Order() { }

        public Order(int orderID, int customerID, int chefID, int mealID,
                    DateTime orderDate, DateTime deliveryDate, string deliveryAddress,
                    string status)
        {
            this.OrderID = orderID;
            this.CustomerID = customerID;
            this.ChefID = chefID;
            this.MealID = mealID;
            this.OrderDate = orderDate;
            this.DeliveryDate = deliveryDate;
            this.DeliveryAddress = deliveryAddress;
            this.Status = status;
        }
    }
}