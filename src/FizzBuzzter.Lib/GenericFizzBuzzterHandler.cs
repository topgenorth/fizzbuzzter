namespace FizzBuzzter
{
    /// <summary>
    ///     This implementation of FizzBuzzterHandler is fairly generic and basic.  Take line number,
    ///     and if that is a multiple of Divisor, append Word to the accumulator. Call the next handler in the chain.
    /// </summary>
    public class GenericFizzBuzzterHandler : FizzBuzzterHandler
    {
        public GenericFizzBuzzterHandler(DivisorWord divisorWord)
        {
            (Divisor, Word) = divisorWord;
        }

        public GenericFizzBuzzterHandler(long divisor, string word)
        {
            Divisor = divisor;
            Word = word;
        }

        internal long Divisor { get; }
        internal string Word { get; }

        public override string ToString() => $"{Divisor}:{Word}";

        protected internal override string HandleInternal(long number, string acc = "")
        {
            if (number % Divisor == 0)
            {
                // [TO20251003] Note the space before {Word} to separate it from any previous words in acc.
                acc += $" {Word}";
            }

            // [TO20251003] Trim any leading/trailing spaces from acc before passing it on, otherwise too many spaces.
            string trimmedAcc = acc.Trim();
            return Next?.HandleInternal(number, trimmedAcc) ?? trimmedAcc;
        }
    }
}
