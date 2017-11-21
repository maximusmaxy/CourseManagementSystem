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
            //load database
            Database.LoadDatabase();
            //location
            Location location = new Location()
            {
                AddressStreet1 = "John St"
            };
            //test add location
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
            //test add student
            if (!student.Add())
            {
                Assert.Fail("Student add failed.");
                return;
            }
            //test update student information
            string femaleName = "Jennifer";
            student.FirstName = femaleName;
            student.Gender = Types.GenderType["Female"];
            if (!student.Update())
            {
                Assert.Fail("Student update failed.");
                return;
            }
            //test search student
            if (!student.Search())
            {
                Assert.Fail("Student search failed.");
                return;
            }
            //assert details have changed
            Assert.AreEqual(femaleName, student.FirstName);
            //test delete
            if (!student.Delete())
            {
                Assert.Fail("Student delete failed.");
                return;
            }
            try
            {
                Validation.ShowErrors = false;
                //make sure student doesn't exist
                if (student.Search())
                {
                    Assert.Fail("Student search succeeded on a deleted student. That shouldn't happen.");
                    return;
                }
            }
            finally
            {
                Validation.ShowErrors = true;
            }
        }
    }
}
