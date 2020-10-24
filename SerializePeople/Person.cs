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
    public class Person : IDeserializationCallback, ISerializable {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Genders Gender { get; set; }
        [NonSerialized]
        private int _age;
        public int Age { get { return _age; } set { _age = value; } }

        public Person(string name, DateTime birthDate, Genders gender) {
            Name = name;
            BirthDate = birthDate;
            this.Gender = gender;
            SetAge();
        }

        public Person() {
        }

        public override string ToString() {
            return $"{this.GetType().Name}: {Name}, gender: {Gender}, birth date: {BirthDate.ToString("yyyy-MM-dd")}, age: {Age}";
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

        public void GetObjectData(SerializationInfo info, StreamingContext context) {
            info.AddValue("name", Name);
            info.AddValue("birthDate", BirthDate);
            info.AddValue("gender", Gender);
        }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   Name == person.Name &&
                   BirthDate == person.BirthDate &&
                   Gender == person.Gender &&
                   _age == person._age &&
                   Age == person.Age;
        }

        public override int GetHashCode()
        {
            int hashCode = -764446635;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + BirthDate.GetHashCode();
            hashCode = hashCode * -1521134295 + Gender.GetHashCode();
            hashCode = hashCode * -1521134295 + _age.GetHashCode();
            hashCode = hashCode * -1521134295 + Age.GetHashCode();
            return hashCode;
        }

        public Person(SerializationInfo info, StreamingContext context) {
            Name = (string)info.GetValue("name", typeof(string));
            BirthDate = (DateTime)info.GetValue("birthDate", typeof(DateTime));
            Gender = (Genders)info.GetValue("gender", typeof(Genders));
        }
    }

    public enum Genders {
        Male, Female
    }
}
