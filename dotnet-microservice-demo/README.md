# Cloud-Ready Microservice API (.NET 8)

A clean, minimal and cloud-ready microservice demonstrating API design, EF Core, Docker, and good engineering practices.

📌 Overview

This is a Device Registry Service, a small microservice built using C#/.NET 8, Entity Framework Core, and SQLite.
It exposes a clean REST API for registering and managing devices — similar to real-world telecom/IoT systems.

The goal is to demonstrate:

Clean API design

Data modeling

Repository pattern

Cloud readiness (Docker)

Basic API-key authentication

Testing with xUnit

Modern .NET minimal API architecture

This project is part of my engineering portfolio for roles in software development, R&D, cloud, and distributed systems.

🏗 Architecture Diagram
                   +----------------------+
                   |   Client / Postman   |
                   +----------+-----------+
                              |
                              v
                    +---------+----------+
                    |   API Gateway      |
                    | (Minimal API)      |
                    +---------+----------+
                              |
                    +---------+----------+
                    |   DeviceService    |
                    +---------+----------+
                              |
                    +---------+----------+
                    | Repository Layer   |
                    |  EF Core / LINQ    |
                    +---------+----------+
                              |
                    +---------+----------+
                    | SQLite Database    |
                    +--------------------+

Explanation

API Layer

Minimal API in .NET 8

Endpoints for CRUD operations

Validates input

Checks API Key for simple authentication

Service Layer

Contains business logic (optional but recommended)

Repository Layer

Handles DB operations

Clean abstraction (IDeviceRepository)

Database

SQLite for simplicity (can be replaced with SQL Server / Azure SQL)

Docker

Containerized app for cloud deployment

📂 Project Structure
dotnet-microservice-demo/
  README.md
  docs/
    architecture-diagram.png     # optional
    api-endpoints.md
    decisions.md                 # optional
  src/
    DeviceRegistry.Api/
      Program.cs
      appsettings.json
      /Models
      /Dtos
      /Data
      /Repositories
      /Endpoints or /Controllers
      /Services
      Dockerfile
  tests/
    DeviceRegistry.Tests/
      DeviceRepositoryTests.cs
      DevicesApiTests.cs

🔌 Endpoints
GET    /api/devices
GET    /api/devices/{id}
POST   /api/devices
PUT    /api/devices/{id}
DELETE /api/devices/{id}


Authentication uses header:
X-API-KEY: your-secret-key

More details in docs/api-endpoints.md.

🚀 Running the Project
Run locally
cd src/DeviceRegistry.Api
dotnet run

Build Docker image
docker build -t device-registry-api .

🧪 Tests

Located in:

tests/DeviceRegistry.Tests/


Run tests:

dotnet test

🎯 Why I built this

I built this project to practice designing clean and cloud-ready microservices with .NET — focusing on API structure, data modeling, testability, and containerization.
These skills are core in telecom R&D, distributed systems, enterprise backends, and cloud-native engineering.

🚧 Future Improvements

Add OpenAPI/Swagger descriptions

Add pagination/filtering

Add Azure deployment

Add logging & metrics

Add gRPC alternative

🧑‍💻 Author

Nazgul Engvall

LinkedIn: linkedin.com/in/nazgulengvall

GitHub: github.com/nazgulengvall

Email: nazgul.engvall@gmail.com
