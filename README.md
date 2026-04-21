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
