namespace FizzBuzzter
{
    /// <summary>
    ///     A wrapper around a divisor to use, and the word to output when a line number is divisible by the divisor.
    /// </summary>
    /// <param name="Divisor"></param>
    /// <param name="Word"></param>
    public record DivisorWord(int Divisor, string Word)
    {
        public void Deconstruct(out int divisor, out string word)
        {
            divisor = Divisor;
            word = Word;
        }
    }
}
