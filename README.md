# CleanArchitecture — Engineering Practice (ASP.NET Core, .NET 10)

Purpose — why this repository exists
-----------------------------------
This repository is a focused learning ground for practicing software architecture and backend engineering with .NET 10. It is intentionally structured to exercise architectural boundaries, dependency inversion and modular design rather than to deliver an application product. The goal is to learn and iterate on architecture decisions, not to ship a finished system.

Why Clean Architecture here
---------------------------
- Clean Architecture separates concerns so you can evolve business rules independently of frameworks and infrastructure. That separation makes experiments (tests, persistence strategies, messaging patterns) low-cost.
- Starting with multiple projects (API / Application / Domain / Infrastructure) makes dependency directions explicit and enforces boundaries early in the learning process.

Engineering goals
-----------------
- Maintainability: small, well-delimited modules.
- Testability: enable unit and integration tests with minimal friction.
- Separation of concerns: keep business logic out of controllers and frameworks.
- Dependency inversion: domain once, implementations replaceable.
- Modularity and reusability: clear contracts and thin adapters.
- Clean code practices: small interfaces, explicit DI, readable tests.

Quick status (truthful)
-----------------------
- Solution: `CleanArchitecture.slnx` with four projects:
  - `CleanArchitecture` (API) — contains `Program.cs`, `WeatherForecastController`, `WeatherForecast` model and OpenAPI wiring.
  - `CleanArchitecture.Application` — present; currently contains a DI extension placeholder.
  - `CleanArchitecture.Domain` — present; currently minimal scaffolding (no business logic yet).
  - `CleanArchitecture.Infrastructure` — present; currently contains a DI extension placeholder.
- No test projects, no EF Core or other persistence provider, and no CI workflows are included yet.

Repository tree (actual)
-----------------------
```
CleanArchitecture.slnx
├─ CleanArchitecture/
│  ├─ Program.cs
│  ├─ CleanArchitecture.Api.csproj
│  ├─ Controllers/WeatherForecastController.cs
│  ├─ WeatherForecast.cs
│  └─ DependencyInjection.cs
├─ CleanArchitecture.Application/
│  ├─ CleanArchitecture.Application.csproj
│  └─ DependencyInjection.cs
├─ CleanArchitecture.Domain/
│  └─ CleanArchitecture.Domain.csproj
└─ CleanArchitecture.Infrastructure/
   ├─ CleanArchitecture.Infrastructure.csproj
   └─ DependencyInjection.cs
```

How to run (verified)
---------------------
From repository root:

```bash
dotnet restore
dotnet build
dotnet run --project CleanArchitecture/CleanArchitecture.Api.csproj
```

Or run from the API folder:

```bash
cd CleanArchitecture
dotnet run
```

Then open:

```
GET https://localhost:<port>/WeatherForecast
```

Architecture overview (educational)
---------------------------------
- Responsibilities:
  - API: HTTP entry point, request/response mapping, middleware and DI setup. Keep controllers thin.
  - Application: Use cases / application services, DTOs, orchestration of domain logic. Defines interfaces for infrastructure.
  - Domain: Entities, value objects, domain rules and interfaces. Business logic lives here and must be framework-agnostic.
  - Infrastructure: Concrete implementations (DB, external APIs, file storage). Contains adapters and DI wiring only.

- Dependency direction:
  Domain <- Application <- API
  Infrastructure -> Application / Domain (implements interfaces)

- Why Domain must be independent:
  Domain models and rules represent core business invariants. Tying them to infrastructure or framework APIs increases coupling and makes testing and evolution harder.

- Why Infrastructure contains implementation details only:
  Infrastructure is a replaceable layer. Keep implementation concerns (EF Core, HTTP clients, file storage) here so the application and domain layers remain testable and portable.

Simple architecture diagram
--------------------------
```text
   +-----+       +-----------+       +--------+
   | API | ----> | Application| ----> | Domain |
   +-----+       +-----------+       +--------+
                     ^   ^
                     |   |
                 +---+   +---+
                 |Infrastructure|
                 +-------------+
```

Planned technical topics (future, not implemented)
--------------------------------------------------
- CQRS, MediatR
- FluentValidation
- EF Core and migrations
- Result Pattern and consistent API responses
- Domain Events and event-driven patterns
- Repository pattern for persistence abstraction
- Unit testing and integration testing (xUnit)
- Docker for local environment parity
- GitHub Actions for CI (build + test)
- Observability: structured logging and metrics

Recommended next steps (small, practical)
----------------------------------------
1. Add a `.gitignore` for .NET.
2. Implement a simple domain entity and one application use case with a unit test.
3. Wire a minimal in-memory repository in `Infrastructure` and replace it later with EF Core.
4. Add a smoke test that exercises the `WeatherForecast` endpoint or the application layer.

Learning objectives
-------------------
This repo is intended to help you practice:
- Designing layer boundaries and DI registration
- Writing isolated unit tests for application logic
- Evolving persistence strategies without touching domain logic
- Keeping controllers thin and testable

Notes
-----
- The README intentionally avoids claiming features that are not present. Treat the codebase as a learning scaffold.
- If you want, I can create the `.gitignore` and scaffold lightweight test projects next.

License
-------
Add a `LICENSE` file if you want to share or publish this work.


