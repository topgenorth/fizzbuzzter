namespace FizzBuzzter
{
    public class DefaultFizzBuzzterHandler : FizzBuzzterHandler
    {
        protected internal override string HandleInternal(long number, string acc = "") =>
            string.IsNullOrEmpty(acc) ? number.ToString() : acc;
    }
}
