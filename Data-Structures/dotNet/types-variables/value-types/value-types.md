# Tipos de valor

Tipos de valor e tipos de referência são as duas categorias principais de tipos C#. Uma variável de um tipo de valor contém uma instância do tipo. Isso é diferente de uma variável de um tipo de referência, que contém uma referência a uma instância do tipo. Por padrão, na atribuição, ao passar um argumento para um método e retornar um resultado de método os valores de variável são copiados. No caso de variáveis de tipo de valor, as instâncias de tipo correspondentes são copiadas.

> As operações em uma variável de tipo de valor afetam apenas essa instância do tipo de valor armazenada na variável.

Se um tipo de valor contiver um membro de dados de um tipo de referência, somente a referência à instância do tipo de referência será copiada quando uma instância de tipo de valor for copiada. A instância de cópia e de tipo de valor original tem acesso à mesma instância de tipo de referência.
