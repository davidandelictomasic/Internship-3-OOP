using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internship_3_OOP.Classes
{
    internal abstract class Person : EntityBase
    {
        public string FirstName { get; set; }  
        public string LastName { get; set; }   
        public int YearOfBirth { get; set; } 
        

        public Person(string firstName, string lastName, int yearOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            YearOfBirth = yearOfBirth;
            
        }

    }
}
