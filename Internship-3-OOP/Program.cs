using Internship_3_OOP.Classes;

namespace Internship_3_OOP
{
    internal class Program
    {
        private static List<Passenger> AllPassengers = new();
        static void Main(string[] args)
        {
            
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
                Console.WriteLine("Uspješna prijava!");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("Neuspješna prijava, pokušajte ponovo.");
                Console.ReadLine();
                return;
            }
        }
    }
}
