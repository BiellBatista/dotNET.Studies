namespace OperatorsExpressions;

internal sealed class LeftShiftOperator
{
    public static void Execute()
    {
        Console.WriteLine("-----------");
        Console.WriteLine($"Inteiro 55 -> Binário: {Convert.ToString(55, 2)}"); //Output: Inteiro 55 -> Binário: 110111
        Console.WriteLine($"Inteiro 55 -> Binário: {Convert.ToString(55, 2)} -> << 3: {Convert.ToString(55<<3, 2)} -> Inteiro deslocamento << 3 -> {55<<3}"); //Output: Inteiro 55 -> Binário: 110111 -> << 3: 110111000 -> Inteiro deslocamento << 3 -> 440
        Console.WriteLine($"Inteiro -43 -> Binário: {Convert.ToString(-43, 2)} -> << 4: {Convert.ToString(-43<<4, 2)} -> Inteiro deslocamento << 4 -> {-43<<4}"); //Output: Inteiro -43 -> Binário: 11111111111111111111111111010101 -> << 4: 11111111111111111111110101010000 -> Inteiro deslocamento << 4 -> -688
        Console.WriteLine($"Inteiro 170 -> Binário: {Convert.ToString(170, 2)} -> << 8: {Convert.ToString(170<<8, 2)} -> Inteiro deslocamento << 8 -> {170<<8}"); //Output: Inteiro 170 -> Binário: 10101010 -> << 8: 1010101000000000 -> Inteiro deslocamento << 8 -> 43520
        Console.WriteLine($"Inteiro -270 -> Binário: {Convert.ToString(-270, 2)} -> << 8: {Convert.ToString(-270<<8, 2)} -> Inteiro deslocamento << 8 -> {-270<<8}"); //Output: Inteiro -270 -> Binário: 11111111111111111111111011110010 -> << 8: 11111111111111101111001000000000 -> Inteiro deslocamento << 8 -> -69120
        Console.WriteLine($"Inteiro -270 -> Binário: {Convert.ToString(-270, 2)} -> << 8 << 8: {Convert.ToString(-270<<8<<8, 2)} -> Inteiro deslocamento << 8 << 8 -> {-270<<8<<8}"); //Output: Inteiro -270 -> Binário: 11111111111111111111111011110010 -> << 8 << 8: 11111110111100100000000000000000 -> Inteiro deslocamento << 8 << 8 -> -17694720
    }
}