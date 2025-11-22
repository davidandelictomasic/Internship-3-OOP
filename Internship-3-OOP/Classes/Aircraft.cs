namespace Internship_3_OOP.Classes
{
    internal class Aircraft : EntityBase
    {
        public string Name { get; set; }
        public int YearOfProduction {  get; set; }
        public List<SeatCategories> AircraftSeatCategories { get; set; }
        public List<int> SeatCategoriesAvailability { get; set; }

        public Aircraft(string name, int yearOfProduction, List<SeatCategories> aircraftSeatCategories, List<int> seatCategoriesAvailability)
        {
            Name = name;
            YearOfProduction = yearOfProduction;
            AircraftSeatCategories = aircraftSeatCategories;
            SeatCategoriesAvailability = seatCategoriesAvailability;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"ID:{Id.ToString().Substring(0, 8)} - Naziv:{Name} - Godina proizvodnje:{YearOfProduction} - Kategorije sjedala:{string.Join(", ", AircraftSeatCategories)}");

        }

    }
}
