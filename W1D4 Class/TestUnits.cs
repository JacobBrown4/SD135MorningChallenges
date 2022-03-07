using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace W1D4_Class
{
    [TestClass]
    public class TestUnits
    {
        [TestMethod]
        public void UserTests()
        {
            User user = new User();
            user.FirstName = "Jacob";
            user.LastName = "Brown";
            Assert.AreEqual("Jacob", user.FirstName);
            Assert.AreEqual("Jacob Brown", user.FullName()); 
        }
    }
}
