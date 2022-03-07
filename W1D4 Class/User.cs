using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W1D4_Class
{
    public class User
    { // POCO Plain old C# Object
        public User() { }
        public User(string first, string last, DateTime dob, string email)
        {
            FirstName = first;
            LastName = last;
            DateOfBirth = dob;
            Email = email;

        }
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
        public int Age()
        {
            TimeSpan ageSpan = DateTime.Now - DateOfBirth;
            double totalAgeInYears = ageSpan.TotalDays / 365.25;
            return Convert.ToInt32(Math.Floor(totalAgeInYears));
        }
    }
}
