# Dotnet Learning

This repository contains my hands-on learning and implementation journey with ASP.NET Core Web API and Entity Framework Core.

I am building this project step-by-step while learning backend development concepts in .NET.

---

# Implemented So Far

## Project Setup

Completed:

- Created ASP.NET Core Web API project
- Configured project structure
- Added Entity Framework Core
- Configured SQL Server connection
- Created DbContext
- Added initial domain models

Concepts Learned:

- ASP.NET Core project structure
- Dependency Injection
- DbContext configuration
- EF Core basics

---

## Regions CRUD Operations

Completed:

- Created Region domain model
- Created Region DTOs
- Implemented Regions Controller
- Implemented Repository Pattern
- Added CRUD operations:
  - Create Region
  - Get All Regions
  - Get Region By Id
  - Update Region
  - Delete Region
- Connected API with SQL Server using EF Core
- Added Swagger testing support

Concepts Learned:

- REST APIs
- DTO usage
- Repository Pattern
- CRUD operations in ASP.NET Core
- EF Core database interaction
- API testing with Swagger

---

# Current Features

- Regions CRUD API
- SQL Server Integration
- Entity Framework Core
- Repository Pattern
- Swagger UI
- DTO Mapping

---

# Tech Stack

- ASP.NET Core Web API
- C#
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI

---

# Project Structure

```text
MyProject.API/
│
├── Controllers/
├── Data/
├── DTOs/
├── Models/
│   └── Domain/
├── Repositories/
├── Migrations/
├── Program.cs
└── appsettings.json
```

---

# Running the Project

## Clone Repository

```bash
git clone https://github.com/77-nikhilesh/dotnet-learning.git
```

## Restore Packages

```bash
dotnet restore
```

## Apply Migrations

```bash
dotnet ef database update
```

## Run Project

```bash
dotnet run
```

---

# Upcoming Learning Goals

Planned next:

- Walks CRUD operations
- Relationships in EF Core
- AutoMapper
- Validation
- JWT Authentication
- Logging
- Pagination & Filtering
- Deployment

---

This README acts as a public learning journal for my .NET backend journey.
