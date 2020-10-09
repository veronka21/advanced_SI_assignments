using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateClass {
    class Employee : Person, ICloneable {
        public double Salary { get; set; }
        public string Profession { get; set; }
        public Room Room { get; set; }
        public Employee(string name, DateTime birthDate, Genders gender, double salary, string profession) : base(name, birthDate, gender) {
            Salary = salary;
            Profession = profession;
        }

        string getRoomNumber() {
            string roomNumber = "TBD";
            if (Room != null) roomNumber = Room.RoomNumber.ToString();
            return roomNumber;
        }

        public override string ToString() {
            return $"{base.ToString()}, salary: {Salary}, profession: {Profession}, room: {getRoomNumber()}";
        }

        public object Clone() {
            Employee newEmployee = (Employee)this.MemberwiseClone();
            newEmployee.Room = new Room(Room.RoomNumber);
            return newEmployee;
            //return this.MemberwiseClone();
        }
    }

    class Room {
        public int RoomNumber { get; set; }

        public Room(int roomNumber) {
            RoomNumber = roomNumber;
        }
    }
}
