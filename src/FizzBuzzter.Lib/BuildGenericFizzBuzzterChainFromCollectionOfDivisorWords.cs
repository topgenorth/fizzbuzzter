namespace FizzBuzzter
{
    /// <summary>
    ///     Takes an array of work pairs, and will build a FizzBuzzterHandler chain from them.
    /// </summary>
    /// <remarks>A facade around BuildFizzBuzzterHandlersIncrementally.</remarks>
    public class BuildGenericFizzBuzzterChainFromCollectionOfDivisorWords : IFizzBuzzterChainBuilder
    {
        readonly DivisorWord[] _divisorWords;

        public BuildGenericFizzBuzzterChainFromCollectionOfDivisorWords(DivisorWord[] divisorWords)
        {
            _divisorWords = divisorWords;
        }

        public FizzBuzzterHandler Build()
        {
            BuildFizzBuzzterChainIncrementally builder = new();
            foreach (DivisorWord wordPair in _divisorWords)
            {
                builder.CreateHandlerFor(wordPair);
            }

            return builder.Build();
        }
    }
}
