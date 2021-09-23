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

        public void add(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Person person = new Person(name);
                foreach (Person pers in ListName)
                {
                    if (pers.Name.Equals(name))
                    {
                        return;
                    }
                    
                }
                ListName.Add(person);
            }
        }

        public void remove(string name)
        {
            Person p = new Person(name);
            foreach (Person pers in ListName)
            {
                if (pers.Name.Equals(name))
                {
                    ListName.Remove(pers);
                    break;
                }

            }

        }
        public void removeAt(int index)
        {
            if (ListName.Count > 0)
            {
                ListName.RemoveAt(index);
            }
        }
    }
}
