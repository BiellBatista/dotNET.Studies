namespace OperatorsExpressions;

internal sealed class BitwiseComplementOperator
{
    public static void Execute()
    {
        Console.WriteLine($"Inteiro 42 -> Binário: {Convert.ToString(42, 2)}"); //Output: Inteiro 42 -> Binário: 101010
        Console.WriteLine($"Inteiro 42 -> Binário: {Convert.ToString(42, 2)} -> Complemento: {Convert.ToString(~42, 2)} -> Inteiro Complemento -> {~42}"); //Output: Inteiro 42 -> Binário: 101010 -> Complemento: 11111111111111111111111111010101 -> Inteiro Complemento -> -43
        Console.WriteLine($"Inteiro -43 -> Binário: {Convert.ToString(-43, 2)} -> Complemento: {Convert.ToString(~-43, 2)} -> Inteiro Complemento -> {~-43}"); //Output: Inteiro -43 -> Binário: 11111111111111111111111111010101 -> Complemento: 101010 -> Inteiro Complemento -> 42
        Console.WriteLine($"Inteiro 9 -> Binário: {Convert.ToString(9, 2)} -> Complemento: {Convert.ToString(~9, 2)} -> Inteiro Complemento -> {~9}"); //Output: Inteiro 9 -> Binário: 1001 -> Complemento: 11111111111111111111111111110110 -> Inteiro Complemento -> -10
        Console.WriteLine($"Inteiro 100 -> Binário: {Convert.ToString(100, 2)} -> Complemento: {Convert.ToString(~100, 2)} -> Inteiro Complemento -> {~100}"); //Output: Inteiro 100 -> Binário: 1100100 -> Complemento: 11111111111111111111111110011011 -> Inteiro Complemento -> -101
        Console.WriteLine($"Inteiro 100 -> Binário: {Convert.ToString(100, 2)} -> Complemento do Complemento: {Convert.ToString(~~100, 2)} -> Inteiro Complemento do Complemento -> {~~100}"); //Output: Inteiro 100 -> Binário: 1100100 -> Complemento do Complemento: 1100100 -> Inteiro Complemento do Complemento -> 100
    }
}