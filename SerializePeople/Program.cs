using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SerializePeople {
    class Program {
        static void Main(string[] args) {
            //Person Veronka = new Person("Veronka", new DateTime(1985, 9, 21), Genders.Female);
            //Console.WriteLine(Veronka.ToString());
            //Console.ReadKey();
            //Veronka.Serialize("VeronkaPerson.dat");
            //Person DeserializedVeronka = Person.Deserialize("VeronkaPerson.dat");
            //Console.WriteLine(DeserializedVeronka.ToString());
            //Console.ReadKey();
            Person Jim = new Person("Jim", new DateTime(1962, 1, 17), Genders.Male);
            Console.WriteLine(Jim.ToString());
            Console.ReadKey();
            Jim.Serialize("JimPerson.dat");
            Person DeserializedJim = Person.Deserialize("JimPerson.dat");
            Console.WriteLine(DeserializedJim.ToString());
            Console.ReadKey();
        }
    }
}
