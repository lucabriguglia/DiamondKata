using NUnit.Framework;

namespace DiamondKata.Tests
{
    [TestFixture]
    public class DiamondTests
    {
        [TestCase("")]
        [TestCase("AB")]
        public void Should_return_error_if_input_length_is_different_from_one(string input)
        {
            var sut = new Diamond();

            var actual = sut.Create(input);

            Assert.AreEqual(Messages.InputNotValid, actual);
        }

        [TestCase("a")]
        [TestCase("z")]
        public void Should_return_error_if_input_is_lower_case(string input)
        {
            var sut = new Diamond();

            var actual = sut.Create(input);

            Assert.AreEqual(Messages.InputNotValid, actual);
        }

        [TestCase("1")]
        [TestCase("!")]
        public void Should_return_an_error_message_if_input_is_not_a_letter(string input)
        {
            var sut = new Diamond();

            var actual = sut.Create(input);

            Assert.AreEqual(Messages.InputNotValid, actual);
        }

        [Test]
        public void A_Should_return_A()
        {
            var sut = new Diamond();

            var actual = sut.Create("A");

            Assert.AreEqual("A", actual);
        }

        [TestCase("A")]
        [TestCase("B")]
        [TestCase("T")]
        public void Should_return_the_correct_number_of_lines(string input)
        {
            var sut = new Diamond();

            var actual = sut.Create(input);

            var lines = actual.Split('\n');

            var expectedLength = (input[0] - 'A') * 2 + 1;

            Assert.AreEqual(expectedLength, lines.Length);
        }

        [TestCase("A")]
        [TestCase("D")]
        [TestCase("Y")]
        [TestCase("Z")]
        public void Any_letters_other_than_A_should_return_a_line_with_identical_value(string input)
        {
            var sut = new Diamond();

            var actual = sut.Create(input);
            var targetLetter = input[0];
            var length = (targetLetter - 'A') * 2 + 1;
            var lines = actual.Split('\n');
            
            foreach (var line in lines)
            {
                var letter = line.First(x => x != ' ');
                var padding = new string(' ', targetLetter - letter);

                if (letter == 'A')
                {
                    Assert.AreEqual($"{padding}A{padding}", line);
                }
                else
                {
                    var insidePadding = new string(' ', length - (targetLetter - letter) * 2 - 2);
                    Assert.AreEqual($"{padding}{letter}{insidePadding}{letter}{padding}", line);
                }
            }
        }
    }
}