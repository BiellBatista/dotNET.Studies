# Conversões numéricas internas

O C# fornece um conjunto de tipos numéricos integral e ponto flutuante. Existe uma conversão entre dois tipos numéricos, implícitos ou explícitos. Você deve usar uma expressão de conversão para executar uma conversão explícita.

## Conversões numéricas implícitas

> As conversões implícitas de ```int```, ```uint```, ```long```, ```ulong```, ```nint``` ou ```nuint``` para ```float``` e de ```long```, ```ulong```, ```nint``` ou ```nuint``` para ```double``` podem causar uma perda de precisão, mas nunca uma perda de uma ordem de magnitude. As outras conversões numéricas implícitas nunca perdem nenhuma informação.

- Qualquer tipo numérico integral pode ser implicitamente convertido em qualquer tipo numérico de ponto flutuante.
- Não há nenhuma conversão implícita para os tipos ```byte```, ```sbyte``` e não há nenhuma conversão implícita dos tipos ```double``` e ```decimal```.
- Não há nenhuma conversão implícita entre os tipos ```decimal``` e ```float``` ou os tipos ```double```.
- Um valor de uma expressão de constante de tipo ```int``` (por exemplo, um valor representado por um literal integral) pode ser convertido em ```sbyte```, ```byte```, ```short```, ```ushort```, ```uint``` ou ```ulong```, ```nint``` ou ```nuint```, se estiver dentro do intervalo do tipo de destino.

## Conversões numéricas explícitas

> Uma conversão numérica explícita pode resultar em perda de dados ou gerar uma exceção, normalmente um _OverflowException_.
>
> As instruções ```checked``` e ```unchecked``` especificam o contexto de verificação de estouro para operações e conversões aritméticas do tipo integral. Quando ocorre um estouro aritmético inteiro, o contexto de verificação de estouro define o que acontece. Em um contexto verificado, um _System.OverflowException_ é lançado; se o estouro acontece em uma expressão de constante, ocorre um erro em tempo de compilação. Em um contexto não verificado, o resultado da operação é truncado pelo descarte dos bits de ordem superior que não se ajustam ao tipo de destino. Por exemplo, a adição quebra do valor máximo para o valor mínimo. O seguinte exemplo mostra a mesma operação em um contexto verificado e não verificado:
>
> ```c#
> uint a = uint.MaxValue;
> 
> unchecked
> {
>     Console.WriteLine(a + 3);  // output: 2
> }
> 
> try
> {
>     checked
>     {
>         Console.WriteLine(a + 3);
>     }
> }
> catch (OverflowException e)
> {
>     Console.WriteLine(e.Message);  // output: Arithmetic operation resulted in an overflow.
> }
> ```
>
> Para especificar o contexto de verificação de estouro para uma expressão, você também pode usar os operadores ```checked``` e ```unchecked```, como mostra o exemplo a seguir:
>
> ```c#
> double a = double.MaxValue;
>
> int b = unchecked((int)a);
> Console.WriteLine(b);  // output: -2147483648
>
> try
> {
>     b = checked((int)a);
> }
> catch (OverflowException e)
> {
>     Console.WriteLine(e.Message);  // output: Arithmetic operation resulted in an overflow.
> }
> ```
>
> Os operadores e as instruções ```checked``` e ```unchecked``` afetam apenas o contexto de verificação de estouro para as operações que estão textualmente dentro dos parênteses do operador ou do bloco de instrução, como mostra o exemplo a seguir:
>
> ```c#
> int Multiply(int a, int b) => a * b;
>
> int factor = 2;
>
> try
> {
>     checked
>     {
>         Console.WriteLine(Multiply(factor, int.MaxValue));  // output: -2
>     }
> }
> catch (OverflowException e)
> {
>     Console.WriteLine(e.Message);
> }
>
> try
> {
>     checked
>     {
>         Console.WriteLine(Multiply(factor, factor * int.MaxValue));
>     }
> }
> catch (OverflowException e)
> {
>     Console.WriteLine(e.Message);  // output: Arithmetic operation resulted in an overflow.
> }
> ```
>
> No exemplo anterior, a primeira invocação da função local _Multiply_ mostra que a instrução ```checked``` não afeta o contexto de verificação de estouro dentro da função _Multiply_, pois nenhuma exceção é gerada. Na segunda invocação da função _Multiply_, a expressão que calcula o segundo argumento da função é avaliada em um contexto verificado e resulta em uma exceção, pois está textualmente dentro do bloco da instrução ```checked```.

- Quando você converte um valor de um tipo integral em outro tipo integral, o resultado depende do contexto de verificação do estouro. Em um contexto verificado, a conversão terá êxito se o valor de origem estiver dentro do intervalo do tipo de destino. Caso contrário, um _OverflowException_ será gerado. Em um contexto não verificado, a conversão sempre terá êxito e procederá da seguinte maneira:
  - Se o tipo de origem for maior do que o tipo de destino, então o valor de origem será truncado descartando seus _bits_ "extra" mais significativos. O resultado é então tratado como um valor do tipo de destino.
  - Se o tipo de origem for menor do que o tipo de destino, então o valor de origem será estendido por sinal ou por zero para que tenha o mesmo tamanho que o tipo de destino. A extensão por sinal será usada se o tipo de origem tiver sinal; a extensão por zero será usada se o tipo de origem não tiver sinal. O resultado é então tratado como um valor do tipo de destino.
  - Se o tipo de origem tiver o mesmo tamanho que o tipo de destino, então o valor de origem será tratado como um valor do tipo de destino.
- Ao converter um valor ```decimal``` para um tipo integral, esse valor será arredondado para zero, para o valor integral mais próximo. Se o valor integral resultante estiver fora do intervalo do tipo de destino, uma _OverflowException_ será lançada.
- Ao converter um valor ```double``` ou ```float``` em um tipo integral, esse valor será arredondado em direção a zero para o valor integral mais próximo. Se o valor integral resultante estiver fora do intervalo do tipo de destino, o resultado dependerá do contexto de verificação de estouro. Em um contexto verificado, uma _OverflowException_ será lançada, ao passo que em um contexto não verificado, o resultado será um valor não especificado do tipo de destino (NaN).
- Ao converter ```double``` para ```float```, o valor ```double``` será arredondado para o valor ```float``` mais próximo. Se o valor ```double``` for muito pequeno ou muito grande para caber no tipo ```float```, o resultado será zero ou infinito.
- Ao converter ```float``` ou ```double``` para ```decimal```, o valor de origem será convertido para uma representação ```decimal``` e arredondado para o número mais próximo após a 28.ª casa decimal, se necessário. De acordo com o valor do valor de origem, um dos resultados a seguir podem ocorrer:
  - Se o valor de origem for muito pequeno para ser representado como um ```decimal```, o resultado será zero.
  - Se o valor de origem for um NaN (não for um número), infinito ou muito grande para ser representado como um decimal, uma _OverflowException_ será lançada.
- Ao converter ```decimal``` para ```float``` ou ```double```, o valor de origem será arredondado para o valor ```float``` ou ```double``` mais próximo.
