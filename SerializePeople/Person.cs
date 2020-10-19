using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace SerializePeople {
    [Serializable()]
    class Person {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        Genders gender { get; set; }
        public int Age { get; set; }

        public Person(string name, DateTime birthDate, Genders gender) {
            Name = name;
            BirthDate = birthDate;
            this.gender = gender;
            SetAge();
        }

        public override string ToString() {
            return $"{this.GetType().Name}: {Name}, gender: {gender}, birth date: {BirthDate.ToString("yyyy-MM-dd")}";
        }

        public void SetAge() {
            Age = DateTime.Today.Year - BirthDate.Year;
        }
    }

    enum Genders {
        Male, Female
    }
}
