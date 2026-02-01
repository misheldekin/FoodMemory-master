namespace Models
{
    public class Chef
    {
        public int ChefID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int YearsOfExperience { get; set; }
        public string Bio { get; set; }
        public double Rating { get; set; }
        public string ProfileImage { get; set; }

        public Chef() { }

        public Chef(int chefID, string firstName, string lastName, string email,
                   string password, string phoneNumber, int yearsOfExperience,
                   string bio, double rating, string profileImage)
        {
            this.ChefID = chefID;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.PhoneNumber = phoneNumber;
            this.YearsOfExperience = yearsOfExperience;
            this.Bio = bio;
            this.Rating = rating;
            this.ProfileImage = profileImage;
        }
    }
}
