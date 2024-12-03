# Operadores _bit_ a _bit_ e de deslocamento

Os operadores _bit_ a _bit_ e de deslocamento incluem complemento _bit_ a _bit_ unário, deslocamento binário para a esquerda e a direita, deslocamento sem sinal para a direita e os operadores binários lógicos AND, OR e OR exclusivo. Esses operandos usam operandos dos tipos numéricos integrais ou do tipo char.

- **Operador unário**: [~ (complemento _bit_ a _bit_)](#operador-de-complemento-bit-a-bit-).
- **Operadores binários**: << (deslocamento para a esquerda), >> (deslocamento para a direita) e >>> (sem sinal de deslocamento para a direita).
- **Operadores binários**: & (AND lógico), | (OR lógico) e ^ (OR exclusivo lógico).

Esses operadores são definidos para os tipos ```int```, ```uint```, ```long``` e ```ulong```. Quando ambos os operandos são de outros tipos integrais (```sbyte```, ```byte```, ```short```, ```ushort``` ou ```char```), seus valores são convertidos no tipo ```int```, que também é o tipo de resultado de uma operação. Quando os operandos são de tipos integrais diferentes, seus valores são convertidos no tipo integral mais próximo que o contém. Os operadores compostos (como >>=) não convertem seus argumentos em ```int``` ou têm o tipo de resultado como ```int```.

Os operadores &, | e ^ também são definidos para os operandos do tipo ```bool```.

As operações de deslocamento e ```bit``` a ```bit``` nunca causam estouro e produzem os mesmos resultados nos [contextos marcados e desmarcados](../types-variables/value-types/built-in-numeric-conversion.md#conversões-numéricas-explícitas).

## Operador de complemento _bit_ a _bit_ ~

O operador de complemento _bit_ a _bit_ (~) é utilizado para inverter todos os _bits_ de um valor binário. Ele é também conhecido como operador _NOT_ _bit_ a _bit_. Quando aplicado a um valor, ele transforma todos os _bits_ 0 em 1 e todos os _bits_ 1 em 0.

O operador ~ é unário, o que significa que é aplicado a um único operando. Ele é usado principalmente para operações de baixo nível e manipulação de _bits_.

```c#
int value = 0b00001101; // Valor inicial em binário: 13 em decimal 
int complement = ~value; // Complemento bit a bit

Console.WriteLine(Convert.ToString(complement, 2)); // Exibe: 11111111111111111111111111110010
Console.WriteLine(complement); // Exibe: -14 (em decimal)
```

Em C#, os valores inteiros são geralmente representados usando complemento de dois. Portanto, quando você inverte os _bits_ de um valor positivo, o resultado é um valor negativo.

### Aplicações comuns do complemento

O operador ~ é útil em situações onde você precisa inverter todos os _bits_ de um número, como em operações de máscara de _bits_ e algoritmos específicos que requerem manipulação direta de _bits_.

1 - **Máscara de _bits_**: o operador ~ pode ser usado para criar máscaras de _bits_ que limpam (tornam zero) _bits_ específicos em um valor.

```c#
int value = 0b11110011;   // Valor inicial: 243 em decimal
int mask = 0b11110000;    // Máscara: define os 4 bits menos significativos como 0
int result = value & ~mask; // Complemento da máscara: 00001111

Console.WriteLine(Convert.ToString(result, 2)); // Exibe: 00000011
Console.WriteLine(result); // Exibe: 3 (em decimal)
```

2 - **Troca de _bits_ (_Bit Toggling_)**: o complemento _bit_ a _bit_ pode ser usado em combinação com a operação XOR (^) para alternar (ou inverter) bits específicos.

```c#
int value = 0b10101010;  // Valor inicial: 170 em decimal
int result = value ^ ~0; // Inverte todos os bits usando XOR e complemento

Console.WriteLine(Convert.ToString(result, 2)); // Exibe: 01010101
Console.WriteLine(result); // Exibe: 85 (em decimal)
```

3 - **Implementação de comparações personalizadas**: o operador de complemento pode ser usado em algoritmos para criar comparações _bit_ a _bit_ mais eficientes, como verificar desigualdade sem usar o operador de desigualdade (!=).

```c#
bool AreEqual(int a, int b)
{
    return ~(a ^ b) == -1; // Se a igualdade bit a bit resulta em todos 1s (0xFFFFFFFF)
}

int value1 = 100;
int value2 = 100;
int value3 = 200;

Console.WriteLine(AreEqual(value1, value2)); // Exibe: True
Console.WriteLine(AreEqual(value1, value3)); // Exibe: False
```

## asdasdasd

### Aplicações comuns do deslocamento de _bits_

- **Multiplicação e divisão rápida**: deslocar _bits_ para a esquerda equivale a multiplicar por uma potência de dois, enquanto deslocar _bits_ para a direita equivale a dividir por uma potência de dois.
- **Manipulação de _bits_**: _bit fields_, máscaras de _bits_ e operações de _bitwise_ frequentemente utilizam deslocamento de _bits_ para manipulação eficiente de dados.
- **Criptografia e compressão de dados**: algoritmos de criptografia e compressão podem usar deslocamento de _bits_ como parte de suas operações.
