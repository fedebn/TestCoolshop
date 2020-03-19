using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCoolShop
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        public Person() { }

        public Person(int id, string name, string surname, DateTime birthdate)
        {
            Id = id;
            Name = name;
            Surname = surname;
            BirthDate = birthdate;
        }

        public override string ToString()
        {
            return $"{Id},{Surname},{Name},{BirthDate}";
        }
    }
}
