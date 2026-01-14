using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Meals
    {
        public int mealID;
        public int userID;
        public string name;

        public Meals() { }
        public Meals(int mealID, int userID, string name)
        {
            this.mealID = mealID;
            this.userID = userID;
            this.name = name;
        }
    }
}
