namespace Internship_3_OOP.Classes
{
    internal class Passenger : Person
    {
        public string Email { get; set; }

        private string Password { get; set; }

        public Passenger(string firstName, string lastName, int yearOfBirth, string email, string password)
            : base(firstName, lastName, yearOfBirth)
        {
            Email = email;
            Password = password;
        }

        public bool VerifyPassword(string password)
        {
            return Password == password;
        }   
    }
}
