using SoftwareDesign.Pr02.ObserverPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Pr2_ObserverPattern.Test
{
    
    
    /// <summary>
    ///This is a test class for UserTest and is intended
    ///to contain all UserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserTest
    {

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext)
        // {
        //    
        // }
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for User Constructor
        ///</summary>
        [TestMethod()]
        public void UserConstructorTest()
        {
            User us = new User("Pablo");
            Assert.IsTrue(us.Name.Equals("Pablo"));
        }

        /// <summary>
        ///A test for addPost
        ///</summary>
        [TestMethod()]
        public void addPostTest()
        {
            User target = new User("Pablo"); 
            String text = "This is a post"; 
            target.addPost(text);
            Assert.IsTrue(target.containsPost(text));
        }

        /// <summary>
        ///A test for Name
        ///</summary>
        [TestMethod()]
        public void NameTest()
        {
            User target = new User("Pablo"); 
            Assert.AreEqual(target.Name, "Pablo");
            target.Name = "Paco";
            Assert.AreEqual(target.Name, "Paco");
        }
    }
}
