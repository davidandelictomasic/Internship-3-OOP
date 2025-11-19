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
    }
}
