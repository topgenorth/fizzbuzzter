using Shouldly;

namespace FizzBuzzter
{
    static class FizzBuzzterTestExtensions
    {
        /// <summary>
        ///     Counts the number of links in the chain of responsibility, starting with the given handler.
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="expectedLength"></param>
        public static void ShouldHaveChainLength(this FizzBuzzterHandler handler, int expectedLength)
        {
            int numberOfLinksInChain = 1; // [TO20251003] The handler counts as the first link in the chain.
            FizzBuzzterHandler current = handler.Next;
            while (current != null)
            {
                numberOfLinksInChain++;
                current = current.Next;
            }

            numberOfLinksInChain.ShouldBe(expectedLength);
        }

        public static void ShouldBeGenericFizzBuzzterHandler(this FizzBuzzterHandler? handler,
            int expectedDivisor,
            string expectedWord)
        {
            handler.ShouldNotBeNull();
            handler.ShouldBeOfType<GenericFizzBuzzterHandler>();
            GenericFizzBuzzterHandler genericHandler = (GenericFizzBuzzterHandler)handler;
            genericHandler.Divisor.ShouldBe(expectedDivisor);
            genericHandler.Word.ShouldBe(expectedWord);
        }
    }
}
