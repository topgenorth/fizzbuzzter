using Shouldly;

namespace FizzBuzzter
{
    public class GenericFizzBuzzterHandlerTests
    {
        [Theory]
        [InlineData(3, "Tom", 3, "Tom")]
        [InlineData(5, "Opgenorth", 1, "")]
        [InlineData(5, "Opgenorth", 5, "Opgenorth")]
        [InlineData(7, "Opgenorth", int.MaxValue, "")]
        [InlineData(7, "Big number!", int.MaxValue, "")]
        // [TO20251002] int.MaxValue is a prime number - so we can only divide it by itself.
        [InlineData(int.MaxValue, "Big number!", int.MaxValue, "Big number!")]
        public void Handle_should_return_expected_value(int divisor, string word, int number, string expected)
        {
            FizzBuzzterHandler handler = new GenericFizzBuzzterHandler(divisor, word);
            string result = handler.Handle(number);
            result.ShouldBe(expected);
        }
    }
}
