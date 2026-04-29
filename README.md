# 🏨 HotelBooking API

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?logo=dotnet&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-Web%20API-5C2D91)
![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?logo=microsoftsqlserver&logoColor=white)
![CQRS](https://img.shields.io/badge/Architecture-CQRS%20%2B%20MediatR-blue)
![Clean Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-success)

A modular **ASP.NET Core Web API** for hotel management: **rooms, room types, amenities, reservations, payments, refunds, cancellations**, and secure **authentication/authorization**.  
Built with **Clean Architecture**, **CQRS (MediatR)**, **EF Core + SQL Server**, and **ASP.NET Core Identity**.

---

## ✨ Key Highlights

- ✅ Clean Architecture (Presentation / Application / Infrastructure / Domain)
- ✅ CQRS + MediatR (Commands / Queries / Handlers)
- ✅ AutoMapper for mapping between Entities ↔ DTOs
- ✅ Specification Pattern for reusable query rules
- ✅ Repository Pattern + Unit of Work
- ✅ Result Pattern for consistent success/failure responses
- ✅ JWT Authentication + Refresh Tokens
- ✅ ASP.NET Core Identity for security & user management
- ✅ FluentValidation for request validation
- ✅ Global ExceptionHandlerMiddleware
- ✅ EF Core Fluent API configurations & constraints
- ✅ SOLID principles applied across layers
- ✅ Automatic DB migrations + JSON seed on startup
- ✅ Swagger/OpenAPI in Development

---

## 🎯 What Problem This Solves

Provides a backend API to manage hotel operations:
- Catalog management (RoomTypes / Amenities / Rooms)
- Booking lifecycle (availability search, reservations, guests)
- Payments & refunds
- Cancellation requests & cancellation policy rules
- Secure authentication and role-based access (**Admin / Manager / Guest**)

---

---

## 🧱 Architecture Overview

This solution follows a **Layered Clean Architecture-style** structure:

- **HotelBooking.Presentation**
  - API Controllers, Middlewares, Extensions, DI, Program.cs
- **HotelBooking.Application**
  - Features (CQRS), DTOs, Validators, Services Interfaces, Specifications, MappingProfiles, Result Types
- **HotelBooking.Infrastructure**
  - DbContext, Migrations, Identity, Security (JWT), Repositories, UnitOfWork, DataSeed
- **HotelBooking.Domain**
  - Entities, Contracts, Domain Services, ValueObjects

---
---

## 🗂️ Project Structure (Simplified)

```text
src/
 ├─ HotelBooking.Presentation
 │  ├─ Controllers
 │  ├─ CustomMiddlewares
 │  ├─ DependencyInjection
 │  ├─ Extensions / Factories
 │  ├─ appsettings.json
 │  └─ Program.cs
 │
 ├─ HotelBooking.Application
 │  ├─ Features
 │  │  ├─ Amenities (Commands / Queries)
 │  │  ├─ CancellationPolicies (Commands / Queries)
 │  │  ├─ Cancellations
 │  │  ├─ Countries
 │  │  ├─ Feedbacks
 │  │  ├─ HotelBooking
 │  │  ├─ HotelSearch
 │  │  ├─ Refunds
 │  │  ├─ RoomAmenities
 │  │  ├─ Rooms
 │  │  ├─ RoomTypes
 │  │  └─ States
 │  ├─ DTOs
 │  ├─ MappingProfiles (AutoMapper)
 │  ├─ Specifications
 │  ├─ Validators (FluentValidation)
 │  ├─ Results (Result Pattern)
 │  ├─ Interfaces / Services
 │  └─ DependencyInjection
 │
 ├─ HotelBooking.Infrastructure
 │  ├─ Data
 │  │  ├─ DbContexts
 │  │  ├─ Configurations (EF Fluent API)
 │  │  ├─ Migrations
 │  │  └─ DataSeed (JSON files + initializer)
 │  ├─ Identity
 │  │  ├─ Security (JwtService / JwtSettings / RefreshTokenService)
 │  │  └─ Entities
 │  ├─ Implementations (Repositories / UnitOfWork)
 │  ├─ SpecificationEvaluator.cs
 │  └─ DependencyInjection
 │
 └─ HotelBooking.Domain
    ├─ Entities
    ├─ Contracts
    ├─ Services
    └─ ValueObjects
```  

---
## 🧩 API Modules Overview (What each module does)

Below is a high-level, **module-based** explanation of the main controllers and their responsibilities.

---

### 🔐 Authentication Module (`AuthenticationController`)
**Purpose:** Handles the full authentication lifecycle using **JWT + Refresh Tokens** with **ASP.NET Core Identity**.

**Responsibilities:**
- User registration & login.
- Issuing **Access Tokens** + **Refresh Tokens**.
- Refreshing expired access tokens securely.
- Logout by invalidating refresh tokens.
- Password change for authenticated users.

---

