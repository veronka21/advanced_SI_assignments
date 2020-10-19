using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializePeople {
    class Program {
        static void Main(string[] args) {
            Person Veronka = new Person("Klaus", new DateTime(1985, 9, 21), Genders.Male);
            Console.WriteLine(Veronka.Age);
            Console.ReadKey();
        }
    }
}
