There is a couple of microservices which implemented **e-commerce** modules over **Catalog, Basket, Discount** and **Ordering** microservices with **NoSQL (DocumentDb, Redis)** and **Relational databases (PostgreSQL, Sql Server)** with communicating over **RabbitMQ Event Driven Communication** and using **Yarp API Gateway**.

![microservices](https://github.com/aspnetrun/run-aspnetcore-microservices/assets/1147445/efe5e688-67f2-4ddd-af37-d9d3658aede4)


## Whats Including In This Repository

#### Catalog microservice which includes; 
* ASP.NET Core Minimal APIs and latest features of .NET8 and C# 12
* **Vertical Slice Architecture** implementation with Feature folders and single .cs file includes different classes in one file
* CQRS implementation using MediatR library
* CQRS Validation Pipeline Behaviors with MediatR and FluentValidation
* Use Marten library for .NET Transactional Document DB on PostgreSQL
* Use Carter for Minimal API endpoint definition
* Cross-cutting concerns Logging, Global Exception Handling and Health Checks

#### Basket microservice which includes;
* ASP.NET 8 Web API application, Following REST API principles, CRUD
* Using **Redis** as a **Distributed Cache** over basketdb
* Implements Proxy, Decorator and Cache-aside patterns
* Consume Discount **Grpc Service** for inter-service sync communication to calculate product final price
* Publish BasketCheckout Queue with using **MassTransit and RabbitMQ**
  
#### Discount microservice which includes;
* ASP.NET **Grpc Server** application
* Build a Highly Performant **inter-service gRPC Communication** with Basket Microservice
* Exposing Grpc Services with creating **Protobuf messages**
* Entity Framework Core ORM — SQLite Data Provider and Migrations to simplify data access and ensure high performance
* **SQLite database** connection and containerization

#### Microservices Communication
* Sync inter-service **gRPC Communication**
* Async Microservices Communication with **RabbitMQ Message-Broker Service**
* Using **RabbitMQ Publish/Subscribe Topic** Exchange Model
* Using **MassTransit** for abstraction over RabbitMQ Message-Broker system
* Publishing BasketCheckout event queue from Basket microservices and Subscribing this event from Ordering microservices	
* Create **RabbitMQ EventBus.Messages library** and add references Microservices

#### Ordering Microservice
* Implementing **DDD, CQRS, and Clean Architecture** with using Best Practices
* Developing **CQRS with using MediatR, FluentValidation and Mapster packages**
* Consuming **RabbitMQ** BasketCheckout event queue with using **MassTransit-RabbitMQ** Configuration
* **SqlServer database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to SqlServer when application startup
	
#### Yarp API Gateway Microservice
* Develop API Gateways with **Yarp Reverse Proxy** applying Gateway Routing Pattern
* Yarp Reverse Proxy Configuration; Route, Cluster, Path, Transform, Destinations
* **Rate Limiting** with FixedWindowLimiter on Yarp Reverse Proxy Configuration

#### Docker Compose establishment with all microservices on docker;
* Containerization of microservices
* Containerization of databases
* Override Environment variables

## Run The Project
You will need the following tools:

* [.Net Core 8 or later](https://dotnet.microsoft.com/download/dotnet-core/8)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Installing
Follow these steps to get your development environment set up: (Before Run Start the Docker Desktop)
1. Clone the repository
2. At the root directory of solution, run below command:
```csharp
docker-compose up -d
```

3. Wait for docker compose all microservices. That’s it! (some microservices need extra time to work so please wait if not worked in first shut)
