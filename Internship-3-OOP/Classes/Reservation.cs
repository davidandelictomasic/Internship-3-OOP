namespace Internship_3_OOP.Classes
{
    internal class Reservation : EntityBase
    {
        public Guid PassengerId { get; set; }
        public Guid FlightId { get; set; }

        public SeatCategories SeatCategory { get; set; }

        public Reservation(Guid passengerId, Guid flightId, SeatCategories category)
        {
            PassengerId = passengerId;
            FlightId = flightId;
            SeatCategory = category;
        }
    }
}
