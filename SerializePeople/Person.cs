using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople {
    [Serializable()]
    class Person : IDeserializationCallback {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        Genders gender { get; set; }
        [NonSerialized]
        private int _age;
        public int Age { get { return _age; } set { _age = value; } }

        public Person(string name, DateTime birthDate, Genders gender) {
            Name = name;
            BirthDate = birthDate;
            this.gender = gender;
            SetAge();
        }

        public Person() {
        }

        public override string ToString() {
            return $"{this.GetType().Name}: {Name}, gender: {gender}, birth date: {BirthDate.ToString("yyyy-MM-dd")}, age: {Age}";
        }

        public void SetAge() {
            Age = DateTime.Today.Year - BirthDate.Year;
        }

        public void Serialize(string output) {
            Stream stream = File.Open(output, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, this);
            stream.Close();
        }

        public static Person Deserialize(string file) {
            Person person = new Person();
            Stream stream = File.Open(file, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            object objectFromFile = binaryFormatter.Deserialize(stream);
            person = (Person)objectFromFile;
            stream.Close();
            return person;
        }

        public void OnDeserialization(object sender) {
            SetAge();
        }
    }

    enum Genders {
        Male, Female
    }
}
