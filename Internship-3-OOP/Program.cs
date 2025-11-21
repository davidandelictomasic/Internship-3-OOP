using System;
using System.Net.NetworkInformation;
using Internship_3_OOP.Classes;

namespace Internship_3_OOP
{
    internal class Program
    {
        public static List<Passenger> AllPassengers = new();
        public static List<Flight> AllFlights = new();
        public static List<Reservation> AllReservations = new();
        public static List<Aircraft> AllAircrafts = new();
        public static List<Employee> AllEmployees = new();
        public static List<Crew> AllCrews = new();
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
            var Flight1 = new Flight(
                origin: "ZAG",
                destination: "LHR",
                departureTime: DateTime.Today.AddHours(500),
                arrivalTime: DateTime.Today.AddHours(504),
                capacity: 180,
                distance: 1500.0
            );            
            AllFlights.Add(Flight1);
            var Aircraft1 = new Aircraft(
                name: "Boeing 737",
                yearOfProduction: 2010,
                aircraftSeatCategories: new List<SeatCategories> { SeatCategories.Standard, SeatCategories.Business },
                seatCategoriesAvailability: new List<int> { 150, 30 }
            );
            

            ShowStartingMenu();

        }

        static void ShowStartingMenu()
        {
            while (true)
            {
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
                            ShowAircraftMenu();
                            break;
                        case 4:
                            ShowCrewMenu();
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
        static void ShowPassengerMenu()
        {
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
        static void ShowPassengerFlightsMenu(Passenger currentPassenger)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("LETOVI PUTNIKA\n1 - Prikaz svih letova\n2 - Odabir leta\n3 - Pretraživanje letova\n4 - Otkazivanje leta\n5 - Povratak na prethodni izbornik");
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            PrintPassengerFlights(currentPassenger);
                            break;
                        case 2:
                            AddPassengerFlight(currentPassenger);
                            break;
                        case 3:
                            SearchPassengerFlight(currentPassenger);
                            break;
                        case 4:
                            CancelPassengerFlight(currentPassenger);
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
            while (true)
            {
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
                            SearchFlight();
                            break;
                        case 4:
                            UpdateFlightInfo();
                            break;
                        case 5:
                            DeleteFlight();
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
        static void ShowAircraftMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("IZBORNIK AVIONA\n1 - Prikaz svih aviona\n2 - Dodavanje aviona\n3 - Pretraživanje aviona\n4 - Brisanje aviona\n5 - Povratak na prethodni izbornik");
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            PrintAllAircrafts();
                            break;
                        case 2:
                            AddAircraft();
                            break;
                        case 3:
                            SearchAircraft();
                            break;
                        case 4:
                            DeleteAircraft();
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
        static void ShowCrewMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("IZBORNIK POSADE\n1 - Prikaz svih posada\n2 - Dodavanje nove posade\n3 - Dodavanja zaposlenika\n4 - Povratak na prethodni izbornik");
                Console.Write("Odabir: ");

                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            PrintAllCrews();
                            break;
                        case 2:
                            AddCrew();
                            break;
                        case 3:
                            AddEmployee();
                            break;                        
                        case 4:
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
        static void LoginPassenger()
        {
            Console.Clear();
            Console.WriteLine("PRIJAVA PUTNIKA\n");
            string email = InputValidator.ReadEmail("Unesite email: ");
            string password = InputValidator.ReadPassword("Unesite zaporku: ");
            int passengerIndex = AllPassengers.FindIndex(p => p.Email == email);

            if (passengerIndex != -1 && AllPassengers[passengerIndex].VerifyPassword(password))
            {
                var currentPassenger = AllPassengers[passengerIndex];
                Console.WriteLine("Uspješna prijava!");
                Console.ReadLine();
                ShowPassengerFlightsMenu(currentPassenger);
            }
            else
            {
                Console.WriteLine("Neuspješna prijava, pokušajte ponovo.");
                Console.ReadLine();
                return;
            }
        }
        static void PrintPassengerFlights(Passenger currentPassenger)
        {
            Console.Clear();
            Console.WriteLine("PRIKAZ SVIH LETOVA PUTNIKA\n");
            if (currentPassenger.GetReservedFlightIds().Count == 0)
            {
                Console.WriteLine("Nemate rezerviranih letova.");
                Console.WriteLine("\nPritisnite bilo koju tipku za povratak na izbornik...");
                Console.ReadKey();
                return;
            }
            foreach (var flightId in currentPassenger.GetReservedFlightIds())
            {
                var flight = AllFlights.Find(flight => flight.Id == flightId);
                if (flight != null)
                {
                    Console.WriteLine($"ID:{flight.Id.ToString().Substring(0, 8)} - Naziv:{flight.FlightName} - Polazak:{flight.DepartureTime} - Dolazak:{flight.ArrivalTime} - Udaljenost:{flight.Distance}km - Trajanje:{flight.FlightDuration}min");
                }
            }
            Console.WriteLine("\nPritisnite bilo koju tipku za povratak na izbornik...");
            Console.ReadKey();
            return;
        }
        static void AddPassengerFlight(Passenger currentPassenger)
        {
            Console.Clear();
            Console.WriteLine("PRIKAZ SVIH LETOVA PUTNIKA\nLetovi:");
            foreach (var flight in AllFlights)
                Console.WriteLine($"ID:{flight.Id.ToString().Substring(0, 8)} - Naziv:{flight.FlightName} - Polazak:{flight.DepartureTime} - Dolazak:{flight.ArrivalTime} - Udaljenost:{flight.Distance}km - Trajanje:{flight.FlightDuration}min");

            var foundFlight = FindFlightById("Unesite ID leta koji želite rezervirati (prvih 8 znakova):");
            if (foundFlight != null)
            {
                Console.WriteLine("Let pronađen");
                if (foundFlight.IsFull())
                {
                    Console.WriteLine("Let je pun, nije moguće rezervirati.");
                    Console.ReadKey();
                    return;
                }
                
                var category = InputValidator.ReadSeatCategory("Odaberie kategoriju leta (standard, business, VIP): ");
                if (!InputValidator.ConfirmAction("Jeste li sigurni da želite rezervirati let?"))
                {
                    Console.WriteLine("Rezervacija leta je otkazana.");
                    Console.ReadKey();
                    return;
                }
                if (!foundFlight.AddPassenger(currentPassenger.Id))
                {
                    Console.WriteLine("Greška pri rezervaciji leta.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    if (currentPassenger.AddReservedFlight(foundFlight.Id))
                    {
                        var reservation = new Reservation(currentPassenger.Id, foundFlight.Id, category);
                        AllReservations.Add(reservation);
                        Console.WriteLine("Let uspješno rezerviran.");
                        Console.ReadKey();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Greška pri rezervaciji leta.");
                        Console.ReadKey();
                        return;
                    }
                }
            }
            else
                Console.WriteLine("Let nije pronađen.");
            Console.ReadKey();
            return;
        }
        static void SearchPassengerFlight(Passenger currentPassenger)
        {

            Console.Clear();
            Console.WriteLine("PRETRAŽIVANJE LETA\nOdaberite načina pretraživanja\n1 - ID\n2 - Naziv");

            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                switch (userChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("PRETRAGA LETA PO ID-U\nRezervirani letovi:");
                        foreach (var flightId in currentPassenger.GetReservedFlightIds())
                        {
                            var flight = AllFlights.Find(flight => flight.Id == flightId);
                            if (flight != null)
                            {
                                Console.WriteLine($"ID:{flight.Id.ToString().Substring(0, 8)}");
                            }
                        }
                        var foundFlight = FindFlightById(currentPassenger);
                        if (foundFlight != null)
                        {
                            Console.WriteLine($"ID:{foundFlight.Id.ToString().Substring(0, 8)} - Naziv:{foundFlight.FlightName} - Polazak:{foundFlight.DepartureTime} - Dolazak:{foundFlight.ArrivalTime} - Udaljenost:{foundFlight.Distance}km - Trajanje:{foundFlight.FlightDuration}min");
                            Console.WriteLine("Let upješno ispisan.");

                        }
                        else
                            Console.WriteLine("Let nije pronađen.");
                        Console.ReadKey();
                        return;


                    case 2:
                        Console.Clear();
                        Console.WriteLine("PRETRAGA LETA PO NAZIVU\nRezervirani letovi:");
                        foreach (var flightId in currentPassenger.GetReservedFlightIds())
                        {
                            var flight = AllFlights.Find(flight => flight.Id == flightId);
                            if (flight != null)
                            {
                                Console.WriteLine($"Naziv:{flight.FlightName}");
                            }
                        }

                        string flightInputName = InputValidator.ReadString("Unesite Naziv leta koji želite pronaći: ");
                        var foundFlightName = AllFlights.Find(flight => flight.FlightName == flightInputName);

                        if (foundFlightName != null)
                        {
                            Console.WriteLine($"ID:{foundFlightName.Id.ToString().Substring(0, 8)} - Naziv:{foundFlightName.FlightName} - Polazak:{foundFlightName.DepartureTime} - Dolazak:{foundFlightName.ArrivalTime} - Udaljenost:{foundFlightName.Distance}km - Trajanje:{foundFlightName.FlightDuration}min");
                            Console.WriteLine("Let upješno ispisan.");
                        }
                        else
                            Console.WriteLine("Let nije pronađen.");


                        Console.ReadKey();
                        return;

                    default:
                        Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                        Console.ReadKey();
                        return;
                }
            }
            else
            {
                Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                Console.ReadKey();
                return;
            }



        }
        static void CancelPassengerFlight(Passenger currentPassenger)
        {
            Console.Clear();
            Console.WriteLine("OTKAZIVANJE LETA");
            if (currentPassenger.GetReservedFlightIds().Count == 0)
            {
                Console.WriteLine("Nemate rezerviranih letova.");
                Console.WriteLine("\nPritisnite bilo koju tipku za povratak na izbornik...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Rezervirani letovi: ");
            foreach (var flightId in currentPassenger.GetReservedFlightIds())
            {
                var flight = AllFlights.Find(flight => flight.Id == flightId);
                if (flight != null)
                {
                    Console.WriteLine($"ID:{flight.Id.ToString().Substring(0, 8)} - Naziv:{flight.FlightName} - Polazak:{flight.DepartureTime} - Dolazak:{flight.ArrivalTime} - Udaljenost:{flight.Distance}km - Trajanje:{flight.FlightDuration}min");
                }
            }
            var foundFlight = FindFlightById(currentPassenger);
            if (foundFlight != null)
            {
                Console.WriteLine("Let pronađen");
                if ((foundFlight.DepartureTime - DateTime.Now).TotalHours > 24)
                {
                    Console.WriteLine("Let polijeće unutar 24 sata, nije moguće otkazati");
                    return;
                }
                if (!InputValidator.ConfirmAction("Jeste li sigurni da želite otkazati let?"))
                {
                    Console.WriteLine("Otkazivanje leta je otkazano.");
                    Console.ReadKey();
                    return;
                }

                if (!foundFlight.RemovePassenger(currentPassenger.Id))
                {
                    Console.WriteLine("Greška pri otkazivanju leta.");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    AllReservations.Remove(AllReservations.First(r => r.FlightId == foundFlight.Id));
                    currentPassenger.RemoveReservedFlight(foundFlight.Id);
                    Console.WriteLine("Let uspješno otkazan.");
                    Console.ReadKey();
                    return;
                }
            }
            else
                Console.WriteLine("Let nije pronađen.");
            Console.ReadKey();
            return;
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
            DateTime arrivalTime = InputValidator.ReadArrivalTime(departureTime,"Unesite vrijeme dolaska (yyyy-MM-dd HH:mm): ");
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
        static void SearchFlight()
        {
            Console.Clear();
            Console.WriteLine("PRETRAŽIVANJE LETA\nOdaberite načina pretraživanja\n1 - ID\n2 - Naziv");

            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                switch (userChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("PRETRAGA LETA PO ID-U\nSvi letovi:");
                        foreach (var flight in AllFlights)
                            Console.WriteLine($"ID:{flight.Id.ToString().Substring(0, 8)}");


                        var foundFlight = FindFlightById("Unesite ID leta koji želite pretražiti: ");
                        if (foundFlight != null) {

                            Console.WriteLine($"ID:{foundFlight.Id.ToString().Substring(0, 8)} - Naziv:{foundFlight.FlightName} - Polazak:{foundFlight.DepartureTime} - Dolazak:{foundFlight.ArrivalTime} - Udaljenost:{foundFlight.Distance}km - Trajanje:{foundFlight.FlightDuration}min");
                            Console.WriteLine("Let uspješno pronađen.");
                        }
                        else
                            Console.WriteLine("Let nije pronađen.");
                        Console.ReadKey();
                        return;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("PRETRAGA LETA PO NAZIVU\nSvi letovi:");
                        foreach (var flight in AllFlights)
                            Console.WriteLine($"Naziv:{flight.FlightName}");

                        string flightInputName = InputValidator.ReadString("Unesite Naziv leta koji želite pronaći: ");
                        var foundFlightName = AllFlights.Find(flight => flight.FlightName == flightInputName);

                        if (foundFlightName != null)
                        {
                            Console.WriteLine($"ID:{foundFlightName.Id.ToString().Substring(0, 8)} - Naziv:{foundFlightName.FlightName} - Polazak:{foundFlightName.DepartureTime} - Dolazak:{foundFlightName.ArrivalTime} - Udaljenost:{foundFlightName.Distance}km - Trajanje:{foundFlightName.FlightDuration}min");
                            Console.WriteLine("Let upješno pronađen.");
                        }
                        else
                            Console.WriteLine("Let nije pronađen.");


                        Console.ReadKey();
                        return;

                    default:
                        Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                        Console.ReadKey();
                        return;
                }
            }
            else
            {
                Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                Console.ReadKey();
                return;
            }




        }
        static void UpdateFlightInfo() {
            Console.Clear();
            Console.WriteLine("UREĐIVANJE PODATAKA LETA");

            Console.WriteLine("Svi letovi:");
            foreach (var flight in AllFlights)
                Console.WriteLine($"ID:{flight.Id.ToString().Substring(0, 8)}");


            var foundFlight = FindFlightById("Unesite ID leta koji želite urediti: ");
            if (foundFlight != null)
            {

                Console.WriteLine($"ID:{foundFlight.Id.ToString().Substring(0, 8)} - Naziv:{foundFlight.FlightName} - Polazak:{foundFlight.DepartureTime} - Dolazak:{foundFlight.ArrivalTime} - Udaljenost:{foundFlight.Distance}km - Trajanje:{foundFlight.FlightDuration}min");
                Console.WriteLine("Let uspješno pronađen.");
            }
            else
            {
                Console.WriteLine("Let nije pronađen.");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Unesite koji podatak želite urediti:\n1 - Vrijeme polaska\n2 - Vrijeme dolaska\n3 - Promjena posade");
            Console.Write("Odabir: ");
            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                switch (userChoice)
                {
                    case 1:

                        var newDepartureTime = InputValidator.ReadDepartureTime(foundFlight.ArrivalTime, "Unesite novo vrijeme polaska: ");
                        if (!InputValidator.ConfirmAction("Jeste li sigurni da želite urediti vrijeme polaska?"))
                        {
                            Console.WriteLine("Uređivanje leta otkazano.");
                            Console.ReadKey();
                            return;
                        }
                        foundFlight.DepartureTime = newDepartureTime;
                        foundFlight.FlightDuration = (int)(foundFlight.ArrivalTime - foundFlight.DepartureTime).TotalMinutes;
                        foundFlight.UpdateTimestamp();
                        Console.WriteLine("Uspješno uređivanje leta.");
                        Console.ReadKey();
                        return;
                    case 2:
                        var newArrivalTime = InputValidator.ReadArrivalTime(foundFlight.DepartureTime, "Unesite novo vrijeme dolaska: ");
                        if (!InputValidator.ConfirmAction("Jeste li sigurni da želite urediti vrijeme dolaska"))
                        {
                            Console.WriteLine("Uređivanje leta otkazano.");
                            Console.ReadKey();
                            return;
                        }
                        foundFlight.ArrivalTime = newArrivalTime;
                        foundFlight.FlightDuration = (int)(foundFlight.ArrivalTime - foundFlight.DepartureTime).TotalMinutes;
                        foundFlight.UpdateTimestamp();
                        Console.WriteLine("Uspješno uređivanje leta.");
                        Console.ReadKey();
                        return;
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                        Console.ReadKey();
                        return;

                }


            }
            else {
                Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                Console.ReadKey();
                return;
            }
            
        }
        static void DeleteFlight()
        {
            Console.Clear();
            Console.WriteLine("BRISANJE LETA");

            Console.WriteLine("Svi letovi:");
            foreach (var flight in AllFlights)
                Console.WriteLine($"ID:{flight.Id.ToString().Substring(0, 8)}");


            var foundFlight = FindFlightById("Unesite ID leta koji želite izbrisati: ");
            if (foundFlight != null)
            {

                Console.WriteLine($"ID:{foundFlight.Id.ToString().Substring(0, 8)} - Naziv:{foundFlight.FlightName} - Polazak:{foundFlight.DepartureTime} - Dolazak:{foundFlight.ArrivalTime} - Udaljenost:{foundFlight.Distance}km - Trajanje:{foundFlight.FlightDuration}min");
                Console.WriteLine("Let uspješno pronađen.");
            }
            else
            {
                Console.WriteLine("Let nije pronađen.");
                Console.ReadKey();
                return;
            }
            if(!InputValidator.ConfirmAction("Jeste li sigurni da želite izbrisati let?"))
            {
                Console.WriteLine("Brisanje leta otkazano.");
                Console.ReadKey();
                return;
            }
            AllFlights.Remove(foundFlight); 
            Console.WriteLine("Brisanje leta uspješno.");
            Console.ReadKey();
            return;
        }
        static void PrintAllAircrafts()
        {
            Console.Clear();
            Console.WriteLine("SVI AVIONI\n");
            if(AllAircrafts.Count == 0)
            {
                Console.WriteLine("Ne postoji ni jedan avion.");
                Console.WriteLine("Pritisnite bilo koju tipku za povratak na izbornik...");
                Console.ReadKey();
                return;
            }
            foreach (var aircraft in AllAircrafts)
            {
                Console.WriteLine($"ID:{aircraft.Id.ToString().Substring(0, 8)} - Naziv:{aircraft.Name} - Godina proizvodnje:{aircraft.YearOfProduction} - Kategorije sjedala:{string.Join(", ", aircraft.AircraftSeatCategories)}");
            }
            Console.WriteLine("\nPritisnite bilo koju tipku za povratak na izbornik...");
            Console.ReadKey();
            return;
        }
        static void AddAircraft()
        {
            Console.Clear();
            Console.WriteLine("DODAVANJE NOVOG AVIONA\n");
            string name = InputValidator.ReadString("Unesite naziv aviona: ");
            int yearOfProduction = InputValidator.ReadInt("Unesite godinu proizvodnje aviona: ");
            List<SeatCategories> aircraftSeatCategories = InputValidator.ReadSeatCategoryList("Unesite kategorije sjedala dostupne u avionu");
            List<int> seatCategoriesAvailability = new();
            foreach (var category in aircraftSeatCategories)
            {
                
                int availability = InputValidator.ReadInt($"Unesite broj dostupnih sjedala za kategoriju {category}: ");
                seatCategoriesAvailability.Add(availability);
            }
            if (InputValidator.ConfirmAction("Jeste li sigurni da želite unijeti avion?"))
            {

                Console.WriteLine("Avion je uspješno dodan.");
                var aircraft = new Aircraft(name, yearOfProduction, aircraftSeatCategories, seatCategoriesAvailability);
                AllAircrafts.Add(aircraft);
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Dodavanje aviona je otkazano.");
                Console.ReadKey();
                return;
            }
        }               
        static void SearchAircraft()
        {
            Console.Clear();
            if (AllAircrafts.Count == 0)
            {
                Console.WriteLine("Ne postoji ni jedan avion.");
                Console.WriteLine("Pritisnite bilo koju tipku za povratak na izbornik...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("PRETRAŽIVANJE AVIONA\nOdaberite načina pretraživanja\n1 - ID\n2 - Naziv");
            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                switch (userChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("PRETRAGA AVIONA PO ID-U\nSvi avioni:");
                        foreach (var aircraft in AllAircrafts)
                            Console.WriteLine($"ID:{aircraft.Id.ToString().Substring(0, 8)}");


                        var foundAircraft = FindAircraftById("Unesite ID aviona koji želite pretražiti: ");
                        if (foundAircraft != null)
                        {

                            Console.WriteLine($"ID:{foundAircraft.Id.ToString().Substring(0, 8)} - Naziv:{foundAircraft.Name} - Godina proizvodnje:{foundAircraft.YearOfProduction} - Kategorije sjedala:{string.Join(", ", foundAircraft.AircraftSeatCategories)}");
                            Console.WriteLine("Avion uspješno pronađen.");
                        }
                        else
                            Console.WriteLine("Avion nije pronađen.");
                        Console.ReadKey();
                        return;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("PRETRAGA AVIONA PO NAZIVU\nSvi avioni:");
                        foreach (var aircraft in AllAircrafts)
                            Console.WriteLine($"Naziv:{aircraft.Name}");

                        string aircraftInputName = InputValidator.ReadString("Unesite Naziv aviona koji želite pronaći: ");
                        var foundAircraftName = AllAircrafts.Find(aircraft => aircraft.Name == aircraftInputName);

                        if (foundAircraftName != null)
                        {
                            Console.WriteLine($"ID:{foundAircraftName.Id.ToString().Substring(0, 8)} - Naziv:{foundAircraftName.Name} - Godina proizvodnje:{foundAircraftName.YearOfProduction} - Kategorije sjedala:{string.Join(", ", foundAircraftName.AircraftSeatCategories)}");
                            Console.WriteLine("Avion upješno pronađen.");
                        }
                        else
                            Console.WriteLine("Avion nije pronađen.");


                        Console.ReadKey();
                        return;

                    default:
                        Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                        Console.ReadKey();
                        return;
                }
            }
            else
            {
                Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                Console.ReadKey();
                return;
            }


        }
        static void DeleteAircraft() {
            Console.Clear();
            if (AllAircrafts.Count == 0)
            {
                Console.WriteLine("Ne postoji ni jedan avion.");
                Console.WriteLine("Pritisnite bilo koju tipku za povratak na izbornik...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("BRISANJE AVIONA\nOdaberite načina brisanja\n1 - ID\n2 - Naziv");
            if (int.TryParse(Console.ReadLine(), out int userChoice))
            {
                switch (userChoice)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("BRISANJE AVIONA PO ID-U\nSvi avioni:");
                        foreach (var aircraft in AllAircrafts)
                            Console.WriteLine($"ID:{aircraft.Id.ToString().Substring(0, 8)}");


                        var foundAircraft = FindAircraftById("Unesite ID aviona koji želite izbrisati: ");
                        if (foundAircraft != null)
                        {

                            Console.WriteLine($"ID:{foundAircraft.Id.ToString().Substring(0, 8)} - Naziv:{foundAircraft.Name} - Godina proizvodnje:{foundAircraft.YearOfProduction} - Kategorije sjedala:{string.Join(", ", foundAircraft.AircraftSeatCategories)}");
                            Console.WriteLine("Avion uspješno pronađen.");
                        }
                        else
                        {
                            Console.WriteLine("Avion nije pronađen.");
                            Console.ReadKey();
                            return;
                        }
                        if (!InputValidator.ConfirmAction("Jeste li sigurni da želite izbrisati avion?"))
                        {
                            Console.WriteLine("Brisanje aviona otkazano.");
                            Console.ReadKey();
                            return;
                        }
                        AllAircrafts.Remove(foundAircraft);
                        Console.WriteLine("Brisanje aviona uspješno.");

                        Console.ReadKey();
                        return;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("BRISANJE AVIONA PO NAZIVU\nSvi avioni:");
                        foreach (var aircraft in AllAircrafts)
                            Console.WriteLine($"Naziv:{aircraft.Name}");

                        string aircraftInputName = InputValidator.ReadString("Unesite Naziv aviona koji želite izbrisati: ");
                        var foundAircraftName = AllAircrafts.Find(aircraft => aircraft.Name == aircraftInputName);

                        if (foundAircraftName != null)
                        {
                            Console.WriteLine($"ID:{foundAircraftName.Id.ToString().Substring(0, 8)} - Naziv:{foundAircraftName.Name} - Godina proizvodnje:{foundAircraftName.YearOfProduction} - Kategorije sjedala:{string.Join(", ", foundAircraftName.AircraftSeatCategories)}");
                            Console.WriteLine("Avion upješno pronađen.");
                        }
                        else
                        {
                            Console.WriteLine("Avion nije pronađen.");
                            Console.ReadKey();
                            return;
                        }
                        if(!InputValidator.ConfirmAction("Jeste li sigurni da želite izbrisati avion?"))
                        {
                            Console.WriteLine("Brisanje aviona otkazano.");
                            Console.ReadKey();
                            return;
                        }
                        AllAircrafts.Remove(foundAircraftName);
                        Console.WriteLine("Brisanje aviona uspješno.");

                        Console.ReadKey();
                        return;

                    default:
                        Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                        Console.ReadKey();
                        return;
                }
            }
            else
            {
                Console.WriteLine("Pogrešan unos, pokušajte ponovo.");
                Console.ReadKey();
                return;
            }
        }
        static void PrintAllCrews()
        {
            Console.Clear();
            Console.WriteLine("ISPIS SVIH POSADA\n");
            if(AllCrews.Count == 0)
            {
                Console.WriteLine("Nema ni jedna posada");
                Console.ReadKey();
                return;
            }
            foreach(Crew crew in AllCrews)                           
                crew.PrintCrewInfo();      
               
            
            Console.WriteLine("\nPritisnite bilo koju tipku za povratak na izbornik...");
            Console.ReadKey();
            return;
        }
        static void AddCrew()
        {
            Console.Clear();
            Console.WriteLine("DODAVANJE NOVE POSADE\n");         
  
            var pilot = SelectAvailableCrewMembers("Dostupni piloti:", JobPosition.Pilot);
            if (pilot == null)
            {
                Console.WriteLine("Pilot nije pronađen.");
                Console.ReadKey();
                return;
            }
           
            var copilot = SelectAvailableCrewMembers("Dostupni kopiloti:", JobPosition.CoPilot);
            if (copilot == null)
            {
                Console.WriteLine("Kopilot nije pronađen.");
                Console.ReadKey();
                return;
            }
            var flightAttendantFirst = SelectAvailableCrewMembers("Dostupne stjuardese:", JobPosition.FlightAttendant);
            
            if (flightAttendantFirst == null)
            {
                Console.WriteLine("Stjuardesa nije pronađen/a.");
                Console.ReadKey();
                return;
            }
            flightAttendantFirst.SetAvailability(false);
            var flightAttendantSecond = SelectAvailableCrewMembers("Dostupne stjuardese:", JobPosition.FlightAttendant);
            if (flightAttendantSecond == null)
            {
                flightAttendantFirst.SetAvailability(true);
                Console.WriteLine("Stjuardesa nije pronađen/a.");
                Console.ReadKey();
                return;
            }
            if (InputValidator.ConfirmAction("Jeste li sigurni da želite unijeti posadu?"))
            {
                var crewMembers = new List<Employee>();
                crewMembers.AddRange(new List<Employee> { pilot, copilot, flightAttendantFirst, flightAttendantSecond } );
                var crew = new Crew(crewMembers);
                AllCrews.Add(crew);
                foreach (var member in crewMembers)
                {
                    member.SetAvailability(false);
                    member.UpdateTimestamp();
                }
                Console.WriteLine("Posada je uspješno dodana.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Dodavanje posade je otkazano.");
                Console.ReadKey();
                return;
            }
        }
        static void AddEmployee()
    {
        Console.Clear();
        Console.WriteLine("DODAVANJE NOVOG ZAPOSLENIKA\n");
        string firstName = InputValidator.ReadString("Unesite ime zaposlenika: ");
        string lastName = InputValidator.ReadString("Unesite prezime zaposlenika: ");
        int yearOfBirth = InputValidator.ReadYear("Unesite godinu rođenja zaposlenika: ");
        var position = InputValidator.ReadJobPosition("Unesite poziciju zaposlenika: ");
        string gender = InputValidator.ReadGender("Unesite spol zaposlenika: ");
        if (InputValidator.ConfirmAction("Jeste li sigurni da želite unijeti zaposlenika?"))
        {
            var employee = new Employee(firstName, lastName, yearOfBirth, position, gender);
            AllEmployees.Add(employee);
            Console.WriteLine("Zaposlenik je uspješno dodan.");
            Console.ReadKey();
            return;
        }
        else
        {
            Console.WriteLine("Dodavanje zaposlenika je otkazano.");
            Console.ReadKey();
            return;
        }
    }
        static Flight FindFlightById(Passenger currentPassenger)

        {
            Console.WriteLine("Unesite ID leta koji želite pronaći (prvih 8 znakova):");
            string shortId = Console.ReadLine().Trim() ?? string.Empty;
            var currentPassengerFlights = currentPassenger.GetReservedFlightIds();
            var foundFlight = currentPassengerFlights.FirstOrDefault(flightId => flightId.ToString().StartsWith(shortId));
            if (foundFlight != Guid.Empty)
            {
                return AllFlights.Find(flight => flight.Id == foundFlight);
            }
            else
            {
                return null;
            }

        }
        static Flight FindFlightById(string prompt)
            {
                Console.WriteLine(prompt);
                string shortId = Console.ReadLine().Trim() ?? string.Empty;
                var foundFlightIndex = AllFlights.FindIndex(flight => flight.Id.ToString().StartsWith(shortId));
                if (foundFlightIndex == -1)
                    return null;
                return AllFlights[foundFlightIndex];
            }
        static Aircraft FindAircraftById(string prompt)
        {
            Console.WriteLine(prompt);
            string shortId = Console.ReadLine().Trim() ?? string.Empty;
            var foundAircraftIndex = AllAircrafts.FindIndex(aircraft => aircraft.Id.ToString().StartsWith(shortId));
            if (foundAircraftIndex == -1)
                return null;
            return AllAircrafts[foundAircraftIndex];
        }
        static Employee SelectAvailableCrewMembers(string prompt,JobPosition position)
        {
            Console.WriteLine(prompt);
            foreach (var employee in AllEmployees.Where(e => e.Position == position && e.Available == true))
            {

                Console.WriteLine($"Ime:{employee.FirstName} {employee.LastName}");
            }

            string employeeNameInput = InputValidator.ReadString($"Unesite ime osobe koje želite zaposliti:");
            var pilot = AllEmployees.FirstOrDefault(employee => employee.FirstName == employeeNameInput);
            
            return pilot;
        }
    }
}

