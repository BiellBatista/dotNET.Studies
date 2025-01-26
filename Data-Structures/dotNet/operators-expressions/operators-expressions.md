# Operadores _bit_ a _bit_ e de deslocamento

Os operadores _bit_ a _bit_ e de deslocamento incluem complemento _bit_ a _bit_ unário, deslocamento binário para a esquerda e a direita, deslocamento sem sinal para a direita e os operadores binários lógicos AND, OR e OR exclusivo. Esses operandos usam operandos dos tipos numéricos integrais ou do tipo char.

- **Operador unário**: [~ (complemento _bit_ a _bit_)](#operador-de-complemento-bit-a-bit-).
- **Operadores binários**: [<< (deslocamento para a esquerda)](#operador-de-deslocamento-à-esquerda-), [>> (deslocamento para a direita)](#operador-de-deslocamento-à-direita-) e [>>> (sem sinal de deslocamento para a direita)](#operador-de-deslocamento-para-a-direita-sem-sinal-).
- **Operadores binários**: & (AND lógico), | (OR lógico) e ^ (OR exclusivo lógico).

Esses operadores são definidos para os tipos ```int```, ```uint```, ```long``` e ```ulong```. Quando ambos os operandos são de outros tipos integrais (```sbyte```, ```byte```, ```short```, ```ushort``` ou ```char```), seus valores são convertidos no tipo ```int```, que também é o tipo de resultado de uma operação. Quando os operandos são de tipos integrais diferentes, seus valores são convertidos no tipo integral mais próximo que o contém. Os operadores compostos (como >>=) não convertem seus argumentos em ```int``` ou têm o tipo de resultado como ```int```.

Os operadores &, | e ^ também são definidos para os operandos do tipo ```bool```.

As operações de deslocamento e ```bit``` a ```bit``` nunca causam estouro e produzem os mesmos resultados nos [contextos marcados e desmarcados](../types-variables/value-types/built-in-numeric-conversion.md#conversões-numéricas-explícitas).

## _Bit_ de ordem alta e baixa

Em sistemas de computação, os _bits_ de um número binário são ordenados por posição, indo da posição de menor valor (_bit_ menos significativo) para a posição de maior valor (_bit_ mais significativo).

### _Bit_ de ordem alta (_bit_ mais significativo)

O _bit_ de ordem alta, ou _bit_ mais significativo (_Most Significant Bit_, MSB), é o _bit_ na posição de maior valor em uma representação binária. Em um número binário de 8 _bits_, por exemplo, o _bit_ de ordem alta é o _bit_ na posição 7 (contando a partir de 0). Este bit tem a maior influência no valor total do número. Exemplo:

> Número binário: 11001010
> Posições:        76543210
> Bit MSB:         1

#### Importância do _bit_ de ordem alta

1 - **Determinação do sinal**: em representações de complemento de dois, o _bit_ de ordem alta determina o sinal do número. Se o _bit_ de ordem alta for 1, o número é negativo; se for 0, o número é positivo.
2 - **Valor numérico**: o valor do _bit_ de ordem alta contribui significativamente para o valor total do número. Por exemplo, em um número de 8 _bits_, o _bit_ de ordem alta representa 2^7 (ou 128 em decimal).

### _Bit_ de ordem baixa (_bit_ menos significativo)

O _bit_ de ordem baixa, ou _bit_ menos significativo (_Least Significant Bit_, LSB), é o _bit_ na posição de menor valor. Ele representa 2^0 (ou 1 em decimal) e tem a menor influência no valor total do número. Exemplo:

> Número binário: 11001010
> Posições:        76543210
> Bit MSB:         0

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

1 - **Multiplicação rápida**: deslocar _bits_ para a esquerda equivale a multiplicar por uma potência de dois. Exemplo: ```x << 3``` é equivalente a ```x * 2^3``` ou ```x * 8```. Onde, ```x``` pode ser o valor decimal.
2 - **Manipulação de _bits_**: _bit fields_, máscaras de _bits_ e operações de _bitwise_ frequentemente utilizam deslocamento de _bits_ para manipulação eficiente de dados. Exemplo: configurar um _bit_ específico em uma máscara de _bits_.
3 - **Criptografia e compressão de dados**: algoritmos de criptografia e compressão podem usar deslocamento de _bits_ como parte de suas operações.

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

1 - **Divisão rápida**: deslocar _bits_ para a direita equivale a dividir por uma potência de dois. Exemplo: ```x >> 8``` é equivalente a ```x / 2^8``` ou ```x * 256```. Onde, ```x``` pode ser o valor decimal.
2 - **Manipulação de _bits_**: _bit fields_, máscaras de _bits_ e operações de _bitwise_ frequentemente utilizam deslocamento de _bits_ para manipulação eficiente de dados. Exemplo: Isolar os _bits_ mais à direita.
3 - **Criptografia e compressão de dados**: algoritmos de criptografia e compressão podem usar deslocamento de _bits_ como parte de suas operações.
4 - **Tratamento de _Overflow_**: Utilizado em algoritmos para manipulação de números inteiros sem se preocupar com overflow ao dividir valores.

## Operador de deslocamento para a direita sem sinal >>>

Disponível em C# 11 e versões posteriores, o operador >>> desloca para direita o operando à esquerda pelo número de _bits_ definido pelo seu operando à direita. Para saber mais sobre como o operando à direita define a contagem de deslocamento, veja a seção [Contagem de deslocamento dos operadores de deslocamento](#contagem-de-deslocamento-dos-operadores-de-deslocamento).

O operador >>> sempre realiza um deslocamento lógico. Ou seja, as posições de _bits_ vazias de alta ordem são sempre definidas como zero, independentemente do tipo do operando à esquerda. O [operador >>](#operador-de-deslocamento-à-direita-) executa um deslocamento aritmético (ou seja, o valor do bit mais significativo é propagado para as posições de _bit_ vazias de alta ordem) se o operando à esquerda for de um tipo assinado. O seguinte exemplo demonstra a diferença entre os operadores >> e >>> para um operando à esquerda negativo:

```c#
int x = -8;
Console.WriteLine($"Before:    {x,11}, hex: {x,8:x}, binary: {Convert.ToString(x, toBase: 2), 32}");

int y = x >> 2;
Console.WriteLine($"After  >>: {y,11}, hex: {y,8:x}, binary: {Convert.ToString(y, toBase: 2), 32}");

int z = x >>> 2;
Console.WriteLine($"After >>>: {z,11}, hex: {z,8:x}, binary: {Convert.ToString(z, toBase: 2).PadLeft(32, '0'), 32}");
// Output:
// Before:             -8, hex: fffffff8, binary: 11111111111111111111111111111000
// After  >>:          -2, hex: fffffffe, binary: 11111111111111111111111111111110
// After >>>:  1073741822, hex: 3ffffffe, binary: 00111111111111111111111111111110
```

### Aplicações comuns do deslocamento de _bits_ à direita sem sinal >>>

1 - **Divisão rápida de números sem sinal**: o operador >>> pode ser usado para dividir rapidamente números sem sinal por potências de dois. Isso é útil em algoritmos que trabalham com números sem sinal, como algoritmos de criptografia e compressão de dados.
2 - **Manipulação de _bits_**: utilizado para manipular _bits_ em dados binários sem se preocupar com o preenchimento de zeros ou a preservação do _bit_ de sinal. Isso é particularmente útil em protocolos de comunicação e formatos de arquivos que dependem da manipulação precisa de _bits_.
3 - **Processamento de imagens e gráficos:**: no processamento de imagens, onde os dados de _pixel_ podem ser representados como inteiros sem sinal, o operador >>> pode ser utilizado para manipulações eficientes de _bits_, como ajuste de brilho e contraste.
4 - **Tratamento de dados em redes**: em aplicações de redes, o operador >>> pode ser usado para processar pacotes de dados, garantindo que os _bits_ sejam manipulados corretamente sem considerar o _bit_ de sinal.
5 - **Implementação de algoritmos de _hash_**: utilizado em funções de _hash_, onde a distribuição uniforme dos _bits_ é crucial. O >>> ajuda a garantir que o deslocamento não introduza padrões indesejados nos _bits_ de ordem alta.

## Operador _AND_ lógico &

O operador & computa o _AND_ lógico _bit_ a _bit_ de seus operandos integrais:

```c#
uint a = 0b_1111_1000;
uint b = 0b_1001_1101;
uint c = a & b;

Console.WriteLine(Convert.ToString(c, toBase: 2)); // Output: 10011000
```

O operador lógico _AND bit_ a _bit_ (&) é utilizado para comparar os _bits_ correspondentes de dois operandos. O resultado da operação é um novo valor onde cada _bit_ é definido como 1 apenas se ambos os _bits_ correspondentes dos operandos forem 1. Caso contrário, o _bit_ resultante será 0.

Para operandos ```bool```, o operador & computa o _AND_ lógico de seus operandos. O operador & unário é o [operador _address-of_](./pointer-related-operators.md#operador-address-of-).

### Aplicações comuns do operador _AND_ lógico &

1 - **Máscaras de _bits_**: utilizado para isolar e extrair bits específicos de um valor. A máscara é um valor onde apenas os _bits_ de interesse são definidos como 1.

```c#
int value = 0b10101101;   // Valor inicial: 173 em decimal
int mask = 0b00001111;    // Máscara: isolar os 4 bits menos significativos
int result = value & mask; // Resultado: 00001101 (13 em decimal)

Console.WriteLine(result); // Saída: 13
```

2 - **Verificação de _bits_**: verificar se _bits_ específicos estão definidos em um valor. Isso é comum em sistemas de permissões e _flags_.

```c#
int flags = 0b1011;     // Flags: 1011 (11 em decimal)
int check = 0b1000;     // Verificar se o bit 3 está definido
bool isSet = (flags & check) != 0;

Console.WriteLine(isSet); // Saída: True
```

3 - **Operações de conjuntos**: utilizado para realizar operações de interseção em conjuntos representados por _bits_. Isso é útil em sistemas que usam _bitsets_ para representar conjuntos.

```c#
int setA = 0b1101;    // Conjunto A: {0, 2, 3}
int setB = 0b1011;    // Conjunto B: {0, 1, 3}
int intersection = setA & setB; // Interseção: {0, 3} (1001 em binário)

Console.WriteLine(Convert.ToString(intersection, 2)); // Saída: 1001
Console.WriteLine(intersection); // Saída: 9 (em decimal)
```

4 - **Controle de _hardware_**: utilizado para manipular e verificar estados de registradores em dispositivos de _hardware_. Operações _bit_ a _bit_ são essenciais para ajustar configurações e estados específicos.

## Operador _OR_ exclusivo lógico ^

O operador ^ computa o _OR_ exclusivo lógico _bit_ a _bit_, também conhecido como o XOR lógico _bit_ a _bit_, de seus operandos integrais:

```c#
uint a = 0b_1111_1000;
uint b = 0b_0001_1100;
uint c = a ^ b;

Console.WriteLine(Convert.ToString(c, toBase: 2)); // Output: 11100100
```

O operador lógico XOR _bit_ a _bit_ (^) é utilizado para comparar os _bits_ correspondentes de dois operandos. O resultado da operação é um novo valor onde cada _bit_ é definido como 1 apenas se os _bits_ correspondentes dos operandos forem diferentes. Caso os _bits_ correspondentes sejam iguais, o _bit_ resultante será 0.

Para operandos ```bool```, o operador ^ computa o OR exclusivo lógico de seus operandos.

### Aplicações comuns do operador _OR_ exclusivo lógico ^

1 - **Troca de valores sem variável temporária**: o operador XOR pode ser utilizado para trocar os valores de duas variáveis sem precisar de uma variável temporária.

```c#
int x = 5; // Binário: 0101
int y = 9; // Binário: 1001

x = x ^ y; // x agora é 1100 (12 em decimal)
y = x ^ y; // y agora é 0101 (5 em decimal)
x = x ^ y; // x agora é 1001 (9 em decimal)

Console.WriteLine($"x: {x}, y: {y}");
```

2 - **Verificação de paridade**: utilizado para verificar a paridade (par ou ímpar) de um número. Se o resultado da operação XOR entre todos os _bits_ de um número for 1, então o número de _bits_ 1 é ímpar.

```c#
int number = 0b1011; // Binário: 1011 (11 em decimal)
int parity = number ^ (number >> 1);

parity ^= (parity >> 2);
parity ^= (parity >> 4);

bool isOdd = (parity & 1) == 1;

Console.WriteLine(isOdd); // Saída: True (número ímpar)
```

3 - **Criptografia simples**: utilizado em algoritmos de criptografia simples, como cifras XOR, onde os dados são combinados com uma chave usando a operação XOR.

```c#
string plaintext = "Hello";
char key = 'K';

string encrypted = new string(plaintext.Select(c => (char)(c ^ key)).ToArray());
string decrypted = new string(encrypted.Select(c => (char)(c ^ key)).ToArray());

Console.WriteLine($"Encrypted: {encrypted}"); // Texto criptografado
Console.WriteLine($"Decrypted: {decrypted}"); // Texto original: Hello
```

4 - **Detecção de erros**: utilizado em códigos de detecção de erros, como o código de redundância cíclica (CRC) e a soma de verificação XOR.

## Operador _OR_ lógico |

O operador | computa o _OR_ lógico _bit_ a _bit_ de seus operandos integrais:

```c#
uint a = 0b_1010_0000;
uint b = 0b_1001_0001;
uint c = a | b;

Console.WriteLine(Convert.ToString(c, toBase: 2)); // Output: 10110001
```

O operador lógico OR _bit_ a _bit_ (|) é utilizado para comparar os _bits_ correspondentes de dois operandos. O resultado da operação é um novo valor onde cada _bit_ é definido como 1 se pelo menos um dos _bits_ correspondentes dos operandos for 1. Caso contrário, o _bit_ resultante será 0.

Para operandos ```bool```, o operador | computa o _OR_ lógico de seus operandos.

### Aplicações comuns do operador _OR_ lógico |

1 - **Configuração de _bits_**: usado para configurar (definir) _bits_ específicos em um valor. Isso é útil em situações onde precisamos ativar ou combinar múltiplos _bits_.

```c#
int value = 0b1001;   // Valor inicial: 9 em decimal
int mask = 0b0110;    // Máscara: configurar bits específicos
int result = value | mask; // Resultado: 1111 (15 em decimal)

Console.WriteLine(result); // Saída: 15
```

2 - **Combinação de permissões**: em sistemas de permissões, o operador _OR_ _bit_ a _bit_ pode ser usado para combinar múltiplas permissões em um único valor.

```c#
[Flags]
public enum Permissions : byte
{
    Read = 1 << 0,    // 0001
    Write = 1 << 1,   // 0010
    Execute = 1 << 2, // 0100
    Delete = 1 << 3   // 1000
}

Permissions userPermissions = Permissions.Read | Permissions.Write;

Console.WriteLine(userPermissions); // Saída: Read, Write
```

3 - **Operações de união em conjuntos**: utilizado para realizar operações de união em conjuntos representados por _bits_. Isso é útil em sistemas que usam _bitsets_ para representar conjuntos.

```c#
int setA = 0b1010;    // Conjunto A: {1, 3}
int setB = 0b0110;    // Conjunto B: {1, 2}
int union = setA | setB; // União: {1, 2, 3} (1110 em binário)

Console.WriteLine(Convert.ToString(union, 2)); // Saída: 1110
Console.WriteLine(union); // Saída: 14 (em decimal)
```

4 - **Controle de _hardware_**: utilizado para manipular e configurar estados de registradores em dispositivos de _hardware_. Operações _bit_ a _bit_ são essenciais para ajustar configurações e estados específicos.

## Contagem de deslocamento dos operadores de deslocamento
