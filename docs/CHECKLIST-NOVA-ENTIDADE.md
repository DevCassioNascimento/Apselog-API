# Checklist de Nova Entidade

Este documento descreve a sequencia padrao para criar uma nova entidade na arquitetura atual do projeto.

## Ordem Recomendada

1. Criar a entidade na camada `Domain`.
   Exemplo: `src/Apselog.Domain/Entities/NovaEntidade.cs`

2. Criar enums relacionados, se existirem.
   Exemplo: `src/Apselog.Domain/Enums`

3. Criar a interface do repositorio no `Domain`.
   Exemplo: `src/Apselog.Domain/Interfaces/Repositories/INovaEntidadeRepository.cs`

4. Criar os DTOs de request na camada `Application`.
   Exemplo:
   - `CriarNovaEntidadeRequest.cs`
   - `AtualizarNovaEntidadeRequest.cs`
   - `ListarNovaEntidadeRequest.cs`
   - `ExcluirNovaEntidadeRequest.cs`

5. Criar os DTOs de response na camada `Application`.
   Exemplo:
   - `CriarNovaEntidadeResponse.cs`
   - `AtualizarNovaEntidadeResponse.cs`
   - `ListarNovaEntidadeResponse.cs`
   - `ExcluirNovaEntidadeResponse.cs`

6. Criar as interfaces dos casos de uso.
   Exemplo:
   - `ICriarNovaEntidadeUseCase.cs`
   - `IAtualizarNovaEntidadeUseCase.cs`
   - `IListarNovaEntidadeUseCase.cs`
   - `IExcluirNovaEntidadeUseCase.cs`

7. Implementar os casos de uso.
   Exemplo:
   - `CriarNovaEntidadeUseCase.cs`
   - `AtualizarNovaEntidadeUseCase.cs`
   - `ListarNovaEntidadeUseCase.cs`
   - `ExcluirNovaEntidadeUseCase.cs`

8. Criar o repositorio concreto na camada `Infrastructure`.
   Exemplo: `src/Apselog.Infrastructure/Repositories/NovaEntidadeRepository.cs`

9. Registrar o repositorio na DI da `Infrastructure`.
   Arquivo: `src/Apselog.Infrastructure/Extensions/DependencyInjection.cs`

10. Registrar os casos de uso na DI da `Application`.
    Arquivo: `src/Apselog.Application/Extensions/DependencyInjection.cs`

11. Verificar se a camada `Application` possui as dependencias necessarias para a DI.
    Exemplo: `Microsoft.Extensions.DependencyInjection.Abstractions`

12. Criar o controller na camada `API`.
    Exemplo: `src/Apselog.API/Controllers/NovaEntidadeController.cs`

13. Adicionar o `DbSet` da entidade no `ApplicationDbContext`.
    Arquivo: `src/Apselog.Infrastructure/Contexts/ApplicationDbContext.cs`

14. Criar o mapping da entidade no EF Core.
    Exemplo: `src/Apselog.Infrastructure/Mappings/NovaEntidadeMapping.cs`

15. Gerar a migration para refletir a nova entidade no banco.

16. Validar a execucao da API e testar os endpoints.

## Estrutura Minima Esperada

- `Domain`: entidade, enums, interfaces de repositorio
- `Application`: DTOs, interfaces de use case, use cases
- `Infrastructure`: repositorio concreto, DbContext, mapping, DI
- `API`: controller

## Boas Praticas

- Manter regras de negocio nos use cases e no dominio.
- Manter o controller fino, apenas recebendo request e retornando response.
- Nao acessar `DbContext` diretamente no controller.
- Nao criar um repositorio por acao. O padrao atual do projeto e um repositorio por entidade.
- Registrar todas as dependencias nos arquivos `DependencyInjection.cs`.
- Criar mapping explicito para a entidade em vez de depender so da convencao.

## Resumo Rapido

1. Entity
2. IRepository
3. Request/Response
4. Interfaces de use case
5. Use cases
6. Repository
7. DI
8. Controller
9. DbSet
10. Mapping
11. Migration
