using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializePeople {
    class Program {
        static void Main(string[] args) {
            Person Veronka = new Person("Veronka", new DateTime(1985, 9, 21), Genders.Female);
            Console.WriteLine(Veronka.Age);
            Console.ReadKey();
            Veronka.Serialize("VeronkaPerson.dat");
            Veronka.Name = "Vercsi";
            Person DeserializedVeronka = Person.Deserialize("VeronkaPerson.dat");
            Console.WriteLine(DeserializedVeronka.ToString());
            Console.WriteLine(Veronka.ToString());
            Console.ReadKey();
        }
    }
}
