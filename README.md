# EShopMicroservices

See the overall picture of implementations on microservices with .net tools on real-world e-commerce microservices project:
![Architecture](https://github.com/mahendraputra21/EShopMicroservices/assets/31196162/00c66501-98c1-4272-8ce0-f528f4f07aae)

## Catalog Microservice:
![Catalog-Architecture](https://github.com/mahendraputra21/EShopMicroservices/assets/31196162/eaf99982-d2c4-4312-b1c6-08431b749614)

* ASP.NET Core Minimal APIs and latest features of .NET8 and C# 12
* **Vertical Slice Architecture** implementation with Feature folders and single .cs file includes different classes in one file
* CQRS implementation using MediatR library
* CQRS Validation Pipeline Behaviors with MediatR and FluentValidation
* Use Marten library for .NET Transactional Document DB on PostgreSQL
* Use Carter for Minimal API endpoint definition
* Cross-cutting concerns Logging, Global Exception Handling and Health Checks
