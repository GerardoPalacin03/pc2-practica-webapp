# Capbase Platform

RESTful API for the **Capbase** ecosystem, built with **C# 14**, **.NET 10** and **ASP.NET Core**.

## Description

Capbase helps founders manage their company, from incorporation to exit. This backend exposes the operations
related to **covenants**, the legal agreements that a company signs with a client. A covenant is identified by a
document identifier, belongs to a client, is valid during a legality period and has a total monetary value.

The application follows **Domain-Driven Design** and a **layered architecture** (domain, application, infrastructure
and interfaces), organized in bounded contexts:

| Bounded context | Purpose |
|-----------------|---------|
| `Paperwork`     | Core business: the `Covenant` aggregate root and its value objects, command service, repository, events and REST endpoint |
| `Shared`        | Reusable base elements: `AggregateRoot`, generic repository, unit of work, `Result`, `Error`, `LegalityPeriod`, `MonetaryAmount`, EF Core configuration, exception handling and localization resources |

Applied patterns: CQRS (commands), Aggregate, Value Object, Repository, Unit of Work, Domain Event, Result,
Resource and Assembler, Chain of Responsibility (ASP.NET Core middleware pipeline).

## Endpoint

| Method | URL                 | Description                                              |
|--------|---------------------|----------------------------------------------------------|
| POST   | `/api/v1/covenants` | Creates a covenant. Returns `201 Created` with the resource and its generated `id` |

Error responses use `ProblemDetails` with the proper HTTP status (`400` for business rule violations, `409` when the
document identifier already exists, `500` for unexpected errors). Messages are returned in English or Spanish
according to the `Accept-Language` header (`en`, `en-US`, `es`, `es-PE`).

Sample request body:

```json
{
  "documentIdentifier": "3f2b8c9e-6d1a-4b7e-9c55-0a1d2e3f4a5b",
  "clientId": "7c9e6679-7425-40de-944b-e07fc1f90ae7",
  "periodStartDate": "2026-01-01",
  "periodEndDate": "2026-12-31",
  "monetaryAmountValue": 15000.50,
  "monetaryAmountCurrency": "USD",
  "status": "Draft",
  "footnotes": "Optional notes"
}
```

## Business rules

- Two covenants cannot share the same `DocumentIdentifier`.
- `LegalityPeriod`: `EndDate` must be later than `StartDate`; `IsExpired(checkDate)` is `true` when `checkDate` is later than `EndDate`.
- `MonetaryAmount`: `value` must be greater than or equal to zero; `currency` must not be null or blank; the value can be multiplied by a factor keeping the currency.
- `CovenantStatus`: `Draft` (default), `Active` or `Expired`.
- `Covenant` is auditable (`created_at`, `updated_at`).

## Running the application

1. Install .NET 10 SDK and MySQL.
2. Update the connection string in `appsettings.Development.json` (database `clerky_wa`).
3. Run the project. The schema and the `covenants` table are created automatically on startup.
4. Open `http://localhost:5191/scalar/v1` to explore the OpenAPI documentation.

## Author

Gerardo Palacin  
Student code: 20211c201 · NRC: 8084
