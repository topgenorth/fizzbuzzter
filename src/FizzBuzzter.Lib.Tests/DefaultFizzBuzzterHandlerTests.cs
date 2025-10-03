using Shouldly;

namespace FizzBuzzter
{
    public class DefaultFizzBuzzterHandlerTests
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(int.MaxValue, "2147483647")]
        public void Handle_should_return_value_as_a_string(int value, string expected)
        {
            FizzBuzzterHandler handler = new DefaultFizzBuzzterHandler();
            string result = handler.Handle(value);
            result.ShouldBe(expected);
        }
    }
}
