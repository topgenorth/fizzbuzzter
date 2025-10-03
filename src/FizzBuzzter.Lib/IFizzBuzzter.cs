namespace FizzBuzzter
{
    /// <summary>
    ///     Public interface for the FizzBuzz.
    /// </summary>
    public interface IFizzBuzzter
    {
        /// <summary>
        ///     Returns a collection of lines from min to max, inclusive.
        /// </summary>
        /// <param name="min">Must be at least 1.</param>
        /// <param name="max">Cannot be greater than int.MaxValue</param>
        /// <returns></returns>
        IEnumerable<FizzBuzzLine> GetLines(int min, int max);
    }
}
