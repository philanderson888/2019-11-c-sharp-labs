using System;
using NUnit.Framework;
using Lab_08_TDD_Collections;
using Lab_09_Rabbit_Test;

namespace NUnit_Tests
{
    [TestFixture]
    class NUnit_Tests
    {
        // annotations
        [SetUp]
        public void Setup()
        {
            // eg get data from database for all tests
        }

        [Test]
        public void RunThisTest()
        {
            // Arrange (data)

            // Act (run test)

            // Assert (true/false ie pass/fail)
            Assert.AreEqual(true, true);
        }

        [TestCase(10,11,22,21,19,83)]
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
        [TestCase(3, -1,-1)]
        [TestCase(4, -1,-1)]
        [TestCase(5, -1,-1)]
        [TestCase(6, -1,-1)]
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
    }
}
