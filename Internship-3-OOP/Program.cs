using Internship_3_OOP.Classes;

namespace Internship_3_OOP
{
    internal class Program
    {
        public static List<Passenger> AllPassengers = new();
        public static List<Flight> AllFlights = new();
        static void Main(string[] args)
        {
            var Passenger1 = new Passenger(
                firstName: "Ana",
                lastName: "Horvat",
                yearOfBirth: 1995,
                email: "ana.horvat@example.com",
                password: "Password1"
            );            
            AllPassengers.Add(Passenger1);
           
            ShowStartingMenu();
            
        }

        static void ShowStartingMenu() {
            while (true) {
                Console.Clear();
                Console.WriteLine("GLAVNI IZBORNIK\n1 - Putnici\n2 - Letovi\n3 - Avioni\n4 - Posada\n5 - Izlazak iz programa");
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            ShowPassengerMenu();
                            break;
                        case 2:
                            ShowFlightMenu();
                            break;
                        case 3:
                            
                            break;
                        case 4:

                            break;
                        case 5:
                            Console.WriteLine("Izlazak iz aplikacije...");
                            break;
                        default:
                            Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                            Console.ReadKey();
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                    Console.ReadKey();
                    continue;
                }

            }
        
        
        }
        static void ShowPassengerMenu() {
            while (true)
            {

                Console.Clear();
                Console.WriteLine("PUTNICI IZBORNIK\n1 - Registracija\n2 - Prijava\n3 - Povratak na prethodni izbornik");
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:

                            RegisterPassenger();
                            break;
                        case 2:
                            LoginPassenger();
                            break;
                        case 3:

                            return;
                        default:
                            Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                            Console.ReadKey();
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                    Console.ReadKey();
                    continue;
                }
            }
        }
        static void ShowPassengerFlightsMenu() {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("LETOVI PUTNIKA\n1 - Prikaz svih letova\n2 - ODabir leta\n3 - Pretraživanje letova\n4 - Otkazivanje leta\n5 - Povratak na prethodni izbornik");
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                           
                            break;
                        case 2:

                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:
                            return;
                        default:
                            Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                            Console.ReadKey();
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                    Console.ReadKey();
                    continue;
                }

            }


        }
        static void ShowFlightMenu()
        {
            while (true) {
                Console.Clear();
                Console.WriteLine("IZBORNIK LETOVA\n1 - Prikaz svih letova\n2 - Dodavanje leta\n3 - Pretraživanje letova\n4 - Uređivanje leta\n5 - Brisanje leta\n6 - Povratak na prethodni izbornik");
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            PrintAllFlights();
                            break;
                        case 2:
                            AddFlight();
                            break;
                        case 3:

                            break;
                        case 4:

                            break;
                        case 5:
                            break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                            Console.ReadKey();
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                    Console.ReadKey();
                    continue;
                }
            }
        }
        static void RegisterPassenger()
        {
            Console.Clear();
            Console.WriteLine("REGISTRACIJA PUTNIKA\n");

            string firstName = InputValidator.ReadString("Unesite ime: ");
            string lastName = InputValidator.ReadString("Unesite prezime: ");
            int yearOfBirth = InputValidator.ReadYear("Unesite godinu rođenja: ");
            string email = InputValidator.ReadEmail("Unesite email: ");
            string password = InputValidator.ReadPassword("Unesite zaporku: ");

            var person = new Passenger(firstName, lastName, yearOfBirth, email, password);           
            AllPassengers.Add(person);
        }
        static void LoginPassenger() {
            Console.Clear();
            Console.WriteLine("PRIJAVA PUTNIKA\n");
            string email = InputValidator.ReadEmail("Unesite email: ");
            string password = InputValidator.ReadPassword("Unesite zaporku: ");
            int passengerIndex = AllPassengers.FindIndex(p => p.Email == email );
            
            if(passengerIndex != -1 && AllPassengers[passengerIndex].VerifyPassword(password) )
            {
                var currentPassenger = AllPassengers[passengerIndex];
                Console.WriteLine("Uspješna prijava!");
                Console.ReadLine();
                ShowPassengerFlightsMenu();
            }
            else
            {
                Console.WriteLine("Neuspješna prijava, pokušajte ponovo.");
                Console.ReadLine();
                return;
            }
        }
        static void PrintAllFlights()
        {
            Console.Clear();
            Console.WriteLine("PRIKAZ SVIH LETOVA\n");

            foreach (var flight in AllFlights)            
                Console.WriteLine($"ID:{flight.Id.ToString().Substring(0, 8)} - Naziv:{flight.FlightName} - Polazak:{flight.DepartureTime} - Dolazak:{flight.ArrivalTime} - Udaljenost:{flight.Distance}km - Trajanje:{flight.FlightDuration}min");
            
            Console.WriteLine("\nPritisnite bilo koju tipku za povratak na izbornik...");
            Console.ReadKey();
            return;

        }
        static void AddFlight()
        {
            Console.Clear();
            Console.WriteLine("DODAVANJE NOVOG LETA\n");
            string origin = InputValidator.ReadString("Unesite polazište: ");
            string destination = InputValidator.ReadString("Unesite odredište: ");
            DateTime departureTime = InputValidator.ReadDateTime("Unesite vrijeme polaska (yyyy-MM-dd HH:mm): ");
            DateTime arrivalTime = InputValidator.ReadDateTime("Unesite vrijeme dolaska (yyyy-MM-dd HH:mm): ");
            int capacity = InputValidator.ReadInt("Unesite kapacitet leta: ");
            double distance = InputValidator.ReadDouble("Unesite udaljenost leta (u km): ");
            var flight = new Flight(origin, destination, departureTime, arrivalTime, capacity, distance);

            if (InputValidator.ConfirmAction("Jeste li sigurni da želite unijeti let?"))
            {
                AllFlights.Add(flight);
                Console.WriteLine("Let je uspješno dodan.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Dodavanje leta je otkazano.");
                Console.ReadKey();
                return;
            }
        }
    }
}
