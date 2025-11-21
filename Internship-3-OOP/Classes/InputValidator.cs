using System.Text.RegularExpressions;

namespace Internship_3_OOP.Classes
{
    internal static class InputValidator
    {
        public static string ReadString(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Polje ne smije biti prazno. Pokušajte ponovo.");
                    
                    continue;
                }

                
                if (input.Any(char.IsDigit))
                {
                    Console.WriteLine("Ime ne smije sadržavati brojeve. Pokušajte ponovo.");
                   
                    continue;
                }

                
                return input;
            }
        }
        public static int ReadYear(string prompt)
        {
            int year;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();

                if (!int.TryParse(input, out year))
                {
                    Console.WriteLine("Neispravan unos. Pokušajte ponovo.");
                    continue;
                }

                if (year < 1900 || year > DateTime.Now.Year)
                {
                    Console.WriteLine($"Godina mora biti između 1900 i {DateTime.Now.Year}. Pokušajte ponovo.");
                    continue;
                }

                return year;
            }
        }
        public static string ReadEmail(string prompt)
        {
            string input;
            Regex emailRegex = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");

            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Email ne smije biti prazan. Pokušajte ponovo.");
                    continue;
                }

                if (!emailRegex.IsMatch(input))
                {
                    Console.WriteLine("Neispravan format email-a. Pokušajte ponovo.");
                    continue;
                }

                return input;
            }
        }
        public static string ReadPassword(string prompt)
        {
            string input;

            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Lozinka ne smije biti prazna. Pokušajte ponovo.");
                    continue;
                }

                if (input.Length < 6)
                {
                    Console.WriteLine("Lozinka mora imati najmanje 6 znakova.");
                    continue;
                }

                if (!input.Any(char.IsUpper))
                {
                    Console.WriteLine("Lozinka mora sadržavati barem jedno veliko slovo.");
                    continue;
                }
                
                if (!input.Any(char.IsDigit))
                {
                    Console.WriteLine("Lozinka mora sadržavati barem jedan broj.");
                    continue;
                }

                return input;
            }
        }
        public static DateTime ReadDateTime(string prompt)
        {
            DateTime result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();

                
                if (!DateTime.TryParse(input, out result))
                {
                    Console.WriteLine("Neispravan format datuma/vremena. Pokušajte ponovo (npr. 19.11.2025 14:30).");
                    continue;
                }

                if (result < DateTime.Now)
                {
                    Console.WriteLine("Datum i vrijeme ne mogu biti u prošlosti. Pokušajte ponovo.");
                    continue;
                }

                return result;
            }
        }
        public static int ReadInt(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();

                if (!int.TryParse(input, out result))
                {
                    Console.WriteLine("Neispravan unos. Unesite cijeli broj.");
                    continue;
                }

                if (result < 0)
                {
                    Console.WriteLine("Broj ne smije biti manji od 0. Pokušajte ponovo.");
                    continue;
                }                

                return result;
            }
        }
        public static double ReadDouble(string prompt)
        {
            double result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();

                if (!double.TryParse(input, out result))
                {
                    Console.WriteLine("Neispravan unos. Unesite decimalni broj.");
                    continue;
                }

                if (result < 0)
                {
                    Console.WriteLine($"Vrijednost ne smije biti manja od 0. Pokušajte ponovo.");
                    continue;
                }               

                return result;
            }
        }
        public static bool ConfirmAction(string message)
        {
            Console.WriteLine($"{message} (Pritisnite ENTER za potvrdu ili bilo koju drugu tipku za prekid.)");

            var key = Console.ReadKey().Key;
            

            if (key == ConsoleKey.Enter)
            {
                
                return true;
            }
            else
            {
                
                return false;
            }
        }
        public static DateTime ReadArrivalTime(DateTime departureTime,string prompt)
        {
            while (true)
            {
                
                DateTime arrival = ReadDateTime(prompt);

                if (arrival <= departureTime)
                {
                    Console.WriteLine("Vrijeme dolaska mora biti POSLIJE vremena polaska! Pokušajte ponovo.");
                    continue;
                }

                return arrival;
            }
        }
        public static DateTime ReadDepartureTime(DateTime arrivalTime, string prompt)
        {
            while (true)
            {

                DateTime departure = ReadDateTime(prompt);

                if (arrivalTime <= departure)
                {
                    Console.WriteLine("Vrijeme polaska mora biti PRIJE vremena polaska! Pokušajte ponovo.");
                    continue;
                }

                return departure;
            }
        }

        public static SeatCategories ReadSeatCategory(string prompt)
        {
            SeatCategories result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();

                if (!SeatCategories.TryParse(input, out result))
                {
                    Console.WriteLine("Neispravan unos. .");
                    continue;
                }

                
                return result;
            }
        }
        public static List<SeatCategories> ReadSeatCategoryList(string message)
        {
            while (true)
            {
                Console.Write($"{message} (odvojite zarezima, npr: standard, business, vip): ");
                string input = Console.ReadLine().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Morate unijeti barem jednu kategoriju.");
                    continue;
                }

                var parts = input.Split(',')
                                 .Select(p => p.Trim().ToLower())
                                 .Where(p => p.Length > 0)
                                 .Distinct()
                                 .ToList();

                List<SeatCategories> categories = new();

                bool error = false;

                foreach (var p in parts)
                {
                    switch (p)
                    {
                        case "standard":
                            categories.Add(SeatCategories.Standard);
                            break;
                        case "business":
                            categories.Add(SeatCategories.Business);
                            break;
                        case "vip":
                            categories.Add(SeatCategories.VIP);
                            break;
                        default:
                            Console.WriteLine($"Nepoznata kategorija: '{p}'");
                            error = true;
                            break;
                    }
                }

                if (error)
                {
                    Console.WriteLine("Pokušajte ponovo.\n");
                    continue;
                }

                if (categories.Count == 0)
                {
                    Console.WriteLine("Niste unijeli ispravne kategorije.");
                    continue;
                }

                return categories;
            }
        }
        public static JobPosition ReadJobPosition(string prompt)
        {
            JobPosition result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim();

                if (!JobPosition.TryParse(input, out result))
                {
                    Console.WriteLine("Neispravan unos. .");
                    continue;
                }


                return result;
            }
        }

        public static string ReadGender(string prompt)
        {
            string result;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim().ToUpper();

                if (input != "M" && input != "Z" && input == null)
                {
                    Console.WriteLine("Neispravan unos. .");
                    
                    continue;
                }
                result = input;


                return result;
            }
        }


    }
}
