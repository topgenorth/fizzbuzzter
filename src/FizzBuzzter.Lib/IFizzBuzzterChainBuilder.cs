namespace FizzBuzzter
{
    /// <summary>
    ///     The building of the FizzBuzzterHandler chain is abstracted behind this interface. This interface
    ///     will allow variations in the algorithm used to build the chain.
    /// </summary>
    public interface IFizzBuzzterChainBuilder
    {
        /// <summary>
        ///     Create the FizzBuzzterHandler chain and return the head of the chain.
        /// </summary>
        /// <returns></returns>
        FizzBuzzterHandler Build();
    }
}
