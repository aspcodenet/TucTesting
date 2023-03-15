using System.Reflection.Metadata;
using TucTesting.Services;

namespace TucTesting.Tests.Services
{
    [TestClass]
    public class StringCalculatorTests
    {
        private readonly StringCalculator sut;

        public StringCalculatorTests()
        {
            sut = new StringCalculator();
        }

        //[TestMethod]
        //public void When_passing_letter()
        //{
        //    var parameter = "5";

        //    var result = sut.Add(parameter);

        //    Assert.AreEqual(5, result);
        //}


        [TestMethod]
        public void When_passing_single_number_should_return_the_number()
        {
            var parameter = "5";

            var result = sut.Add(parameter);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void When_passing_multiple_numbers_should_return_the_sum()
        {
            var parameter = "5,3,6";

            var result = sut.Add(parameter);

            Assert.AreEqual(14, result);
        }

        [TestMethod]
        public void When_passing_numbers_should_ignore_larger_than_1000_and_return_the_sum()
        {
            var parameter = "5,1001,3,1008,6";

            var result = sut.Add(parameter);

            Assert.AreEqual(14, result);
        }




        [TestMethod]
        public void When_passing_empty_string_should_return_0()
        {
            var parameter = String.Empty;

            var result = sut.Add(parameter);

            Assert.AreEqual(0,result);
        }
    }
}
