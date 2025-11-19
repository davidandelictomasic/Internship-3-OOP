namespace Internship_3_OOP.Classes
{
    internal class Passenger : Person
    {
        public string Email { get; set; }

        private string Password { get; set; }

        private List<Guid> ReservedFlightIds = new();

        public IReadOnlyList<Guid> GetReservedFlightIds()
        {
            return ReservedFlightIds.AsReadOnly();
        }

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
        public bool AddReservedFlight(Guid flightId)
        {
            if (!ReservedFlightIds.Contains(flightId))
            {
                ReservedFlightIds.Add(flightId);
                return true;
            }
            return false;
        }
        public void RemoveReservedFlight(Guid flightId)
        {
            ReservedFlightIds.Remove(flightId);
        }
    }
}
