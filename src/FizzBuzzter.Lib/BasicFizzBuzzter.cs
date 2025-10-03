namespace FizzBuzzter
{
    /// <summary>
    ///     Basic implementation of a FizzBuzzter, which will return lines from min to max, inclusive.
    /// </summary>
    public class BasicFizzBuzzter : IFizzBuzzter
    {
        // [TO20251003] IFizzBuzzterHandler should be sufficient here, but needs to be a concrete type to call HandleInternal.
        readonly IFizzBuzzterHandler _fizzBuzzters;

        /// <summary>
        ///     Simple constructor that will take a pre-built handler chain.
        /// </summary>
        /// <param name="fizzBuzzters"></param>
        public BasicFizzBuzzter(IFizzBuzzterHandler fizzBuzzters)
        {
            _fizzBuzzters = fizzBuzzters;
        }

        /// <summary>
        ///     Another constructor that will take a custom IFizzBuzzterHandlerBuilder to build the handler chain.
        /// </summary>
        /// <param name="builder"></param>
        public BasicFizzBuzzter(IFizzBuzzterChainBuilder builder)
        {
            _fizzBuzzters = builder.Build();
        }

        /// <summary>
        ///     A constructor that will take an array of DivisorWord pairs to build the handler chain.
        /// </summary>
        /// <param name="divisorWords"></param>
        public BasicFizzBuzzter(DivisorWord[] divisorWords)
            : this(new BuildGenericFizzBuzzterChainFromCollectionOfDivisorWords(divisorWords))
        {
        }

        public IEnumerable<FizzBuzzLine> GetLines(int min, int max)
        {
            // TODO [TO20251003] Could inject a validator to allow for custom rules.
            AssertInputsAreValid(min, max);

            for (long lineNumber = min; lineNumber <= max; lineNumber++)
            {
                // [TO20251003] Flagrant LSP violation here, but by calling HandleInternal directly we
                // avoid having to cast/convert the long to an int. For the purposes of this exercise, I'd say it's
                // a fair trade-off.
                string val = ((FizzBuzzterHandler)_fizzBuzzters).HandleInternal(lineNumber);

                yield return new FizzBuzzLine(lineNumber, val);
            }
        }

        /// <summary>
        ///     Basic validation of inputs.  We must stick to natural numbers within the range of int.MaxValue.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        static void AssertInputsAreValid(long min, long max)
        {
            if (min > max)
            {
                throw new ArgumentOutOfRangeException(nameof(min), "Min must be less than or equal to max.");
            }

            if (min < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(min), "Min must be greater than or equal to 1.");
            }
        }
    }
}
