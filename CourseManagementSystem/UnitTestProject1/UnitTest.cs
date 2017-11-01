using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CmsLibrary;

namespace CmsUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void StudentTest()
        {
            Database.LoadDatabase();
            Location location = new Location()
            {
                AddressStreet1 = "John St"
            };
            if (!location.Add())
            {
                Assert.Fail("Location add failed.");
                return;
            }
            //student
            Student student = new Student()
            {
                FirstName = "Maxwell",
                LastName = "Littlejohn",
                LocationId = location.Id,
                DateOfBirth = new DateTime(1991, 10, 17),
                Email = "maximusmax3000@hotmail.com",
                CountryOfOrigin = "Australia",
                Gender = Types.GenderType["Male"],
                ContactNumber = "0468900468",
                Aboriginal = false,
                Centrelink = true,
                Disability = true,
                DisabilityDescription = "Crippling Depression"
            };
            if (!student.Add())
            {
                Assert.Fail("Student add failed.");
                return;
            }
            string femaleName = "Jennifer";
            student.FirstName = femaleName;
            student.Gender = Types.GenderType["Female"];
            if (!student.Update())
            {
                Assert.Fail("Student update failed.");
                return;
            }
            if (!student.Search())
            {
                Assert.Fail("Student search failed.");
                return;
            }
            Assert.AreEqual(femaleName, student.FirstName);
        }
    }
}
