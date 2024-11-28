# Tipos de valor

Tipos de valor e tipos de referência são as duas categorias principais de tipos C#. Uma variável de um tipo de valor contém uma instância do tipo. Isso é diferente de uma variável de um tipo de referência, que contém uma referência a uma instância do tipo. Por padrão, na atribuição, ao passar um argumento para um método e retornar um resultado de método os valores de variável são copiados. No caso de variáveis de tipo de valor, as instâncias de tipo correspondentes são copiadas.

> As operações em uma variável de tipo de valor afetam apenas a cópida (instância do tipo de valor armazenada na variável).

Se um tipo de valor contiver um membro de dados de um tipo de referência, somente a referência à instância do tipo de referência será copiada quando uma instância de tipo de valor for copiada. A instância de cópia e de tipo de valor original tem acesso à mesma instância de tipo de referência.

Um tipo de valor pode ser de uma das duas seguintes modalidades:

- **Tipo de estrutura**: encapsula dados e funcionalidade relacionada.
- **Tipo de enumeração**: é definido por um conjunto de constantes nomeadas e representa uma escolha ou uma combinação de opções.

O C# fornece os seguintes tipos de valor internos, também conhecidos como **tipos simples**:

- Tipos numéricos integrais.
- Tipos numéricos de ponto flutuante.
- Tipo booliano.
- Tipo caractere (char).

Todos os tipos simples são tipos de estrutura, e diferem de outros tipos de estrutura por permitirem determinadas operações adicionais:

- Você pode usar literais para fornecer um valor de um tipo simples. Por exemplo, ```A``` é um literal do tipo ```char```, ```2001``` é um literal do tipo ```int``` e ```12.34m``` é um literal do tipo ```decimal```.
- Não é possível ter constantes de tipos diferentes de simples.
- As expressões constantes, cujos operandos são todos constantes de tipo simples, são avaliadas em tempo de compilação.

> Uma tupla é um tipo de valor, mas não um tipo simples.

## Tipos numéricos de ponto flutuante

Você pode misturar tipos integrais e os tipos ```float``` e ```double``` em uma expressão. Nesse caso, os tipos integrais são convertidos implicitamente em um dos tipos de ponto flutuante e, se necessário, o tipo ```float``` é convertido implicitamente em ```double```. A expressão é avaliada como segue:

- Se houver os tipo ```double``` na expressão, ela será avaliada como double, ou como bool em comparações relacionais e de igualdade.
- Se não houver nenhum tipo ```double``` na expressão, ela será avaliada como ```float```, ou como bool em comparações relacionais e de igualdade.

Você também pode misturar tipos integrais e o tipo ```decimal``` em uma expressão. Nesse caso, os tipos integrais são convertidos implicitamente no tipo ```decimal``` e a expressão é avaliada como ```decimal```, ou como bool em comparações relacionais e de igualdade.

Não é possível misturar o tipo ```decimal``` com os tipos ```float``` e ```double``` em uma expressão. Nesse caso, se você quiser executar operações aritméticas, de comparação ou de igualdade, deverá converter explicitamente os operandos de/para o tipo ```decimal```.

### Conversões

Há apenas uma conversão implícita entre tipos numéricos de ponto flutuante: de ```float``` para ```double```. No entanto, você pode converter qualquer tipo de ponto flutuante em qualquer outro tipo de ponto flutuante com a conversão explícita.

> Veja tudo sobre conversões na página [Conversões numéricas internas](./built-in-numeric-conversion.md)
