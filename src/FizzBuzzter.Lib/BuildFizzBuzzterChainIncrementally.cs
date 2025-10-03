namespace FizzBuzzter
{
    /// <summary>
    ///     This builder is handy for simple scenarios, building a handler chain of only a few handlers. This builder
    ///     will use the GenericFizzBuzzterHandler for each divisor/word pair added to the chain, and will terminate with
    ///     a DefaultFizzBuzzterHandler.
    /// </summary>
    public class BuildFizzBuzzterChainIncrementally : IFizzBuzzterChainBuilder
    {
        FizzBuzzterHandler _head;
        FizzBuzzterHandler _tail;

        public FizzBuzzterHandler Build()
        {
            // [TO20251002] Always end with the DefaultHandler to handle non-matching cases
            DefaultFizzBuzzterHandler defaultFizzBuzzterHandler = new();

            if (_head == null)
            {
                _head = defaultFizzBuzzterHandler;
                _tail = defaultFizzBuzzterHandler;
            }
            else
            {
                _tail.SetNext(defaultFizzBuzzterHandler);
                _tail = defaultFizzBuzzterHandler;
            }

            return _head;
        }

        /// <summary>
        /// This implementation will create a GenericFizzBuzzterHandler for  divisor/word pair.
        /// </summary>
        /// <param name="divisorWord"></param>
        /// <returns></returns>
        public BuildFizzBuzzterChainIncrementally CreateHandlerFor(int divisor, string word) =>
            CreateHandlerFor(new DivisorWord(divisor, word));

        /// <summary>
        /// This implementation will create a GenericFizzBuzzterHandler for the given DivisorWord,
        /// and append it to the end of the chain.
        /// </summary>
        /// <param name="divisorWord"></param>
        /// <returns></returns>
        public BuildFizzBuzzterChainIncrementally CreateHandlerFor(DivisorWord divisorWord)
        {
            GenericFizzBuzzterHandler newBuzzterHandler = new(divisorWord.Divisor, divisorWord.Word);
            if (_head == null)
            {
                // [TO20251003] First time: Both the tail and the head are the same handler.
                _head = newBuzzterHandler;
                _tail = newBuzzterHandler;
            }
            else
            {
                // [TO20251003] Subsequent invocations: Append to the tail, and leave the _head alone.
                _tail.SetNext(newBuzzterHandler);
                _tail = newBuzzterHandler;
            }

            return this;
        }
    }
}
