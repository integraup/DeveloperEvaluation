# Estrutura de Diretórios - DeveloperEvaluation

```
DeveloperEvaluation
├── .git
├── .dockerignore
├── .editorconfig
├── .gitignore
├── Ambev.DeveloperEvaluation.sln
├── docker-compose.dcproj
├── docker-compose.yml
├── Dockerfile
├── obj/
├── src/
│   ├── Ambev.DeveloperEvaluation.Application/
│   │   ├── Auth/
│   │   ├── CartItems/
│   │   ├── Carts/
│   │   ├── Products/
│   │   ├── Users/
│   │   ├── bin/
│   │   ├── obj/
│   │   ├── Ambev.DeveloperEvaluation.Application.csproj
│   │   └── ApplicationLayer.cs
│   ├── Ambev.DeveloperEvaluation.Common/
│   │   ├── HealthChecks/
│   │   ├── Logging/
│   │   ├── Security/
│   │   ├── Validation/
│   │   ├── bin/
│   │   ├── obj/
│   │   └── Ambev.DeveloperEvaluation.Common.csproj
│   ├── Ambev.DeveloperEvaluation.Domain/
│   │   ├── Common/
│   │   ├── Entities/
│   │   ├── Enums/
│   │   ├── Events/
│   │   ├── Exceptions/
│   │   ├── Repositories/
│   │   ├── Services/
│   │   ├── Specifications/
│   │   ├── Validation/
│   │   ├── bin/
│   │   ├── obj/
│   │   └── Ambev.DeveloperEvaluation.Domain.csproj
│   ├── Ambev.DeveloperEvaluation.IoC/
│   │   ├── ModuleInitializers/
│   │   ├── bin/
│   │   ├── obj/
│   │   ├── Ambev.DeveloperEvaluation.IoC.csproj
│   │   ├── DependencyResolver.cs
│   │   └── IModuleInitializer.cs
│   ├── Ambev.DeveloperEvaluation.ORM/
│   │   ├── Mapping/
│   │   ├── Migrations/
│   │   ├── Repositories/
│   │   ├── Seed/
│   │   ├── bin/
│   │   ├── obj/
│   │   ├── appsettings.json
│   │   ├── Ambev.DeveloperEvaluation.ORM.csproj
│   │   └── DefaultContext.cs
│   └── Ambev.DeveloperEvaluation.WebApi/
│       ├── Common/
│       ├── Features/
│       ├── logs/
│       ├── Mappings/
│       ├── Middleware/
│       ├── bin/
│       ├── obj/
│       ├── appsettings.json
│       ├── appsettings.Development.json
│       ├── Ambev.DeveloperEvaluation.WebApi.csproj
│       ├── Ambev.DeveloperEvaluation.WebApi.http
│       ├── Dockerfile
│       └── Program.cs
├── tests/
```

## Arquitetura de Software Aplicada

Com base na estrutura de pastas, este projeto segue uma arquitetura **em camadas** fortemente inspirada em princípios de **Clean Architecture** ou **Onion Architecture**.

### Camadas Identificadas:

- **Domain Layer** (`.Domain`): Regras de negócio, entidades, repositórios e validações.
- **Application Layer** (`.Application`): Casos de uso, orquestração e serviços de aplicação.
- **Infrastructure Layer** (`.ORM`, `.IoC`, `.Common`): Persistência, injeção de dependência, segurança, logs, health checks etc.
- **Presentation Layer** (`.WebApi`): Controllers, endpoints REST, middlewares e configurações da API.

### Diagrama Conceitual:

```
Presentation Layer (WebApi)
         |
Application Layer (Use Cases)
         |
Domain Layer (Entities, Rules)
         |
Infrastructure Layer (ORM, Logs, DI)
```

### Padrões e Práticas Aplicadas

- DDD (Domain-Driven Design)
- SOLID Principles
- Separação de responsabilidades
- Inversão de dependência (IoC)
- Camadas testáveis e independentes
