namespace FizzBuzzter
{
    /// <summary>
    ///     The public interface for handling FizzBuzzter logic.
    /// </summary>
    public interface IFizzBuzzterHandler
    {
        /// <summary>
        ///     Will take the line number, and an optional accumulator string, and return either the accumulator string (if not
        ///     empty) or the line number as a string.
        /// </summary>
        /// <param name="lineNumber">The line number to process. Must be at least 1, and no greater than int.MaxValue</param>
        /// <param name="acc">An accumulator variable that holds the result of any previous handler.</param>
        /// <returns></returns>
        string Handle(int lineNumber, string acc = "");
    }
}
