using NSubstitute;
using Shouldly;

namespace FizzBuzzter
{
    public class BasicFizzBuzzterTests
    {
        [Fact]
        public void GetLines_should_throw_Exception_when_starting_with_less_than_1()
        {
            IFizzBuzzterChainBuilder fizzBuzzterChainBuilder = Substitute.For<IFizzBuzzterChainBuilder>();
            BasicFizzBuzzter x = new(fizzBuzzterChainBuilder);
            Should.Throw<ArgumentOutOfRangeException>(() => x.GetLines(0, 10).ToArray());
        }

        [Fact]
        public void GetLines_should_throw_Exception_when_start_is_greater_than_end()
        {
            IFizzBuzzterChainBuilder fizzBuzzterChainBuilder = Substitute.For<IFizzBuzzterChainBuilder>();
            BasicFizzBuzzter x = new(fizzBuzzterChainBuilder);
            Should.Throw<ArgumentOutOfRangeException>(() => x.GetLines(11, 10).ToArray());
        }

        [Theory]
        [MemberData(nameof(LinesToFizzBuzzAndTheExpectedResult.GetTestParams),
            MemberType = typeof(LinesToFizzBuzzAndTheExpectedResult))]
        public void Should_return_expected_results_for_1_to_15(int index, string value)
        {
            // [TO20251002] TODO This is brittle test because it depends on BuildFizzBuzzterHandlerFromCollectionOfDivisorWords
            // working correctly.  A better test would be to use a mock IFizzBuzzterHandlerBuilder, or write a test-specific
            // implementation of IFizzBuzzterHandlerBuilder that returns a known FizzBuzzterHandler
            IFizzBuzzterChainBuilder fizzBuzzterChainBuilder =
                new BuildGenericFizzBuzzterChainFromCollectionOfDivisorWords([
                    new DivisorWord(3, "Tom"), new DivisorWord(5, "Opgenorth")
                ]);
            BasicFizzBuzzter x = new(fizzBuzzterChainBuilder);
            FizzBuzzLine[] lines = x.GetLines(1, 15).ToArray();
            lines[index - 1].ToString().ShouldBe(value);
        }

        class LinesToFizzBuzzAndTheExpectedResult
        {
            public static IEnumerable<object[]> GetTestParams() => new List<object[]>
            {
                new object[] { 1, "1" },
                new object[] { 3, "Tom" },
                new object[] { 5, "Opgenorth" },
                new object[] { 6, "Tom" },
                new object[] { 9, "Tom" },
                new object[] { 10, "Opgenorth" },
                new object[] { 12, "Tom" },
                new object[] { 15, "Tom Opgenorth" }
            };
        }
    }
}
