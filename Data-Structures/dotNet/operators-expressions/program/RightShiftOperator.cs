namespace OperatorsExpressions;

internal sealed class RightShiftOperator
{
    public static void Execute()
    {
        Console.WriteLine("-----------");
        uint number = 55;

        Console.WriteLine($"Inteiro 55 -> Binário: {Convert.ToString(55, 2)}"); //Output: Inteiro 55 -> Binário: 110111
        Console.WriteLine($"Inteiro 55 -> Binário: {Convert.ToString(55, 2)} -> >> 3: {Convert.ToString(55>>3, 2)} -> Inteiro deslocamento >> 3 -> {55>>3}"); //Output: Inteiro 55 -> Binário: 110111 -> >> 3: 110 -> Inteiro deslocamento >> 3 -> 6
        Console.WriteLine($"Inteiro (uint) 55 -> Binário: {Convert.ToString(number, 2)} -> >> 3: {Convert.ToString(number>>3, 2)} -> Inteiro deslocamento >> 3 -> {number>>3}"); //Output: Inteiro (uint) 55 -> Binário: 110111 -> >> 3: 110 -> Inteiro deslocamento >> 3 -> 6
        Console.WriteLine($"Inteiro -55 -> Binário: {Convert.ToString(-55, 2)} -> >> 3: {Convert.ToString(-55>>3, 2)} -> Inteiro deslocamento >> 3 -> {-55>>3}"); //Output: Inteiro -55 -> Binário: 11111111111111111111111111001001 -> >> 3: 11111111111111111111111111111001 -> Inteiro deslocamento >> 3 -> -7
        Console.WriteLine($"Inteiro -43 -> Binário: {Convert.ToString(-43, 2)} -> >> 4: {Convert.ToString(-43>>4, 2)} -> Inteiro deslocamento >> 4 -> {-43>>4}"); //Output: Inteiro -43 -> Binário: 11111111111111111111111111010101 -> >> 4: 11111111111111111111111111111101 -> Inteiro deslocamento >> 4 -> -3
        Console.WriteLine($"Inteiro 170 -> Binário: {Convert.ToString(170, 2)} -> >> 8: {Convert.ToString(170>>8, 2)} -> Inteiro deslocamento >> 8 -> {170>>8}"); //Output: Inteiro 170 -> Binário: 10101010 -> >> 8: 0 -> Inteiro deslocamento >> 8 -> 0
        Console.WriteLine($"Inteiro -270 -> Binário: {Convert.ToString(-270, 2)} -> >> 8: {Convert.ToString(-270>>8, 2)} -> Inteiro deslocamento >> 8 -> {-270>>8}"); //Output: Inteiro -270 -> Binário: 11111111111111111111111011110010 -> >> 8: 11111111111111111111111111111110 -> Inteiro deslocamento >> 8 -> -2
        Console.WriteLine($"Inteiro -270 -> Binário: {Convert.ToString(-270, 2)} -> >> 8 >> 8: {Convert.ToString(-270>>8>>8, 2)} -> Inteiro deslocamento >> 8 >> 8 -> {-270>>8>>8}"); //Output: Inteiro -270 -> Binário: 11111111111111111111111011110010 -> >> 8 >> 8: 11111111111111111111111111111111 -> Inteiro deslocamento >> 8 >> 8 -> -1
    }
}