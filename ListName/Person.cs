using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListName
{
    public class Person
    {
        // Nom de famille
        public string LastName { get; set; }
        //Prenom
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }


        public Person(string firstname, string lastname = "", DateTime birth = new DateTime())
        {
            LastName = lastname;
            FirstName = firstname;
            BirthDate = birth;

        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} né·e le {BirthDate.ToShortDateString()}";

        }
    }
}
