namespace Internship_3_OOP.Classes
{
    internal class Crew : EntityBase
    {
        public List<Employee> Employees { get; set; } = new(4);
        public Crew(List<Employee> employees)
        {
            Employees = employees;
        }

        public void PrintCrewInfo()
        {
            Console.Write($"\nID:{Id}");
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Ime: {Employees[0].FirstName} - Prezime: {Employees[0].LastName} - Spol: {Employees[0].FirstName} - Pozicija: {Employees[0].Position}");
                
            }
        }

    }
}
