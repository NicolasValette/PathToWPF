using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListName
{
    public class People
    {
        public List<Person> ListName { get; }

        public People()
        {
            ListName = new List<Person>();
            Person p1 = new("Jean");
            Person p2 = new("Niko");
            Person p3 = new Person("Elayan", "Mitsuyo");
            ListName.Add(p1);
            ListName.Add(p2);
            ListName.Add(p3);
        }

        public void Add(string firstname, string lastname = "", DateTime birthdate = new DateTime())
        {
            if (!string.IsNullOrWhiteSpace(firstname))
            {
                Person person = new(firstname, lastname, birthdate);
                foreach (Person pers in ListName)
                {
                    if (pers.FirstName.Equals(firstname) && pers.LastName.Equals(lastname) && pers.BirthDate.Equals(birthdate))
                    {
                        return;
                    }

                }
                ListName.Add(person);
            }
        }

        public void Remove(string firstname, string lastname = "", DateTime birthdate = new DateTime())
        {
            Person person = new(firstname, lastname, birthdate);
            foreach (Person pers in ListName)
            {
                if (pers.FirstName.Equals(firstname) && pers.LastName.Equals(lastname) && pers.BirthDate.Equals(birthdate))
                {
                    ListName.Remove(pers);
                    break;
                }

            }

        }
        public void RemoveAt(int index)
        {
            if (ListName.Count > 0)
            {
                ListName.RemoveAt(index);
            }
        }
    }
}
