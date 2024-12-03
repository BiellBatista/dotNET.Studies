namespace ValueTypes;

internal sealed class ConversoesNumericasInternas
{
    public static void Execute()
    {
        Console.WriteLine($"IntMinValue = {int.MinValue} -> Short = {unchecked((short) int.MinValue)}"); //Output: IntMinValue = -2147483648 -> Short = 0

        Console.WriteLine($"IntMinValue = {int.MinValue} -> Long = {unchecked((long) int.MinValue)}"); //Output: IntMinValue = -2147483648 -> Long = -2147483648
        Console.WriteLine($"IntMaxValue = {int.MaxValue} -> Long = {unchecked((long) int.MaxValue)}"); //Output: IntMaxValue = 2147483647 -> Long = 2147483647
        Console.WriteLine($"IntMinValue = {int.MinValue} -> Float = {unchecked((float) int.MinValue)}"); //Output: IntMinValue = -2147483648 -> Float = -2,1474836E+09
        Console.WriteLine($"IntMaxValue = {int.MaxValue} -> Double = {unchecked((double) int.MaxValue)}"); //Output: IntMaxValue = 2147483647 -> Double = 2147483647

        Console.WriteLine($"LongMinValue = {long.MinValue} -> Int = {unchecked((int) long.MinValue)}"); //Output: LongMinValue = -9223372036854775808 -> Int = 0
        Console.WriteLine($"LongMaxValue = {long.MaxValue} -> Int = {unchecked((int) long.MaxValue)}"); //Output: LongMaxValue = 9223372036854775807 -> Int = -1
        Console.WriteLine($"LongMinValue = {long.MinValue} -> Float = {unchecked((float) long.MinValue)}"); //Output: LongMinValue = -9223372036854775808 -> Float = -9,223372E+18
        Console.WriteLine($"LongMaxValue = {long.MaxValue} -> Double = {unchecked((double) long.MaxValue)}"); //Output: LongMaxValue = 9223372036854775807 -> Double = 9,223372036854776E+18

        Console.WriteLine($"FloatMinValue = {float.MinValue} -> Short = {unchecked((short) float.MinValue)}"); //Output: FloatMinValue = -3,4028235E+38 -> Short = 0
        Console.WriteLine($"FloatMinValue = {float.MinValue} -> Int = {unchecked((int) float.MinValue)}"); //Output: FloatMinValue = -3,4028235E+38 -> Int = 0
        Console.WriteLine($"FloatMinValue = {float.MinValue} -> Long = {unchecked((long) float.MinValue)}"); //Output: FloatMinValue = -3,4028235E+38 -> Long = 0
        Console.WriteLine($"FloatMinValue = {float.MinValue} -> Double = {unchecked((double) float.MinValue)}"); //Output: FloatMinValue = -3,4028235E+38 -> Double = -3,4028234663852886E+38

        Console.WriteLine($"FloatMaxValue = {float.MaxValue} -> Short = {unchecked((short) float.MaxValue)}"); //Output: FloatMaxValue = 3,4028235E+38 -> Short = 0
        Console.WriteLine($"FloatMaxValue = {float.MaxValue} -> Int = {unchecked((int) float.MaxValue)}"); //Output: FloatMaxValue = 3,4028235E+38 -> Int = 0
        Console.WriteLine($"FloatMaxValue = {float.MaxValue} -> Long = {unchecked((long) float.MaxValue)}"); //Output: FloatMaxValue = 3,4028235E+38 -> Long = 0
        Console.WriteLine($"FloatMaxValue = {float.MaxValue} -> Double = {unchecked((double) float.MaxValue)}"); //Output: FloatMaxValue = 3,4028235E+38 -> Double = 3,4028234663852886E+38

        Console.WriteLine($"DoubleMinValue = {double.MinValue} -> Short = {unchecked((short) double.MinValue)}"); //Output: DoubleMinValue = -1,7976931348623157E+308 -> Short = 0
        Console.WriteLine($"DoubleMinValue = {double.MinValue} -> Int = {unchecked((int) double.MinValue)}"); //Output: DoubleMinValue = -1,7976931348623157E+308 -> Int = 0
        Console.WriteLine($"DoubleMinValue = {double.MinValue} -> Long = {unchecked((long) double.MinValue)}"); //Output: DoubleMinValue = -1,7976931348623157E+308 -> Long = 0
        Console.WriteLine($"DoubleMinValue = {double.MinValue} -> Float = {unchecked((float) double.MinValue)}"); //Output: DoubleMinValue = -1,7976931348623157E+308 -> Float = -∞

        Console.WriteLine($"DoubleMaxValue = {double.MaxValue} -> Short = {unchecked((short) double.MaxValue)}"); //Output: DoubleMaxValue = 1,7976931348623157E+308 -> Short = 0
        Console.WriteLine($"DoubleMaxValue = {double.MaxValue} -> Int = {unchecked((int) double.MaxValue)}"); //Output: DoubleMaxValue = 1,7976931348623157E+308 -> Int = 0
        Console.WriteLine($"DoubleMaxValue = {double.MaxValue} -> Long = {unchecked((long) double.MaxValue)}"); //Output: DoubleMaxValue = 1,7976931348623157E+308 -> Long = 0
        Console.WriteLine($"DoubleMaxValue = {double.MaxValue} -> Float = {unchecked((float) double.MaxValue)}"); //Output: DoubleMaxValue = 1,7976931348623157E+308 -> Float = ∞

        Console.WriteLine($"Float = {1.556F} -> Short = {unchecked((short) 1.556F)}"); //Output: Float = 1,556 -> Short = 1
        Console.WriteLine($"Double = {1.456D} -> Short = {unchecked((short) 1.456D)}"); //Output: Double = 1,456 -> Short = 1
        Console.WriteLine($"Decimal = {1.756M} -> Short = {unchecked((short) 1.756M)}"); //Output: Decimal = 1,756 -> Short = 1

        Console.WriteLine($"Float = {1.556F} -> Int = {unchecked((int) 1.556F)}"); //Output: Float = 1,556 -> Int = 1
        Console.WriteLine($"Double = {1.456D} -> Int = {unchecked((int) 1.456D)}"); //Output: Double = 1,456 -> Int = 1
        Console.WriteLine($"Decimal = {1.756M} -> Int = {unchecked((int) 1.756M)}"); //Output: Decimal = 1,756 -> Int = 1

        Console.WriteLine($"Float = {1.556F} -> Long = {unchecked((long) 1.556F)}"); //Output: Float = 1,556 -> Long = 1
        Console.WriteLine($"Double = {1.456D} -> Long = {unchecked((long) 1.456D)}"); //Output: Double = 1,456 -> Long = 1
        Console.WriteLine($"Decimal = {-1.756M} -> Long = {unchecked((long) -1.756M)}"); //Output: Decimal = -1,756 -> Long = -1

        Console.WriteLine($"Float = {1.556F} -> Double = {unchecked((double) 1.556F)}"); //Output: Float = 1,556 -> Double = 1,555999994277954
        Console.WriteLine($"Double = {1.456D} -> Decimal = {unchecked((decimal) 1.456D)}"); //Output: Double = 1,456 -> Decimal = 1,456
        Console.WriteLine($"Decimal = {1.756M} -> Float = {unchecked((float) 1.756M)}"); //Output: Decimal = 1,756 -> Float = 1,756
    }
}