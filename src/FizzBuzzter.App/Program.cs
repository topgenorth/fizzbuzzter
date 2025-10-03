using FizzBuzzter;

// TODO [TO20251003] Add command line parsing to allow user to specify start, end, and perhaps even the word pairs?
const int START = 1;
const int END = 105;
IFizzBuzzter fizzBuzzter = new BasicFizzBuzzter([
    new DivisorWord(3, "Tom"),
    new DivisorWord(5, "Opgenorth"),
    new DivisorWord(7, "(Master Corporal, Ret)")
]);
IEnumerable<FizzBuzzLine> theLines = fizzBuzzter.GetLines(START, END);

foreach (FizzBuzzLine line in theLines)
{
    Console.WriteLine(line);
}
