using Pr02_BidirectionalAssociations.TotalPolygamy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Pr02_BidirectionalAssociations.TotalPolygamy.Test
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
            Assert.IsTrue(target.Name.Equals("Pablo"), "Constructor works for equality");
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
            Assert.AreEqual(man, otherEqualMan, "Equals works for equality");
            Assert.AreNotEqual(man, otherNotEqualMan, "Equals works for inequality");
            Assert.AreNotEqual(man, obj, "Equals works for erronous types");
        }

        /// <summary>
        ///A test for the get accesor for name Name
        ///</summary>
        [TestMethod()]
        public void GetNameTest()
        {
            String name = "Pablo";
            String otherName = "Paco";
            Man man = new Man(name);
            Assert.AreEqual(man.Name, name);
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
        public void AddWifeTest()
        {

            Man man = new Man("Pablo");
            Woman scarlett = new Woman("Scarlett");
            Woman catherine = new Woman("Catherine");

            // I married Scarlett, which means Scarlett marries me
            man.AddWife(scarlett);
            Assert.IsTrue(man.HasMarried(scarlett));
            Assert.IsTrue(scarlett.HasMarried(man));
            Assert.IsFalse(man.HasMarried(catherine));
            Assert.IsFalse(catherine.HasMarried(man));

            // I married Catherine also, which means Catherine marries me
            man.AddWife(catherine);
            Assert.IsTrue(man.HasMarried(scarlett));
            Assert.IsTrue(man.HasMarried(catherine));
            Assert.IsTrue(man.HasMarried(catherine));
            Assert.IsTrue(catherine.HasMarried(man));

        } // AddWifeTest

        /// <summary>
        ///A test for HasMarried
        ///</summary>
        [TestMethod()]
        public void HasMarriedTest()
        {

            Man man = new Man("Pablo");
            Woman scarlett = new Woman("Scarlett");
            Woman catherine = new Woman("Catherine");

            // I married Scarlett, which means Scarlett marries me
            man.AddWife(scarlett);
            Assert.IsTrue(man.HasMarried(scarlett));
            Assert.IsFalse(man.HasMarried(catherine));

        } // HasMarried

        /// <summary>
        ///A test for RemoveWife
        ///</summary>
        [TestMethod()]
        public void RemoveWifeTest()
        {

            Man man = new Man("Pablo");
            Woman scarlett = new Woman("Scarlett");
            Woman catherine = new Woman("Catherine");

            man.AddWife(scarlett);
            man.RemoveWife(scarlett);
            Assert.IsFalse(man.HasMarried(scarlett));
            Assert.IsFalse(man.HasMarried(catherine));

            man.AddWife(scarlett);
            man.AddWife(catherine);
            man.RemoveWife(scarlett);
            Assert.IsFalse(man.HasMarried(scarlett));
            Assert.IsTrue(man.HasMarried(catherine));

        } // RemoveWifeTest


        /// <summary>
        ///A test for checking couple interchange works properly
        ///</summary>
        [TestMethod()]
        public void ChangeCouplesTest()
        {

            Man man = new Man("Pablo");
            Man newMan = new Man("Paco");
            Woman scarlett = new Woman("Scarlett");
            Woman catherine = new Woman("Catherine");

            man.AddWife(scarlett);
            newMan.AddWife(catherine);

            // Couples are established properly
            Assert.IsTrue(man.HasMarried(scarlett));
            Assert.IsTrue(newMan.HasMarried(catherine));
            Assert.IsTrue(scarlett.HasMarried(man));
            Assert.IsTrue(catherine.HasMarried(newMan));

            man.AddWife(catherine);
            newMan.AddWife(scarlett);

            // Couples are rearranged
            Assert.IsTrue(man.HasMarried(catherine));
            Assert.IsTrue(newMan.HasMarried(scarlett));
            Assert.IsTrue(scarlett.HasMarried(newMan));
            Assert.IsTrue(catherine.HasMarried(man));

        } // ChangeCouplesTest
    }
}
