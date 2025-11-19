using System;
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
            var Flight1 = new Flight(
                origin: "ZAG",
                destination: "LHR",
                departureTime: DateTime.Today.AddHours(500),
                arrivalTime: DateTime.Today.AddHours(504),
                capacity: 180,
                distance: 1500.0
            );
            AllFlights.Add(Flight1);

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
                        Console.WriteLine("PRETRAGA LETA PO NAZIVU\nRezervirani letovi:");
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
    }
}
