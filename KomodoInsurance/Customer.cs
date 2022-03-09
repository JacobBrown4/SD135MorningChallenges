using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoInsurance
{
    public class Customer
    {
        public Customer() {}
        public Customer(int id, string lastName,int age,DateTime enrollment)
        {
            Id = id;
            LastName = lastName;
            Age = age;
            EnrollmentDate = enrollment;
        }
        public int Id { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int YearsWithKomodo
        {
            get
            {
                double totalRaw = (DateTime.Now - EnrollmentDate).TotalDays / 365.25;
                return Convert.ToInt32(Math.Floor(totalRaw));

            }
        }

        public string ThankYou()
        {
            if(YearsWithKomodo > 5)
            {
                return "Thank you for being a Gold member.";
            }
            else if (YearsWithKomodo > 1 && YearsWithKomodo <= 5)
            {
                return "Thank you for being a member";
            }
            else
            {
                return "Welcome to Komodo Insurance";
            }
        }
    }
}
