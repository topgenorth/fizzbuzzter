namespace FizzBuzzter
{
    public record FizzBuzzLine
    {
        public FizzBuzzLine(long index, string value) : this((int)index, value)
        {
            if (index is < int.MinValue or > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(index),
                    "Index must be within the range of a 32-bit integer.");
            }
        }

        public FizzBuzzLine(int index, string value)
        {
            Index = index;
            Value = value;
        }

        public int Index { get; }
        public string Value { get; }

        public override int GetHashCode() => HashCode.Combine(Index, Value);

        public static implicit operator string(FizzBuzzLine line) => line.ToString();

        public override string ToString()
        {
            if (string.IsNullOrWhiteSpace(Value))
            {
                return Index.ToString();
            }

            return Value;
        }
    }
}
