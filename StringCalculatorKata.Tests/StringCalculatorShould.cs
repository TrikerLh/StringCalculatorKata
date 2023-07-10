using FluentAssertions;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorShould
    {
        private StringCalculator stringCalculator;
        [SetUp]
        public void Setup()
        {
            stringCalculator = new StringCalculator();
        }

        [Test]
        public void Return_0_when_string_is_empty()
        {
            var result = stringCalculator.Add("");

            result.Should().Be(0);
        }

        [TestCase("1",1)]
        [TestCase("2", 2)]
        [TestCase("50", 50)]
        public void Return_the_same_number(string numbers, int expected)
        {
            var result = stringCalculator.Add(numbers);

            result.Should().Be(expected);
        }

        [Test]
        public void Return_10_with_numbers_5_and_5()
        {
            var result = stringCalculator.Add("5,5");

            result.Should().Be(10);
        }

        [Test]
        public void Return_10_with_numbers_6_and_4()
        {
            var result = stringCalculator.Add("6,4");

            result.Should().Be(10);
        }

        [TestCase("5,5", 10)]
        [TestCase("6,4", 10)]
        [TestCase("50,20", 70)]
        public void Return_add_with_two_number(string numbers, int expected)
        {
            var result = stringCalculator.Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4", 10)]
        [TestCase("1,2,3,4,10", 20)]
        public void Return_add_whit_some_numbers(string numbers, int expected)
        {
            var result = stringCalculator.Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("10\n23\n37", 70)]
        [TestCase("96,58\n37", 191)]
        public void Return_add_whit_return_separator(string numbers, int expected)
        {
            var result = stringCalculator.Add(numbers);
            
            result.Should().Be(expected);
        }

        [Test]
        public void Return_3()
        {
            var result = stringCalculator.Add("//;\n1;2");

            result.Should().Be(3);
        }

        [Test]
        public void Return_4()
        {
            var result = stringCalculator.Add("//;\n1;3");

            result.Should().Be(4);
        }
    }
}