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
        public void PrintSortedFlightInfo(string sortType, string sortBy, List<Flight> AllFlights)
        {
            var sortedFlights = GetReservedFlightIds().Select(id => AllFlights.Find(f => f.Id == id)).Where(f => f != null).ToList();

            switch (sortBy.ToLower())
            {
                case "polazak":
                    if (sortType == "ASC")
                    {
                        sortedFlights = sortedFlights.OrderBy(f => f.DepartureTime).ToList();
                        break;
                    }
                    sortedFlights = sortedFlights.OrderByDescending(f => f.DepartureTime).ToList();
                    break;

                case "trajanje":
                    if (sortType == "ASC")
                    {
                        sortedFlights = sortedFlights.OrderBy(f => f.FlightDuration).ToList();
                        break;
                    }
                    sortedFlights = sortedFlights.OrderByDescending(f => f.FlightDuration).ToList();
                    break;

                case "udaljenost":
                    if (sortType == "ASC")
                    {
                        sortedFlights = sortedFlights.OrderBy(f => f.Distance).ToList();
                        break;
                    }
                    sortedFlights = sortedFlights.OrderByDescending(f => f.Distance).ToList();
                    break;

                case "naziv":
                    sortedFlights = sortedFlights.OrderBy(f => f.FlightName).ToList();
                    break;

                default:
                    return;
            }

            foreach (var flight in sortedFlights)
                flight.PrintInfo();
        }

    }
}
