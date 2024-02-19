using System;
using System.Globalization;

namespace Backend.Model
{
    public class MovieStar
    {
        public string DateOfBirth { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public int Age
        {
            get
            {
                var dob = DateTime.ParseExact(DateOfBirth, "dd-MMM-yyyy", CultureInfo.InvariantCulture);
                var now = DateTime.Today;
                int age = now.Year - dob.Year;
                if (dob.Date > now.AddYears(-age)) age--;
                return age;
            }
        }
    }
}