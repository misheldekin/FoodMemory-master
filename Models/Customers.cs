namespace Models
{
    public class Customers
    {
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IsAdmin { get; set; }
        public string ProfileImage { get; set; }
        public Customers() { }
        public Customers(int customerID, string Name, string LastName, string Email, string Password, string ProfileImage)
        {
            this.CustomerID = customerID;
            this.Name = Name;
            this.LastName = LastName;
            this.Email = Email;
            this.Password = Password;
            this.ProfileImage = ProfileImage;
        }


    }
}
