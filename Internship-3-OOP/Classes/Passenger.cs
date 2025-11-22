namespace Internship_3_OOP.Classes
{
    internal class Passenger : Person
    {
        public string Email { get; set; }

        private string Password { get; set; }

        private List<Guid> ReservedFlightIds = new();

        private List<Flight> FavouriteFlights = new();

        public IReadOnlyList<Guid> GetReservedFlightIds()
        {
            return ReservedFlightIds.AsReadOnly();
        }

        public Passenger(string firstName, string lastName, int yearOfBirth, string email, string password)
            : base(firstName, lastName, yearOfBirth)
        {
            Email = email;
            Password = password;
            FavouriteFlights = new List<Flight>();
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
                UpdateTimestamp();
                return true;
            }
            return false;
        }
        public void RemoveReservedFlight(Guid flightId)
        {
            ReservedFlightIds.Remove(flightId);
            UpdateTimestamp();
        }
        public bool AddFavouriteFlight(Flight flight)
        {
                if (FavouriteFlights.Contains(flight))
                    return false;

                FavouriteFlights.Add(flight);
                UpdateTimestamp();
                return true;

        }
        public void PrintFavouriteFlightInfo()
        {
            if(FavouriteFlights.Count == 0)
            {
                Console.WriteLine("Ne postoji ni jedan favorit");                
                return;
            }
            foreach(var flight in FavouriteFlights)
            {
                flight.PrintInfo();
            }
        }
    }
}
