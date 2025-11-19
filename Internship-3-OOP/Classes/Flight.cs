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

        private List<Guid> ReservedPassengerIds = new();
        public IReadOnlyList<Guid> GetReservedPassengerIds()
        {
            return ReservedPassengerIds.AsReadOnly();
        }
        public Flight(string origin, string destination, DateTime departureTime, DateTime arrivalTime, int capacity, double distance)
        {
            FlightName = $"{origin}-{destination}";
            Origin = origin;
            Destination = destination;
            DepartureTime = departureTime;
            ArrivalTime = arrivalTime;
            Capacity = capacity;
            FlightDuration = (int)(ArrivalTime - DepartureTime).TotalMinutes;            
            Distance = distance;

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


    }
}
