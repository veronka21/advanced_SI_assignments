using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateClass {
    class Person {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        Genders gender;

        public Person(string name, DateTime birthDate, Genders gender) {
            Name = name;
            BirthDate = birthDate;
            this.gender = gender;
        }

        public override string ToString() {
            return $"{this.GetType().Name}: {Name}, gender: {gender}, birth date: {BirthDate.ToString("yyyy-MM-dd")}";
        }
    }

    enum Genders {
        Male, Female
    }
}
