# Guia de Relacionamentos entre Entidades

Este documento serve como base para modelar relacionamentos entre entidades no projeto.

O objetivo e responder sempre estas perguntas antes de criar ou alterar uma entidade:

1. Uma instancia de `A` se relaciona com quantas instancias de `B`?
2. Uma instancia de `B` se relaciona com quantas instancias de `A`?
3. Quem depende de quem para existir?
4. Onde a chave estrangeira deve ficar?
5. A relacao precisa guardar dados extras?

## Regra Rapida

- `1:1`: um registro de um lado corresponde a um unico registro do outro lado
- `1:N`: um registro do lado principal possui varios registros do outro lado
- `N:N`: varios registros de um lado se relacionam com varios do outro lado

## Como Pensar Antes de Codar

Use esta sequencia sempre:

1. Identifique as entidades envolvidas.
2. Defina a cardinalidade da relacao: `1:1`, `1:N` ou `N:N`.
3. Escolha qual entidade e a principal e qual e a dependente.
4. Coloque a chave estrangeira na entidade dependente.
5. Adicione as propriedades de navegacao.
6. Crie ou ajuste o mapping do Entity Framework.
7. Gere migration somente depois de o modelo estar coerente.

## Padrao de Codigo

Na pratica, os relacionamentos costumam seguir estas regras:

- Relacao para um unico item: propriedade simples
- Relacao para varios itens: `ICollection<T>`
- Chave estrangeira: propriedade como `EntidadeId`
- Navegacao: propriedade com o nome da entidade relacionada

Exemplo de nomes:

```csharp
public Guid MotoristaId { get; set; }
public Motorista Motorista { get; set; } = null!;
public ICollection<Entrega> Entregas { get; set; } = [];
```

## Relacionamento 1:1

### Quando usar

Use `1:1` quando uma entidade possui exatamente uma correspondente do outro lado.

Exemplo:

- `Usuario` e `Perfil`
- `Entrega` e `ComprovanteEntrega`

### Como fica no codigo

```csharp
public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public Perfil? Perfil { get; set; }
}
```

```csharp
public class Perfil
{
    public Guid Id { get; set; }
    public string Telefone { get; set; } = string.Empty;

    public Guid UsuarioId { get; set; }
    public Usuario Usuario { get; set; } = null!;
}
```

### Como pensar

- `Perfil` depende de `Usuario`
- por isso a FK fica em `Perfil`
- cada `Perfil` aponta para um unico `Usuario`
- cada `Usuario` aponta para um unico `Perfil`

### Resumo visual

```text
Usuario 1 ---- 1 Perfil
```

## Relacionamento 1:N

### Quando usar

Use `1:N` quando uma entidade principal pode ter varias dependentes.

Exemplo:

- `Motorista` e `Entrega`
- `Pedido` e `ItemPedido`
- `Cliente` e `Endereco`

### Como fica no codigo

```csharp
public class Motorista
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public ICollection<Entrega> Entregas { get; set; } = [];
}
```

```csharp
public class Entrega
{
    public Guid Id { get; set; }
    public string Codigo { get; set; } = string.Empty;

    public Guid MotoristaId { get; set; }
    public Motorista Motorista { get; set; } = null!;
}
```

### Como pensar

- um `Motorista` pode possuir varias `Entregas`
- cada `Entrega` pertence a um unico `Motorista`
- por isso a FK fica em `Entrega`

### Resumo visual

```text
Motorista 1 ---- N Entrega
```

## Relacionamento N:N

### Quando usar

Use `N:N` quando varios registros de um lado podem se relacionar com varios do outro lado.

Exemplo:

- `Entrega` e `Motorista`, se uma entrega puder passar por varios motoristas
- `Usuario` e `PerfilAcesso`
- `Produto` e `Categoria`

## Opcao 1: N:N direto

Quando a relacao nao precisa de dados extras, o modelo pode ser direto:

```csharp
public class Usuario
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public ICollection<PerfilAcesso> PerfisAcesso { get; set; } = [];
}
```

```csharp
public class PerfilAcesso
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public ICollection<Usuario> Usuarios { get; set; } = [];
}
```

### Resumo visual

```text
Usuario N ---- N PerfilAcesso
```

## Opcao 2: N:N com entidade associativa

Esta costuma ser a opcao mais flexivel.

