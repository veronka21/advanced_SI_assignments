using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateClass {
    class Program {
        static void Main(string[] args) {
            Person girl = new Person("Sophie", new DateTime(2000, 9, 21), Genders.Female);
            Person boy = new Person("Bobbie", new DateTime(1998, 7, 21), Genders.Male);
            Console.WriteLine(girl.ToString());
            Console.WriteLine(boy.ToString());
            Employee man = new Employee("John", new DateTime(1960, 1, 21), Genders.Male, 10000, "accountant");
            Room room = new Room();
            room.RoomNumber = 21;
            man.Room = room;
            Console.WriteLine(man.ToString());
        }
    }
}
