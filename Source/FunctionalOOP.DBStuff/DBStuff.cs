using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalOOP.ExampleDBFunctions
{
    public static class DBStuff
    {
        private static readonly List<Person> personList = new List<Person>
        {
            new Person{Id = 123, FirstName = "Jack", LastName = "O'Neill", IsActive = true},
            new Person{Id = 234, FirstName = "Samantha", LastName = "Carter", IsActive = true},
            new Person{Id = 345, FirstName = "Teal'C", LastName = "of Chulak", IsActive = true},
            new Person{Id = 456, FirstName = "Daniel", LastName = "Jackson", IsActive = true},
            new Person{Id = 567, FirstName = "Janet", LastName = "Fraiser", IsActive = false},
        };
        public static Person GetPersonById(int id)
        {
            if (id < 0 || id == 9999) throw new Exception("The system is down.");

            return personList.FirstOrDefault(p => p.Id == id);
        }
    }
}
