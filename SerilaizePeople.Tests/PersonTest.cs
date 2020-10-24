using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SerializePeople;
using System.IO;

namespace SerializePeople.Tests
{
    [TestFixture]
    public class PersonTest
    {
        Person _testPerson = new Person("Jim Carrey", new DateTime(1962, 1, 17), Genders.Male);

        [Test]
        public void Person_CreatingInstance_ShouldProduceObjectWithEligibleProperties()
        {
            Assert.Multiple(() =>
            {
                Assert.AreEqual("Jim Carrey", _testPerson.Name);
                Assert.AreEqual(new DateTime(1962, 1, 17), _testPerson.BirthDate);
                Assert.AreEqual(Genders.Male, _testPerson.Gender);
                Assert.AreEqual(58, _testPerson.Age);
            });
        }

        [Test]
        public void ToString_CallingMethod_ShouldReturnProperStringRepresentationOfPersonObject()
        {
            Assert.AreEqual("Person: Jim Carrey, gender: Male, birth date: 1962-01-17, age: 58", _testPerson.ToString());
        }

        [Test]
        public void Serialize_CheckIfPersonObjectIsSerializable_ShouldReturnTrue()
        {
            Assert.IsTrue(typeof(Person).IsSerializable);
        }

        [Test]
        public void Serialize_CallingMethodOnPersonObject_ShouldCreateOutputFile()
        {
            File.Delete("TestPerson.dat");
            _testPerson.Serialize("TestPerson.dat");
            Assert.IsTrue(File.Exists("TestPerson.dat"));
        }

        [Test]
        public void Deserialize_CallingMethodOnPersonObject_ShouldCreatePersonObjectFromFile()
        {
            File.Delete("TestPerson.dat");
            _testPerson.Serialize("TestPerson.dat");
            Person fromFile = Person.Deserialize("TestPerson.dat");
            Assert.AreEqual(_testPerson, fromFile);
            //Assert.IsTrue(_testPerson.Equals(fromFile));
        }
    }
}
