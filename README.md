# EShopMicroservices

See the overall picture of implementations on microservices with .net tools on real-world e-commerce microservices projects:
![Architecture](https://github.com/mahendraputra21/EShopMicroservices/assets/31196162/00c66501-98c1-4272-8ce0-f528f4f07aae)

## Catalog Microservice:
![Catalog-Architecture](https://github.com/mahendraputra21/EShopMicroservices/assets/31196162/eaf99982-d2c4-4312-b1c6-08431b749614)

* ASP.NET Core Minimal APIs and latest features of.NET8 and C# 12
* **Vertical Slice Architecture** implementation with Feature folders and single .cs file includes different classes in one file
* CQRS implementation using the MediatR library
* CQRS Validation Pipeline Behaviors with MediatR and FluentValidation
* Use Marten library for .NET Transactional Document DB on PostgreSQL
* Use Carter for Minimal API endpoint definition
* Cross-cutting concerns Logging, Global Exception Handling and Health Checks

## Basket Microservice
![Basket-Architecture](https://github.com/mahendraputra21/EShopMicroservices/assets/31196162/bf48e44b-85b6-4005-b739-62651bf15afc)

* ASP.NET 8 Web API application, Following REST API principles, CRUD
* Using **Redis** as a **Distributed Cache** over basketdb
* Implements Proxy, Decorator and Cache-aside patterns
* Consume Discount **Grpc Service** for inter-service sync communication to calculate product final price
* Publish BasketCheckout Queue with using **MassTransit and RabbitMQ**

## Discount Microservice
![Discount-Architecture](https://github.com/mahendraputra21/EShopMicroservices/assets/31196162/d3908d9f-45cd-4235-839f-961fccb052ea)

* ASP.NET **Grpc Server** application
* Build a Highly Performant **inter-service gRPC Communication** with Basket Microservice
* Exposing Grpc Services with creating **Protobuf messages**
* Entity Framework Core ORM — SQLite Data Provider and Migrations to simplify data access and ensure high performance
* **SQLite database** connection and containerization

## Ordering Microservice
![Ordering-Architecture](https://github.com/mahendraputra21/EShopMicroservices/assets/31196162/b9dcf6cb-2a9b-4ddb-9a8f-bd15a0b12d63)

* Implementing **DDD, CQRS, and Clean Architecture** with using Best Practices
* Developing **CQRS using MediatR, FluentValidation, and Mapster packages**
* Consuming **RabbitMQ** BasketCheckout event queue with using **MassTransit-RabbitMQ** Configuration
* **SqlServer database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to SqlServer when application startup

## Microservices Communication
* Sync inter-service **gRPC Communication**
* Async Microservices Communication with **RabbitMQ Message-Broker Service**
* Using **RabbitMQ Publish/Subscribe Topic** Exchange Model
* Using **MassTransit** for abstraction over the RabbitMQ Message-Broker system
* Publishing BasketCheckout event queue from Basket microservices and Subscribing to this event from Ordering microservices	
* Create **RabbitMQ EventBus.Messages library** and add references Microservices

## Yarp API Gateway Microservice
* Develop API Gateways with **Yarp Reverse Proxy** applying Gateway Routing Pattern
* Yarp Reverse Proxy Configuration; Route, Cluster, Path, Transform, Destinations
* **Rate Limiting** with FixedWindowLimiter on Yarp Reverse Proxy Configuration

## WebUI ShoppingApp Microservice
* ASP.NET Core Web Application with Bootstrap 4 and Razor template
* Call **Yarp APIs with Refit HttpClientFactory**

## Docker Compose establishment with all microservices on docker;
* Containerization of microservices
* Containerization of databases
* Override Environment variables
