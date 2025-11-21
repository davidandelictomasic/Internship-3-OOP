using System;
using System.Collections.Generic;
namespace Internship_3_OOP.Classes
{
    internal class Employee : Person
    {
            public JobPosition Position { get; set; }
            public string Gender { get; set; }

            public bool Available { get; private set; } = true;

        public Employee(string firstName, string lastName, int yearOfBirth, JobPosition position, string gender)
                 : base(firstName, lastName, yearOfBirth)
            {
                this.Position = position;
                this.Gender = gender;
            }
        public void SetAvailability(bool availability)
        {
            
            this.Available = availability; 
        }
    }
}

