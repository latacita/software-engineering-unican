﻿using Pr02_BidirectionalAssociations.PeopleCanBeSingle;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Pr02_BidirectionalAssociations.PeopleCanBeSingle.Test
{
    
    
    /// <summary>
    ///This is a test class for ManTest and is intended
    ///to contain all ManTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ManTest
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
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
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
        ///A test for Man Constructor
        ///</summary>
        [TestMethod()]
        public void ManConstructorTest()
        {
            Man target = new Man("Pablo");
            Assert.IsTrue(target.Name.Equals("Pablo"),"Constructor works for equality");
            Assert.IsFalse(target.Name.Equals("Paco"), "Constructor works for not equality");
        } // ManConstructorTest

        /// <summary>
        ///     A test for Equals
        ///</summary>
        [TestMethod()]
        public void EqualsTest()
        {
            Man man = new Man("Pablo");
            Man otherEqualMan = new Man("Pablo");
            Man otherNotEqualMan = new Man("Paco");
            String obj = "Juan";
            Assert.AreEqual(man,otherEqualMan,"Equals works for equality");
            Assert.AreNotEqual(man, otherNotEqualMan, "Equals works for inequality");
            Assert.AreNotEqual(man, obj, "Equals works for erronous types");
        }

        /// <summary>
        ///A test for the get accesor for name Name
        ///</summary>
        [TestMethod()]
        public void GetNameTest()
        {
            String name      = "Pablo";
            String otherName = "Paco";
            Man man = new Man(name); 
            Assert.AreEqual(man.Name,name);
            Assert.AreNotEqual(man.Name, otherName);
        } // GetNameTest

        /// <summary>
        ///A test for the set accesor for Name
        ///</summary>
        [TestMethod()]
        public void SetNameTest()
        {
            String name = "Pablo";
            String otherName = "Paco";
            Man man = new Man(name);
            man.Name = otherName;
            Assert.AreNotEqual(man.Name, name);
            Assert.AreEqual(man.Name, otherName);
        } // GetNameTest

        /// <summary>
        ///A test for Wife
        ///</summary>
        [TestMethod()]
        public void WifeTest()
        {
            Man   man   = new Man("Pablo");
            Woman scarlett  = new Woman("Scarlett");
            Woman catherine = new Woman("Catherine");

            // Initially, I am single
            Assert.AreEqual(man.Wife,null);

            // I married Scarlett, which means Scarlett marries me
            man.Wife = scarlett;
            Assert.AreEqual(man.Wife, scarlett);
            Assert.AreEqual(scarlett.Husband, man);

            // I get divorced with Scarlett :-(, which means Scarlett is free 
            man.Wife = null;
            Assert.AreEqual(man.Wife, null);
            Assert.AreEqual(scarlett.Husband, null);

            // I married Scarlett, but I got confused during the weeding and I married 
            // catherine in the end, so catherine is married with me
            man.Wife = scarlett;
            Assert.AreEqual(catherine.Husband, null);
            man.Wife = catherine;
            Assert.AreEqual(man.Wife, catherine);
            Assert.AreEqual(catherine.Husband, man);
            Assert.AreEqual(scarlett.Husband, null);
        }

        /// <summary>
        ///A test for Wife
        ///</summary>
        [TestMethod()]
        public void ChangeCoupleTest()
        {

            // We change couples
            Man man = new Man("Pablo");
            Man newMan = new Man("Paco");
            Woman scarlett = new Woman("Scarlett");
            Woman catherine = new Woman("Catherine");


            man.Wife = scarlett;
            newMan.Wife = catherine;

            Assert.AreEqual(man.Wife, scarlett);
            Assert.AreEqual(scarlett.Husband, man);
            Assert.AreEqual(newMan.Wife, catherine);
            Assert.AreEqual(catherine.Husband, newMan);

            man.Wife = catherine;
            newMan.Wife = scarlett;

            Assert.AreEqual(man.Wife, catherine);
            Assert.AreEqual(catherine.Husband, man);
            Assert.AreEqual(newMan.Wife, scarlett);
            Assert.AreEqual(scarlett.Husband, newMan);
        }

    }
}
