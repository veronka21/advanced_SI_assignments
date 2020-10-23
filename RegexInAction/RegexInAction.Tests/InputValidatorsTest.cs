using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RegexInAction;

namespace RegexInAction.Tests
{
    [TestFixture]
    public class InputValidatorsTest
    {
        [TestCase("Veron")]
        [TestCase("12345")]
        [TestCase("fds+4sad")]
        [TestCase("DWDA_Sas")]
        [TestCase("")]
        public void IsValidName_GivenSomeInvalidNames_ShouldReturnFalse(string name)
        {
            Assert.IsFalse(InputValidators.IsValidName(name));
        }

        [TestCase("Veronika Takacs")]
        [TestCase("Jim Carrey")]
        [TestCase("Dwight D Eisenhover")]
        public void IsValidName_GivenSomeValidNames_ShouldReturnTrue(string name)
        {
            Assert.IsTrue(InputValidators.IsValidName(name));
        }

        [TestCase("01234567890")]
        [TestCase("0620432345")]
        [TestCase("dsadma")]
        [TestCase("GFDS_fsda")]
        [TestCase("")]
        public void IsValidPhoneNumber_GivenSomeInvalidInputs_ShouldReturnFalse(string phoneNumber)
        {
            Assert.IsFalse(InputValidators.IsValidPhoneNumber(phoneNumber));
        }

        [TestCase("06201234567")]
        [TestCase("06452341234")]
        public void IsValidPhoneNumber_GivenSomeValidInputs_ShouldReturnTrue(string phoneNumber)
        {
            Assert.IsTrue(InputValidators.IsValidPhoneNumber(phoneNumber));
        }

        [TestCase("dsad@sad.d")]
        [TestCase("dsaddasda.com")]
        [TestCase("dsadd_asd2311.uk")]
        [TestCase("dsaSDAdasd2311@@rewrw.com")]
        public void IsValidEmailAddress_GivenSomeInvalidEmails_ShouldReturnFalse(string email)
        {
            Assert.IsFalse(InputValidators.IsValidEmailAddress(email));
        }

        [TestCase("example@xyz.hu")]
        [TestCase("123dfas@xyz.com")]
        [TestCase("123-d_f.as@xyz.com")]
        public void IsValidEmailAddress_GivenSomeValidEmails_ShouldReturnTrue(string email)
        {
            Assert.IsTrue(InputValidators.IsValidEmailAddress(email));
        }
    }
}
