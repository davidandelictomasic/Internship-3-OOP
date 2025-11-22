namespace Internship_3_OOP.Classes
{
    internal class Flight : EntityBase
    {
        public string FlightName { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int Capacity { get; set; }
        public int FlightDuration { get; set; }
        public double Distance { get; set; }
        public Aircraft FlightAircraft { get; set; }
        public Crew FlightCrew { get; set; }

        private List<Guid> ReservedPassengerIds = new();
        public Dictionary<SeatCategories, int> ReservedSeatsByCategory { get; set; }

        public IReadOnlyList<Guid> GetReservedPassengerIds()
        {
            return ReservedPassengerIds.AsReadOnly();
        }
        public Flight(string origin, string destination, DateTime departureTime, DateTime arrivalTime, int capacity, double distance,Aircraft aircraft,Crew crew)
        {
            FlightName = $"{origin}-{destination}";
            Origin = origin;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Capacity = capacity;
            FlightDuration = (int)(ArrivalTime - DepartureTime).TotalMinutes;            
            Distance = distance;
            FlightAircraft = aircraft;
            FlightCrew = crew;
            ReservedSeatsByCategory = new Dictionary<SeatCategories, int>();

            for (int i = 0; i < aircraft.AircraftSeatCategories.Count; i++)
            {
                var cat = aircraft.AircraftSeatCategories[i];
                ReservedSeatsByCategory[cat] = 0; 
            }


        }

        public bool AddPassenger(Guid passengerId)
        {
            if (!ReservedPassengerIds.Contains(passengerId))
            {
                ReservedPassengerIds.Add(passengerId);
                UpdateTimestamp(); 
                return true;
            }
            return false;
        }

        public bool RemovePassenger(Guid passengerId)
        {
            if (ReservedPassengerIds.Remove(passengerId))
            {
                UpdateTimestamp(); 
                return true;
            }
            return false;
        }

        public bool IsFull()
        {
            return ReservedPassengerIds.Count >= Capacity;
        }

        
        public void PrintInfo()
        {
            Console.WriteLine($"ID:{Id.ToString().Substring(0, 8)} - Naziv:{FlightName} - Polazak:{DepartureTime} - Dolazak:{ArrivalTime} - Udaljenost:{Distance}km - Trajanje:{FlightDuration}min");

        }
        public bool HasCategory(SeatCategories category)
        {
            return FlightAircraft.AircraftSeatCategories.Contains(category);
        }

        public bool HasFreeSeatInCategory(SeatCategories category)
        {
            int index = FlightAircraft.AircraftSeatCategories.IndexOf(category);
            if (index == -1)
                return false;

            int totalSeats = FlightAircraft.SeatCategoriesAvailability[index];
            int reservedSeats = ReservedSeatsByCategory[category];

            return reservedSeats < totalSeats;
        }
        

    }
}
