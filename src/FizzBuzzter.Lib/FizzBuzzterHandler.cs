#nullable enable
namespace FizzBuzzter
{
    /// <summary>
    ///     A linked list of handlers that will be called in order to generate the FizzBuzzter output.
    ///     Each handler can either handle the input or pass it to the next handler in the chain.
    /// </summary>
    public abstract class FizzBuzzterHandler : IFizzBuzzterHandler
    {
        /// <summary>
        ///     The next a handler in the chain. If this is null, then the end of the chain has been reached.
        /// </summary>
        protected internal FizzBuzzterHandler? Next { get; private set; }


        public string Handle(int lineNumber, string acc = "") => HandleInternal(lineNumber, acc);

        public FizzBuzzterHandler SetNext(FizzBuzzterHandler next)
        {
            Next = next;

            return next;
        }

        /// <summary>
        ///     This has to be implemented by derived classes. Uses a long to mitigate chances of an overflow from int operations.
        /// </summary>
        /// <param name="lineNumber"></param>
        /// <param name="acc"></param>
        /// <returns></returns>
        protected internal abstract string HandleInternal(long lineNumber, string acc = "");
    }
}
