using Core.StoreExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests.StoreExample
{
    
    
    /// <summary>
    ///This is a test class for DiscountCalculatorTest and is intended
    ///to contain all DiscountCalculatorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class DiscountCalculatorTest
    {

        private DiscountCalculator _calculator = new DiscountCalculator();
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
        ///A test for CalculateDiscountPercentage
        ///</summary>
        [TestMethod()]
        public void Return15PercentageForNewCustomer()
        {
            Customer customer = new Customer();
            var discount = _calculator.CalculateDiscountPercentage(customer);
            Assert.AreEqual(0.15m, discount);
        }

        [TestMethod()]
        public void Return5PercentSenior()
        {
            Customer customer = new Customer() { DateOfBirth = DateTime.Now.AddYears(-65).AddMonths(-5)
                , DateOfFirstPurchase = DateTime.Now.AddMonths(-2) };
            var discount = _calculator.CalculateDiscountPercentage(customer);
            Assert.AreEqual(0.05m, discount);
        }

        [TestMethod()]
        public void Return12PctFor5YearsLoyalCustomer()
        {
            Customer customer = new Customer()
            {
                DateOfBirth = DateTime.Now.AddDays(-5),
                DateOfFirstPurchase = DateTime.Today.AddYears(-5)
            };
            var discount = _calculator.CalculateDiscountPercentage(customer);
            Assert.AreEqual(0.12m, discount);
        }

        [TestMethod()]
        public void Return22PctFor5YearsLoyalCustomerOnBirthDay()
        {
            Customer customer = new Customer()
            {
                DateOfBirth = DateTime.Today,
                DateOfFirstPurchase = DateTime.Today.AddYears(-5)
            };
            var discount = _calculator.CalculateDiscountPercentage(customer);
            Assert.AreEqual(0.22m, discount);
        }
    }
}
