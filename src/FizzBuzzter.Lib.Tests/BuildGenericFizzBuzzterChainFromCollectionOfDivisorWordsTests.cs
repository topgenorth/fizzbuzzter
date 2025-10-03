using Shouldly;

namespace FizzBuzzter
{
    public class BuildGenericFizzBuzzterChainFromCollectionOfDivisorWordsTests
    {
        [Fact]
        public void Should_have_only_DefaultFizzBuzzterHandler_when_no_DivisorWords()
        {
            BuildGenericFizzBuzzterChainFromCollectionOfDivisorWords builder = new([]);
            FizzBuzzterHandler handler = builder.Build();

            handler.ShouldBeOfType<DefaultFizzBuzzterHandler>();
            handler.Next.ShouldBeNull();
        }

        [Fact]
        public void Should_build_a_chain_with_correct_number_of_handlers()
        {
            BuildGenericFizzBuzzterChainFromCollectionOfDivisorWords builder = new([
                new DivisorWord(3, "Fizz"),
                new DivisorWord(5, "Buzz"),
                new DivisorWord(7, "Fazz"),
                new DivisorWord(11, "Bizz")
            ]);
            FizzBuzzterHandler handler = builder.Build();

            // [TO20251003] Don't like so many asserts in one test, but good enough for now.
            handler.ShouldBeOfType<GenericFizzBuzzterHandler>();
            handler.ShouldHaveChainLength(5); // 4 Generic + 1 Default
        }
    }
}