Use quando a relacao precisa armazenar informacoes extras, por exemplo:

- data de vinculacao
- status
- observacao
- ordem

### Como fica no codigo

```csharp
public class Motorista
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public ICollection<MotoristaEntrega> MotoristaEntregas { get; set; } = [];
}
```

```csharp
public class Entrega
{
    public Guid Id { get; set; }
    public string Codigo { get; set; } = string.Empty;

    public ICollection<MotoristaEntrega> MotoristaEntregas { get; set; } = [];
}
```

```csharp
public class MotoristaEntrega
{
    public Guid MotoristaId { get; set; }
    public Motorista Motorista { get; set; } = null!;

    public Guid EntregaId { get; set; }
    public Entrega Entrega { get; set; } = null!;

    public DateTime DataVinculo { get; set; }
}
```

### Como pensar

- a tabela associativa quebra um `N:N` em dois relacionamentos `1:N`
- `Motorista 1:N MotoristaEntrega`
- `Entrega 1:N MotoristaEntrega`

### Resumo visual

```text
Motorista 1 ---- N MotoristaEntrega N ---- 1 Entrega
```

## Como Descobrir Onde Fica a FK

Use esta regra:

- a FK fica na entidade que depende da outra
- em `1:N`, ela fica no lado `N`
- em `1:1`, ela fica no lado dependente
- em `N:N` com entidade associativa, ela fica na entidade associativa

Exemplos:

- `Entrega` depende de `Motorista` -> `Entrega` recebe `MotoristaId`
- `Perfil` depende de `Usuario` -> `Perfil` recebe `UsuarioId`
- `MotoristaEntrega` depende de `Motorista` e `Entrega` -> recebe `MotoristaId` e `EntregaId`

## Regras Praticas para o Projeto

Ao criar qualquer entidade nova, siga estas decisoes:

1. Se a entidade tem varios filhos, use `ICollection<T>` no lado pai.
2. Se a entidade pertence a outra, crie `EntidadePaiId` e `EntidadePai`.
3. Evite guardar relacao como `string` quando ela representa outra entidade do dominio.
4. Se a relacao puder crescer de complexidade, prefira modelar corretamente desde cedo.
5. Se o relacionamento tiver dados proprios, use entidade associativa.

## Exemplo de Evolucao Correta

### Modelo simples, mas fraco

```csharp
public class Entrega
{
    public Guid Id { get; set; }
    public string Entregador { get; set; } = string.Empty;
}
```

Problema:

- `Entregador` e apenas texto
- nao existe relacao real no banco
- nao ha integridade referencial
- fica dificil consultar entregas por motorista real

### Modelo correto para dominio

```csharp
public class Motorista
{
    public Guid Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public ICollection<Entrega> Entregas { get; set; } = [];
}
```

```csharp
public class Entrega
{
    public Guid Id { get; set; }

    public Guid MotoristaId { get; set; }
    public Motorista Motorista { get; set; } = null!;
}
```

## Erros Comuns

- usar `string` para representar outra entidade
- criar colecao nos dois lados em relacao `1:N`
- esquecer a FK na entidade dependente
- criar `N:N` direto quando a relacao precisa guardar mais dados
- modelar primeiro no controller em vez de modelar primeiro no dominio

## Checklist Rapido de Relacionamento

Antes de finalizar uma entidade, valide:

1. A cardinalidade esta clara?
2. A FK esta na entidade correta?
3. As navegacoes representam a cardinalidade real?
4. O nome da FK segue o padrao `EntidadeId`?
5. O mapping do EF Core reflete essa relacao?
6. Existe chance de a relacao precisar de entidade associativa?

## Tabela de Consulta Rapida

```text
1:1  -> objeto de um lado, objeto do outro
1:N  -> colecao no lado pai, objeto no lado filho
N:N  -> colecao nos dois lados ou entidade associativa
FK   -> fica no lado dependente
```

## Regra Final

Se voce estiver em duvida, pense assim:

- "um registro deste lado pode ter quantos do outro?"
- se a resposta for "varios", normalmente existe `ICollection<T>`
- se a resposta for "um so", normalmente existe objeto simples
- se os dois lados responderem "varios", provavelmente e `N:N`

Este documento pode ser usado como base para qualquer nova entidade do sistema.
