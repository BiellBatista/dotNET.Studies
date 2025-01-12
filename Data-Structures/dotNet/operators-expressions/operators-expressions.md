# Operadores _bit_ a _bit_ e de deslocamento

Os operadores _bit_ a _bit_ e de deslocamento incluem complemento _bit_ a _bit_ unário, deslocamento binário para a esquerda e a direita, deslocamento sem sinal para a direita e os operadores binários lógicos AND, OR e OR exclusivo. Esses operandos usam operandos dos tipos numéricos integrais ou do tipo char.

- **Operador unário**: [~ (complemento _bit_ a _bit_)](#operador-de-complemento-bit-a-bit-).
- **Operadores binários**: [<< (deslocamento para a esquerda)](#operador-de-deslocamento-à-esquerda-), >> (deslocamento para a direita) e >>> (sem sinal de deslocamento para a direita).
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

Em C#, os valores inteiros são geralmente representados usando complemento de dois. Portanto, quando você inverte os _bits_ de um valor positivo, o resultado é um valor negativo. O complemento de dois facilita a manipulação de números negativos e positivos no hardware.

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

## Operador de deslocamento à esquerda <<

O operador << desloca para esquerda o operando à esquerda pelo número de _bits_ definido pelo seu operando à direita. Para saber mais sobre como o operando à direita define a contagem de deslocamento, veja a seção [Contagem de deslocamento dos operadores de deslocamento](#contagem-de-deslocamento-dos-operadores-de-deslocamento).

A operação de deslocamento à esquerda descarta os _bits_ de ordem superior que estão fora do intervalo do tipo de resultado e define as posições de _bits_ vazios de ordem inferior como zero, como mostra o exemplo a seguir:

```c#
uint x = 0b_1100_1001_0000_0000_0000_0000_0001_0001;
uint y = x << 4;

Console.WriteLine($"Before: {Convert.ToString(x, toBase: 2)}"); // Exibe: 11001001000000000000000000010001
Console.WriteLine($"After:  {Convert.ToString(y, toBase: 2)}"); // Exibe: 10010000000000000000000100010000
```

Quando você aplica o operador << a um número, os _bits_ desse número são movidos para a esquerda, e zeros são adicionados nas posições de _bits_ mais à direita. O deslocamento à esquerda pode ser usado para multiplicar rapidamente um valor por potências de dois.

```c#
int value = 3; // Binário: 00000011
int result = value << 2; // Binário: 00001100 (3 deslocado 2 bits para a esquerda)

Console.WriteLine(result); // Exibe: 12
```

Como os operadores de deslocamento são definidos apenas para os tipos ```int```, ```uint```, ```long``` e ```ulong```, o resultado de uma operação sempre contém pelo menos 32 _bits_. Se o operando à esquerda for de outro tipo integral (```sbyte```, ```byte```, ```short```, ```ushort``` ou ```char```), seu valor será convertido no tipo int, como mostra o exemplo a seguir:

```c#
byte a = 0b_1111_0001;
var b = a << 8;

Console.WriteLine(b.GetType()); // Exibe: System.Int32
Console.WriteLine($"Shifted byte: {Convert.ToString(b, toBase: 2)}"); // Exibe: Shifted byte: 1111000100000000
```

### Aplicações comuns do deslocamento de _bits_ à esquerda <<

- **Multiplicação rápida**: deslocar _bits_ para a esquerda equivale a multiplicar por uma potência de dois. Exemplo: ```x << 3``` é equivalente a ```x * 2^3``` ou ```x * 8```. Onde, ```x``` pode ser o valor decimal.
- **Manipulação de _bits_**: _bit fields_, máscaras de _bits_ e operações de _bitwise_ frequentemente utilizam deslocamento de _bits_ para manipulação eficiente de dados. Exemplo: configurar um _bit_ específico em uma máscara de _bits_.
- **Criptografia e compressão de dados**: algoritmos de criptografia e compressão podem usar deslocamento de _bits_ como parte de suas operações.

## Operador de deslocamento à direita >>

O operador >> desloca para direita o operando à esquerda pelo número de _bits_ definido pelo seu operando à direita. Para saber mais sobre como o operando à direita define a contagem de deslocamento, veja a seção [Contagem de deslocamento dos operadores de deslocamento](#contagem-de-deslocamento-dos-operadores-de-deslocamento).

```c#
uint x = 0b_1001;
uint y = x >> 2;

Console.WriteLine($"Before: {Convert.ToString(x, toBase: 2), 4}"); // Exibe: Before: 1001
Console.WriteLine($"After:  {Convert.ToString(y, toBase: 2).PadLeft(4, '0'), 4}"); // Exibe: After:  0010
```

Quando você aplica o operador >> a um número, os _bits_ desse número são movidos para a direita, e os _bits_ de ordem mais alta (à esquerda) são preenchidos com o _bit_ de sinal (para inteiros com sinal) ou zeros (para inteiros sem sinal). Esta operação é útil para dividir rapidamente valores por potências de dois, entre outras aplicações.

```c#
int value = 12; // Binário: 00001100
int result = value >> 2; // Binário: 00000011 (12 deslocado 2 bits para a direita)

Console.WriteLine(result); // Exibe: 3
```

As posições vazias de _bit_ de ordem superior são definidas com base no tipo do operando à esquerda da seguinte maneira:

- Se o operando à esquerda for do tipo ```int``` ou ```long```, o operador de deslocamento à direita executará um deslocamento aritmético: o valor do _bit_ mais significativo (o _bit_ de sinal) do operando à esquerda é propagado para as posições vazias de _bits_ de ordem superior. Ou seja, as posições vazias de _bit_ de ordem superior são definidas como zero se o operando à esquerda for positivo e definidas como um se ele for negativo.

> Deslocamento Aritmético (_Signed Right Shift_):
>
> - Preenche os _bits_ de ordem mais alta (à esquerda) com o _bit_ de sinal (o _bit_ mais à esquerda do valor original). Isso preserva o sinal do número.
> - Utilizado para inteiros com sinal.

```c#
int a = int.MinValue;
int b = a >> 3;

Console.WriteLine($"Before: {Convert.ToString(a, toBase: 2)}"); // Exibe: Before: 10000000000000000000000000000000
Console.WriteLine($"After:  {Convert.ToString(b, toBase: 2)}"); // Exibe: After:  11110000000000000000000000000000
```

```c#
int value = -8; // Binário: 11111000 (em complemento de dois para -8)
int result = value >> 2; // Binário: 11111110 (deslocado 2 bits para a direita)

Console.WriteLine(result); // Exibe: -2
```

- Se o operando à esquerda for do tipo ```uint``` ou ```ulong```, o operador de deslocamento à direita executará um deslocamento lógico: as posições vazias de _bit_ de ordem superior são sempre definidas como zero.

> Deslocamento Lógico (_Unsigned Right Shift_):
>
> - Preenche os _bits_ de ordem mais alta (à esquerda) com zeros.
> - C# não possui diretamente um operador de deslocamento lógico para tipos com sinal, mas o comportamento pode ser simulado usando tipos sem sinal (```uint```, ```ulong```).

```c#
uint c = 0b_1000_0000_0000_0000_0000_0000_0000_0000;
uint d = c >> 3;

Console.WriteLine($"Before: {Convert.ToString(c, toBase: 2), 32}"); // Exibe: Before: 10000000000000000000000000000000
Console.WriteLine($"After:  {Convert.ToString(d, toBase: 2).PadLeft(32, '0'), 32}"); // Exibe: After:  00010000000000000000000000000000
```

```c#
uint value = 0b11110000; // Binário: 11110000 (240 em decimal)
uint result = value >> 2; // Binário: 00111100 (deslocado 2 bits para a direita)

Console.WriteLine(result); // Exibe: 60
```

> Use o [operador de deslocamento à direita sem sinal](#operador-de-deslocamento-para-a-direita-sem-sinal-) para executar um deslocamento lógica em operandos de tipos inteiros com sinal. Isso é preferido para converter um operando à esquerda em um tipo não assinado e, em seguida, converter o resultado de uma operação de deslocamento de volta para um tipo assinado.

### Aplicações comuns do deslocamento de _bits_ à direita >>

- **Divisão rápida**: deslocar _bits_ para a direita equivale a dividir por uma potência de dois. Exemplo: ```x >> 8``` é equivalente a ```x / 2^8``` ou ```x * 256```. Onde, ```x``` pode ser o valor decimal.
- **Manipulação de _bits_**: _bit fields_, máscaras de _bits_ e operações de _bitwise_ frequentemente utilizam deslocamento de _bits_ para manipulação eficiente de dados. Exemplo: Isolar os _bits_ mais à direita.
- **Criptografia e compressão de dados**: algoritmos de criptografia e compressão podem usar deslocamento de _bits_ como parte de suas operações.
- **Tratamento de _Overflow_**: Utilizado em algoritmos para manipulação de números inteiros sem se preocupar com overflow ao dividir valores.

## Operador de deslocamento para a direita sem sinal >>>

Disponível em C# 11 e versões posteriores, o operador >>> desloca para direita o operando à esquerda pelo número de _bits_ definido pelo seu operando à direita. Para saber mais sobre como o operando à direita define a contagem de deslocamento, veja a seção [Contagem de deslocamento dos operadores de deslocamento](#contagem-de-deslocamento-dos-operadores-de-deslocamento).

### Aplicações comuns do deslocamento de _bits_

- **Multiplicação e divisão rápida**: deslocar _bits_ para a esquerda equivale a multiplicar por uma potência de dois, enquanto deslocar _bits_ para a direita equivale a dividir por uma potência de dois.
- **Manipulação de _bits_**: _bit fields_, máscaras de _bits_ e operações de _bitwise_ frequentemente utilizam deslocamento de _bits_ para manipulação eficiente de dados.
- **Criptografia e compressão de dados**: algoritmos de criptografia e compressão podem usar deslocamento de _bits_ como parte de suas operações.

## Contagem de deslocamento dos operadores de deslocamento
