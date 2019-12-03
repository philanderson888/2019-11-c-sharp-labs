using System;
using NUnit.Framework;
using Lab_08_TDD_Collections;
using Lab_09_Rabbit_Test;
using Lab_17_Northwind_Tests_Code_First;
using Lab_14_LINQ;
using Lab_20_Northwind_Products;

namespace NUnit_Tests
{
    [TestFixture]
    class NUnit_Tests
    {
        #region Setup
        // annotations
        [SetUp]
        public void Setup()
        {
            // eg get data from database for all tests
        }
        #endregion

        #region ArrayListDictionaryGetTotal
        [TestCase(1,2,3,4,5,280)]
        [TestCase(1,4,9,16,25,1604)]
        [TestCase(10,11,12,13,14,1405)]
        public void ArrayListDictionaryGetTotal(int a, int b, int c, int d, int e, int expected)
        {
            // call method in OTHER PROJECT 
            int actual = TestCollections.ArrayListDictionaryGetTotal(a,b,c,d,e);
            // get answer
            // see if answer is correct or not 
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region TestRabbitGrowth
        [TestCase(3,7,8)]
        public void RabbitGrowthTests(int totalYears,int expectedRabbitAge,int expectedRabbitCount)
        {
            // Arrange

            // Act
            // Tuple (int NAME,int NAME)
            (int actualCumulativeAge,int actualRabbitCount) = Rabbit_Collection.MultiplyRabbits(totalYears);

            // Assert
            Assert.AreEqual(expectedRabbitAge,actualCumulativeAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }
        #endregion

        #region TestRabbitGrowthWhereItDoesNotBeginUntilThreeYearsAgeReached
        [TestCase(3, 3,1)]
        [TestCase(4, 4,2)]
        [TestCase(5, 6, 3)]
        [TestCase(6, 9, 4)]
        public void RabbitGrowthAfterThreeYears
            (int totalYears, int expectedRabbitAge, 
                                   int expectedRabbitCount)
        {
            // Arrange

            // Act
            // Tuple (int NAME,int NAME)
            (int actualCumulativeAge, int actualRabbitCount) = 
                     Rabbit_Collection.MultiplyRabbitsAfterAgeThreeReached (totalYears);

            // Assert
            Assert.AreEqual(expectedRabbitAge, actualCumulativeAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }
        #endregion

        #region TestNumberOfNorthwindCustomers
        /* Create a class to read in Northwind customers and return the total
         * Then repeat for just London customers
         * */
        [TestCase(null,91)]    // how many customers total?
        [TestCase("London",6)] // how many customers in London?
        [TestCase("Berlin",1)]  // how many in berlin
        public void TestNumberOfNorthwindCustomers(string city,int expected)
        {
            // arrange
            var testInstance = new Lab_14_LINQ.NorthwindCustomers();
            // act
            var actual = testInstance.NumberOfNorthwindCustomers(city);
            // assert
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region TestNumberOfProductsStartingWithAndContainingAParticularLetter
        [TestCase(3)]
        public void TestNumberOfProductsStartingWithP(int expected)
        {
            // arrange (instance)
            var instance = new NorthwindProductTest();
            // act (method)
            var actual = instance.TestNumberOfProductsStartingWithP();
            // assert 
            Assert.AreEqual(expected, actual);
        }
        [TestCase("p",3)]
        public void TestNumberOfProductsStartingWithALetter(string letter, int expected)
        {
            // arrange (instance)
            var instance = new NorthwindProductTest();
            // act (method)
            var actual = instance.TestNumberOfProductsStartingWithALetter(letter);
            // assert 
            Assert.AreEqual(expected, actual);
        }

        [TestCase("p", 17)]
        [TestCase("a", 58)]
        [TestCase("d", 30)]
        public void TestNumberOfProductsContainingALetter(string letter, int expected)
        {
            // arrange (instance)
            var instance = new NorthwindProductTest();
            // act (method)
            var actual = instance.TestNumberOfProductsContainingALetter(letter);
            // assert 
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
