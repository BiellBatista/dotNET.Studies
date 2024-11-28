namespace ValueTypes;

internal sealed class ConversoesNumericasInternas
{
    public static void Execute()
    {
        Console.WriteLine($"IntMinValue = {int.MinValue} & ShortMinValue = {unchecked((short) int.MinValue)}"); //Output: IntMinValue = -2147483648 & ShortMinValue = 0

        Console.WriteLine($"IntMinValue = {int.MinValue} & LongMinValue = {unchecked((long) int.MinValue)}"); //Output: IntMinValue = -2147483648 & LongMinValue = -2147483648
        Console.WriteLine($"IntMaxValue = {int.MaxValue} & LongMaxValue = {unchecked((long) int.MaxValue)}"); //Output: IntMaxValue = 2147483647 & LongMaxValue = 2147483647

        Console.WriteLine($"LongMinValue = {long.MinValue} & IntMinValue = {unchecked((int) long.MinValue)}"); //Output: LongMinValue = -9223372036854775808 & IntMinValue = 0
        Console.WriteLine($"LongMaxValue = {long.MaxValue} & IntMaxValue = {unchecked((int) long.MaxValue)}"); //Output: LongMaxValue = 9223372036854775807 & IntMaxValue = -1
    }
}