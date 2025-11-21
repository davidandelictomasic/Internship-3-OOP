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
            Console.WriteLine($"ID:{Id}");
           
            for (int i = 0; i < 4; i++)
            {
                string jobPosition = "pilot";
                switch (Employees[i].Position)
                {                    
                    case JobPosition.CoPilot:
                        jobPosition = "kopilot";
                        break;
                    case JobPosition.FlightAttendant:
                        jobPosition = Employees[i].Gender == "M" ? "stjuard" : "stjuardesa" ;
                        break;
                    default:
                        break;
                }

               Console.WriteLine($"Ime: {Employees[i].FirstName} - Prezime: {Employees[i].LastName} - Spol: {Employees[i].Gender} - Pozicija: {jobPosition}");
                
            }
        }

    }
}
