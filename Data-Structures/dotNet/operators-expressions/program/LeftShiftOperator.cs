namespace OperatorsExpressions;

internal sealed class LeftShiftOperator
{
    public static void Execute()
    {
        Console.WriteLine("-----------");
        Console.WriteLine($"Inteiro 55 -> Binário: {Convert.ToString(55, 2)}"); //Output: Inteiro 55 -> Binário: 110111
        Console.WriteLine($"Inteiro 55 -> Binário: {Convert.ToString(55, 2)} -> << 3: {Convert.ToString(55<<3, 2)} -> Inteiro deslocamento << 3 -> {55<<3}"); //Output: Inteiro 55 -> Binário: 110111 -> << 3: 110111000 -> Inteiro deslocamento << 3 -> 440
    }
}